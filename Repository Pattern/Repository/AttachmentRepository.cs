using Microsoft.EntityFrameworkCore;
using Ticketing_System;
using Ticketing_System.Models;

public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
{
    private readonly string _storageBasePath;

    public AttachmentRepository(ApplicationDbContext context, IConfiguration configuration) : base(context)
    {
        _storageBasePath = configuration["AttachmentStorage:BasePath"] ?? "Attachments";
        Directory.CreateDirectory(_storageBasePath);
    }

    public async Task<IEnumerable<Attachment>> GetAttachmentsByTicketIdAsync(int ticketId)
    {
        return await _dbSet
            .Where(a => a.TicketID == ticketId)
            .Include(a => a.Uploader)
            .OrderByDescending(a => a.UploadedDate)
            .ToListAsync();
    }

    public async Task<Stream> GetAttachmentContentAsync(int attachmentId)
    {
        var attachment = await _dbSet.FindAsync(attachmentId);
        if (attachment == null)
            return null;

        string filePath = Path.Combine(_storageBasePath, attachment.FilePath);
        if (!File.Exists(filePath))
            return null;

        return new FileStream(filePath, FileMode.Open, FileAccess.Read);
    }

    public async Task SaveAttachmentContentAsync(int attachmentId, Stream content)
    {
        var attachment = await _dbSet.FindAsync(attachmentId);
        if (attachment == null)
            throw new ArgumentException("Attachment not found", nameof(attachmentId));

        string directory = Path.Combine(_storageBasePath, attachmentId.ToString());
        Directory.CreateDirectory(directory);

        string filePath = Path.Combine(directory, attachment.FileName);
        attachment.FilePath = Path.Combine(attachmentId.ToString(), attachment.FileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await content.CopyToAsync(fileStream);
        }

        await UpdateAsync(attachment);
    }
}