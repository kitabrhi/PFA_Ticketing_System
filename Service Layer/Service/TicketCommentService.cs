using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Service_Layer.Service
{
    public class TicketCommentService : ITicketCommentService
    {
        private readonly ITicketCommentRepository _commentRepository;

        public TicketCommentService(ITicketCommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<TicketComment>> GetCommentsByTicketIdAsync(int ticketId)
        {
            return await _commentRepository.GetCommentsByTicketIdAsync(ticketId);
        }

        public async Task<TicketComment> AddCommentAsync(TicketComment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));
            if (string.IsNullOrEmpty(comment.CommentText)) throw new ArgumentException("Comment text cannot be empty");

            comment.CreatedDate = DateTime.Now;
            return await _commentRepository.AddAsync(comment);
        }

        public async Task<TicketComment> GetCommentByIdAsync(int commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {commentId} not found");
            }
            return comment;
        }

        public async Task UpdateCommentAsync(TicketComment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));

            var existingComment = await _commentRepository.GetByIdAsync(comment.CommentID);
            if (existingComment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {comment.CommentID} not found");
            }

            await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {commentId} not found");
            }

            await _commentRepository.DeleteAsync(comment);
        }

        public async Task<IEnumerable<TicketComment>> GetPublicCommentsByTicketIdAsync(int ticketId)
        {
            return await _commentRepository.GetPublicCommentsByTicketIdAsync(ticketId);
        }

        public async Task<IEnumerable<TicketComment>> GetInternalCommentsByTicketIdAsync(int ticketId)
        {
            return await _commentRepository.GetInternalCommentsByTicketIdAsync(ticketId);
        }
    }
}

