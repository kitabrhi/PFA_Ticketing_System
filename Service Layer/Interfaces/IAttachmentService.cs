using Ticketing_System.Models;

public interface IAttachmentService
{
    Task<IEnumerable<Attachment>> GetAttachmentsByTicketIdAsync(int ticketId);
    Task<Attachment> GetAttachmentByIdAsync(int attachmentId);
    Task<Attachment> AddAttachmentAsync(Attachment attachment, Stream fileContent);
    Task DeleteAttachmentAsync(int attachmentId);
    Task<Stream> GetAttachmentContentAsync(int attachmentId);
    Task<bool> CanDeleteAttachmentAsync(string userId, int attachmentId);
}
