using Ticketing_System.Models;

public interface IAttachmentRepository : IRepository<Attachment>
{
    Task<IEnumerable<Attachment>> GetAttachmentsByTicketIdAsync(int ticketId);
    Task<Stream> GetAttachmentContentAsync(int attachmentId);
    Task SaveAttachmentContentAsync(int attachmentId, Stream content);
    Task<Attachment> AddWithContentAsync(Attachment attachment, Stream content);
}
