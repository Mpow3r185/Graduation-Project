using Bau.Seedit.Core.Common;
using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using BAU.SeedIT.Core.DTO;
using BAU.SeedIT.Core.Response;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bau.Seedit.Infra.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IDbContext dbContext;

        public PostRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Post createPost(Post post)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@post_title", post.title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@post_content", post.content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@author_id", post.authorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("createPost", parameters, commandType: CommandType.StoredProcedure);
            return post;

        }

        public bool deletePost(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("deletePost", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<GetPostData> getAllPosts()
        {
            IEnumerable<GetPostData> result = dbContext.Connection.Query<GetPostData>("getAllPosts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool postDownVote(int postId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@post_id", postId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("postDownVote", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool postUpVote(int postId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@post_id", postId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("postUpVote", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updatePost(Post post)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@post_id", post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@post_title", post.title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@post_content", post.content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@author_id", post.authorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("updatePost", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public string UploadImagePost(string image, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@picture", image, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Post> result = dbContext.Connection.Query<Post>("uploadPostImage", parameters, commandType: CommandType.StoredProcedure);
            return result.ToString(); 
        }

    }
}
