using Bau.Seedit.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.RepositoryInterface
{
    public interface ICommentRepository
    {
        bool createComment(Comment comment);
        List<Comment> getAllComments();
        bool updateComment(Comment comment);
        bool deleteComment(int id);
        bool CommentUpVote(int CommentId);
        bool CommentDownVote(int CommentId);

    }
}
