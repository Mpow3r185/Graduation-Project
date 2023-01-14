using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using Bau.Seedit.Core.ServiceInterface;
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
        public bool CommentDownVote(int CommentId)
        {
            return commentRepository.CommentDownVote(CommentId);
        }

        public bool CommentUpVote(int CommentId)
        {
            return commentRepository.CommentUpVote(CommentId);
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
