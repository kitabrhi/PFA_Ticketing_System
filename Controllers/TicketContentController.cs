using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;
using Index = Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor.Index;

namespace Ticketing_System.Controllers
{
    public class TicketContentController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketCommentService _commentService;
        private readonly IAttachmentService _attachmentService;

        public TicketContentController(
            ITicketService ticketService,
            ITicketCommentService commentService,
            IAttachmentService attachmentService)
        {
            _ticketService = ticketService;
            _commentService = commentService;
            _attachmentService = attachmentService;
        }
        // POST: Ticket/AddComment
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddComment(int ticketId, string commentText, bool isInternal = false)
        {
            if (string.IsNullOrWhiteSpace(commentText))
            {
                TempData["ErrorMessage"] = "Le texte du commentaire ne peut pas être vide";
                return RedirectToAction(nameof(Details), new { id = ticketId });
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

                await _commentService.AddCommentAsync(comment);
                TempData["SuccessMessage"] = "Commentaire ajouté avec succès";
            }
            catch (KeyNotFoundException)
            {
                TempData["ErrorMessage"] = "Ticket non trouvé";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur lors de l'ajout du commentaire: {ex.Message}";
            }

            return RedirectToAction(nameof(Details), new { id = ticketId });
        }

        // GET: Ticket/EditComment/5
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditComment(int id)
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

                ViewBag.TicketId = comment.TicketID;
                return View(comment);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Ticket/EditComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> EditComment(int id, TicketComment comment)
        {
            if (id != comment.CommentID)
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(comment.CommentText))
            {
                ModelState.AddModelError("CommentText", "Le texte du commentaire ne peut pas être vide");
                ViewBag.TicketId = comment.TicketID;
                return View(comment);
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
                existingComment.CommentText = comment.CommentText;

                // Pour les commentaires internes, vérifier que l'utilisateur a le rôle approprié
                if (User.IsInRole("Admin") || User.IsInRole("SupportAgent"))
                {
                    existingComment.IsInternal = comment.IsInternal;
                }

                await _commentService.UpdateCommentAsync(existingComment);
                TempData["SuccessMessage"] = "Commentaire mis à jour avec succès";

                return RedirectToAction(nameof(Details), new { id = existingComment.TicketID });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erreur lors de la mise à jour du commentaire: {ex.Message}");
                ViewBag.TicketId = comment.TicketID;
                return View(comment);
            }
        }

        // GET: Ticket/DeleteComment/5
        [HttpGet]
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

                ViewBag.TicketId = comment.TicketID;
                return View(comment);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Ticket/DeleteComment/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteCommentConfirmed(int id)
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

                int ticketId = comment.TicketID;
                await _commentService.DeleteCommentAsync(id);

                TempData["SuccessMessage"] = "Commentaire supprimé avec succès";
                return RedirectToAction(nameof(Details), new { id = ticketId });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur lors de la suppression du commentaire: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Ticket/UploadAttachment
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UploadAttachment(int ticketId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["ErrorMessage"] = "Aucun fichier n'a été téléchargé";
                return RedirectToAction(nameof(Details), new { id = ticketId });
            }

            try
            {
                // Vérifier si le ticket existe
                await _ticketService.GetTicketByIdAsync(ticketId);

                // Créer la pièce jointe
                var attachment = new Attachment
                {
                    TicketID = ticketId,
                    FileName = file.FileName,
                    UploaderUserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    UploadedDate = DateTime.Now
                };

                // Enregistrer le fichier
                using (var stream = file.OpenReadStream())
                {
                    await _attachmentService.AddAttachmentAsync(attachment, stream);
                }

                TempData["SuccessMessage"] = "Fichier téléchargé avec succès";
            }
            catch (KeyNotFoundException)
            {
                TempData["ErrorMessage"] = "Ticket non trouvé";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur lors du téléchargement du fichier: {ex.Message}";
            }

            return RedirectToAction(nameof(Details), new { id = ticketId });
        }

        // GET: Ticket/DownloadAttachment/5
        [HttpGet]
        public async Task<IActionResult> DownloadAttachment(int id)
        {
            try
            {
                var attachment = await _attachmentService.GetAttachmentByIdAsync(id);
                var content = await _attachmentService.GetAttachmentContentAsync(id);

                if (content == null)
                {
                    return NotFound();
                }

                // Renvoyer le fichier au navigateur
                return File(content, "application/octet-stream", attachment.FileName);
            }
            catch (KeyNotFoundException)
            {
                TempData["ErrorMessage"] = "Pièce jointe non trouvée";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur lors du téléchargement de la pièce jointe: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Ticket/DeleteAttachment/5
        [HttpGet]
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

                ViewBag.TicketId = attachment.TicketID;
                return View(attachment);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Ticket/DeleteAttachment/5
        [HttpPost, ActionName("DeleteAttachment")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteAttachmentConfirmed(int id)
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

                int ticketId = attachment.TicketID;
                await _attachmentService.DeleteAttachmentAsync(id);

                TempData["SuccessMessage"] = "Pièce jointe supprimée avec succès";
                return RedirectToAction(nameof(Details), new { id = ticketId });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur lors de la suppression de la pièce jointe: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}