using Bau.Seedit.Core.Common;
using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bau.Seedit.Infra.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IDbContext dbContext;

        public CommentRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool CommentDownVote(int commentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@comment_id", commentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("commentDownVote", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool CommentUpVote(int commentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@comment_id", commentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("commentUpVote", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool createComment(Comment comment)
        {
            var parameters = new DynamicParameters();      
            parameters.Add("@post_id", comment.postId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@text_", comment.text, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("createComment", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool deleteComment(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@comment_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("deleteComment", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Comment> getAllComments()
        {
            IEnumerable<Comment> result = dbContext.Connection.Query<Comment>("getAllComments", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool updateComment(Comment comment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@comment_id", comment.postId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@text_", comment.text, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Comment>("updateComment", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
