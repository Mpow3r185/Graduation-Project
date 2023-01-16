using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.ServiceInterface
{
    public interface ICommentService
    {
        bool createComment(Comment comment);
        List<Comment> getAllComments();
        bool updateComment(Comment comment);
        bool deleteComment(int id);
        bool CommentUpVote(int CommentId);
        bool CommentDownVote(int CommentId);
        List<CommentDTO> getCommentsByPostId(int id);

    }
}
