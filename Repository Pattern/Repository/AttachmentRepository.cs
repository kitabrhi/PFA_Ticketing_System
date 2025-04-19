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

        // Créer le dossier s'il n'existe pas
        string directory = Path.Combine(_storageBasePath, attachmentId.ToString());
        Directory.CreateDirectory(directory);

        // Nom de fichier sécurisé
        string safeFileName = Path.GetFileNameWithoutExtension(attachment.FileName) + "_" +
                              Guid.NewGuid().ToString().Substring(0, 8) +
                              Path.GetExtension(attachment.FileName);

        // Chemin complet du fichier
        string filePath = Path.Combine(directory, safeFileName);

        // Mettre à jour le chemin dans l'entité
        attachment.FilePath = Path.Combine(attachmentId.ToString(), safeFileName);

        try
        {
            // Enregistrer le fichier sur le disque
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                content.Position = 0; // S'assurer que le stream est au début
                await content.CopyToAsync(fileStream);
            }

            // Mettre à jour l'entité dans la base de données
            await UpdateAsync(attachment);
        }
        catch (Exception ex)
        {
            // Log de l'erreur ou propagation avec plus de détails
            throw new Exception($"Failed to save attachment content: {ex.Message}", ex);
        }
    }
    public async Task<Attachment> AddWithContentAsync(Attachment attachment, Stream content)
    {
        // Génération d'un nom de fichier temporaire unique
        attachment.FilePath = $"temp_{Guid.NewGuid()}";

        // Sauvegarde initiale dans la base de données
        var addedAttachment = await AddAsync(attachment);

        // Création du répertoire de stockage
        string directory = Path.Combine(_storageBasePath, addedAttachment.AttachmentId.ToString());
        Directory.CreateDirectory(directory);

        // Génération d'un nom de fichier sécurisé
        string safeFileName = Path.GetFileNameWithoutExtension(attachment.FileName) + "_" +
                             Guid.NewGuid().ToString().Substring(0, 8) +
                             Path.GetExtension(attachment.FileName);

        string filePath = Path.Combine(directory, safeFileName);
        string relativePath = Path.Combine(addedAttachment.AttachmentId.ToString(), safeFileName);

        // Sauvegarde du fichier sur le disque
        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            content.Position = 0;
            await content.CopyToAsync(fileStream);
        }

        // Mise à jour du chemin du fichier
        addedAttachment.FilePath = relativePath;
        await UpdateAsync(addedAttachment);

        return addedAttachment;
    }
}