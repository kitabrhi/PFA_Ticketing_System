using Ticketing_System.Models;

public class AttachmentService : IAttachmentService
{
    private readonly IAttachmentRepository _attachmentRepository;

    public AttachmentService(IAttachmentRepository attachmentRepository)
    {
        _attachmentRepository = attachmentRepository;
    }

    public async Task<IEnumerable<Attachment>> GetAttachmentsByTicketIdAsync(int ticketId)
    {
        return await _attachmentRepository.GetAttachmentsByTicketIdAsync(ticketId);
    }

    public async Task<Attachment> GetAttachmentByIdAsync(int attachmentId)
    {
        var attachment = await _attachmentRepository.GetByIdAsync(attachmentId);
        if (attachment == null)
        {
            throw new KeyNotFoundException($"Attachment with ID {attachmentId} not found");
        }
        return attachment;
    }

    // Dans AttachmentService.cs


    public async Task DeleteAttachmentAsync(int attachmentId)
    {
        var attachment = await _attachmentRepository.GetByIdAsync(attachmentId);
        if (attachment == null)
        {
            throw new KeyNotFoundException($"Attachment with ID {attachmentId} not found");
        }

        await _attachmentRepository.DeleteAsync(attachment);
    }

    public async Task<Stream> GetAttachmentContentAsync(int attachmentId)
    {
        return await _attachmentRepository.GetAttachmentContentAsync(attachmentId);
    }

    public async Task<bool> CanDeleteAttachmentAsync(string userId, int attachmentId)
    {
        var attachment = await _attachmentRepository.GetByIdAsync(attachmentId);
        if (attachment == null) return false;

        // Le créateur de la pièce jointe ou un admin peut la supprimer
        return attachment.UploaderUserId == userId;
        // Note: Dans un cas réel, ajoutez également une vérification du rôle Admin
    }

    public async Task<Attachment> AddAttachmentAsync(Attachment attachment, Stream fileContent)
    {
        if (attachment == null) throw new ArgumentNullException(nameof(attachment));
        if (fileContent == null) throw new ArgumentNullException(nameof(fileContent));

        try
        {
            attachment.UploadedDate = DateTime.Now;

            // Utiliser la nouvelle méthode qui gère tout en une seule transaction
            return await _attachmentRepository.AddWithContentAsync(attachment, fileContent);
        }
        catch (Exception ex)
        {
            // Log de l'erreur
            Console.WriteLine($"Error adding attachment: {ex.Message}");
            // Rethrow avec plus de contexte
            throw new Exception($"Failed to add attachment: {ex.Message}", ex);
        }
    }
}