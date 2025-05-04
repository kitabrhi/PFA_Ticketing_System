using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketContentApiController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketCommentService _commentService;
        private readonly IAttachmentService _attachmentService;

        public TicketContentApiController(
            ITicketService ticketService, 
            ITicketCommentService commentService, 
            IAttachmentService attachmentService)
        {
            _ticketService = ticketService;
            _commentService = commentService;
            _attachmentService = attachmentService;
        }

        // POST: api/TicketContentApi/AddComment
        [HttpPost("AddComment")]
        [Authorize]
        public async Task<IActionResult> AddComment(int ticketId, string commentText, bool isInternal = false)
        {
            if (string.IsNullOrWhiteSpace(commentText))
            {
                return BadRequest(new { message = "Le texte du commentaire ne peut pas être vide" });
            }

            try
            {
                // Vérifier si le ticket existe
                await _ticketService.GetTicketByIdAsync(ticketId);

                // Pour les commentaires internes, vérifier que l'utilisateur a le rôle approprié
                if (isInternal && !User.IsInRole("Admin") && !User.IsInRole("SupportAgent"))
                {
                    isInternal = false; // Forcer à false pour les utilisateurs normaux
                }

                // Créer le commentaire
                var comment = new TicketComment
                {
                    TicketID = ticketId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CommentText = commentText,
                    IsInternal = isInternal,
                    CreatedDate = DateTime.Now
                };

                var addedComment = await _commentService.AddCommentAsync(comment);
                return Ok(new { success = true, comment = addedComment });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Ticket non trouvé" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erreur lors de l'ajout du commentaire: {ex.Message}" });
            }
        }

        // PUT: api/TicketContentApi/EditComment/5
        [HttpPut("EditComment/{id}")]
        [Authorize]
        public async Task<IActionResult> EditComment(int id, string commentText, bool isInternal = false)
        {
            if (string.IsNullOrWhiteSpace(commentText))
            {
                return BadRequest(new { message = "Le texte du commentaire ne peut pas être vide" });
            }

            try
            {
                // Récupérer le commentaire existant
                var existingComment = await _commentService.GetCommentByIdAsync(id);

                // Vérifier si l'utilisateur est l'auteur du commentaire ou un admin
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (existingComment.UserId != userId && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                // Mettre à jour uniquement les champs autorisés
                existingComment.CommentText = commentText;

                // Pour les commentaires internes, vérifier que l'utilisateur a le rôle approprié
                if (User.IsInRole("Admin") || User.IsInRole("SupportAgent"))
                {
                    existingComment.IsInternal = isInternal;
                }

                await _commentService.UpdateCommentAsync(existingComment);
                return Ok(new { success = true, comment = existingComment });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Commentaire non trouvé" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erreur lors de la mise à jour du commentaire: {ex.Message}" });
            }
        }

        // DELETE: api/TicketContentApi/DeleteComment/5
        [HttpDelete("DeleteComment/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                var comment = await _commentService.GetCommentByIdAsync(id);

                // Vérifier si l'utilisateur est l'auteur du commentaire ou un admin
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (comment.UserId != userId && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                await _commentService.DeleteCommentAsync(id);
                return Ok(new { success = true, message = "Commentaire supprimé avec succès" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Commentaire non trouvé" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erreur lors de la suppression du commentaire: {ex.Message}" });
            }
        }

        // POST: api/TicketContentApi/UploadAttachment
        [HttpPost("UploadAttachment")]
        [Authorize]
        public async Task<IActionResult> UploadAttachment(int ticketId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "Aucun fichier téléchargé" });
            }

            try
            {
                // Vérifier si le ticket existe
                var ticket = await _ticketService.GetTicketByIdAsync(ticketId);

                // Vérifier l'ID utilisateur
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest(new { message = "Échec de l'identification de l'utilisateur" });
                }

                // Créer la pièce jointe avec des valeurs par défaut
                var attachment = new Attachment
                {
                    TicketID = ticketId,
                    FileName = Path.GetFileName(file.FileName),
                    UploaderUserId = userId,
                    UploadedDate = DateTime.Now,
                };

                // Utiliser un MemoryStream pour garantir que le contenu complet est disponible
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    memoryStream.Position = 0; // Réinitialiser la position pour la lecture

                    var addedAttachment = await _attachmentService.AddAttachmentAsync(attachment, memoryStream);
                    return Ok(new { success = true, attachment = addedAttachment });
                }
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Ticket non trouvé" });
            }
            catch (Exception ex)
            {
                // Capture de l'exception interne pour plus de détails
                var innerException = ex.InnerException != null ? $" Inner error: {ex.InnerException.Message}" : "";
                return StatusCode(500, new { message = $"Erreur lors du téléchargement du fichier: {ex.Message}.{innerException}" });
            }
        }

        // GET: api/TicketContentApi/DownloadAttachment/5
        [HttpGet("DownloadAttachment/{id}")]
        public async Task<IActionResult> DownloadAttachment(int id)
        {
            try
            {
                var attachment = await _attachmentService.GetAttachmentByIdAsync(id);
                var content = await _attachmentService.GetAttachmentContentAsync(id);

                if (content == null)
                {
                    return NotFound(new { message = "Contenu de la pièce jointe non trouvé" });
                }

                // Renvoyer le fichier au navigateur
                return File(content, "application/octet-stream", attachment.FileName);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Pièce jointe non trouvée" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erreur lors du téléchargement de la pièce jointe: {ex.Message}" });
            }
        }

        // DELETE: api/TicketContentApi/DeleteAttachment/5
        [HttpDelete("DeleteAttachment/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            try
            {
                var attachment = await _attachmentService.GetAttachmentByIdAsync(id);

                // Vérifier si l'utilisateur est autorisé à supprimer cette pièce jointe
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                bool canDelete = await _attachmentService.CanDeleteAttachmentAsync(userId, id) || User.IsInRole("Admin");

                if (!canDelete)
                {
                    return Forbid();
                }

                await _attachmentService.DeleteAttachmentAsync(id);
                return Ok(new { success = true, message = "Pièce jointe supprimée avec succès" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Pièce jointe non trouvée" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erreur lors de la suppression de la pièce jointe: {ex.Message}" });
            }
        }
    }
}