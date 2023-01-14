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
    public class PostRepository : IPostRepository
    {
        private readonly IDbContext dbContext;

        public PostRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool createPost(Post post)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@post_title", post.title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@post_content", post.content, dbType: DbType.String, direction: ParameterDirection.Input);
           // parameters.Add("@post_published", post.published, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@author_id", post.authorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@published_at", post.publishedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("createPost", parameters, commandType: CommandType.StoredProcedure);
            return true;

        }

        public bool deletePost(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("deletePost", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Post> getAllPosts()
        {
            IEnumerable<Post> result = dbContext.Connection.Query<Post>("getAllPosts", commandType: CommandType.StoredProcedure);
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
            parameters.Add("@post_published", post.published, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@author_id", post.authorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@published_at", post.publishedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
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
        public bool updatePostPublishedAt(int id, DateTime publishedAt)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@published_At", publishedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Post> result = dbContext.Connection.Query<Post>("updatePostPublishedAt", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

    }
}
