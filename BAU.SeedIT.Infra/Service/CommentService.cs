using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using Bau.Seedit.Core.ServiceInterface;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Infra.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository _commentRepository)
        {
            commentRepository = _commentRepository;
        }
        public List<CommentDTO> getCommentsByPostId(int id)
        {
            return commentRepository.getCommentsByPostId(id);
        }

            public bool createComment(Comment comment)
        {
            return commentRepository.createComment(comment);
        }

        public bool deleteComment(int id)
        {
            return commentRepository.deleteComment(id);
        }

        public List<Comment> getAllComments()
        {
            return commentRepository.getAllComments();
        }

        public bool updateComment(Comment comment)
        {
            return commentRepository.updateComment(comment);
        }
    }
}
