using Bau.Seedit.Core.Common;
using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using Bau.Seedit.Core.ServiceInterface;
using BAU.SeedIT.Core.DTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bau.Seedit.Infra.Repository
{
    public class PostActionRepository: IPostActionRepository
    {
        private readonly IDbContext dbContext;

        public PostActionRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool createPostAction(PostAction postAction)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_id", postAction.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@post_id", postAction.postId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@up_vote", postAction.upVote, dbType: DbType.Boolean, direction: ParameterDirection.Input);
            parameters.Add("@down_vote", postAction.downVote, dbType: DbType.Boolean, direction: ParameterDirection.Input);
            parameters.Add("@comment_id", postAction.commentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("createPostAction", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<PostActionDTO> getPostActionsByPostId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return dbContext.Connection.Query<PostActionDTO>("getPostActionsByPostId", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public bool deletePostAction(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("deletePostAction", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<PostAction> getAllPostActions()
        {
            IEnumerable<PostAction> result = dbContext.Connection.Query<PostAction>("getAllPostAction", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
