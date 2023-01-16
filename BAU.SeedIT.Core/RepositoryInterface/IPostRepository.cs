using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.RepositoryInterface
{
    public interface IPostRepository
    {
        Post createPost(Post post);
        List<GetAllPosts> getAllPosts();
        bool updatePost(Post post);
        bool deletePost(int id);
        bool postUpVote(int postId);
        bool postDownVote(int postId);
        string UploadImagePost(string image, int id);
        bool updatePostPublishedAt(int id, DateTime publishedAt);
    }
}
