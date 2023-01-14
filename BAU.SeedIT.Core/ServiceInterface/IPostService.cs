using Bau.Seedit.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.ServiceInterface
{
    public interface IPostService
    {
        bool createPost(Post post);
        List<Post> getAllPosts();
        bool updatePost(Post post);
        bool deletePost(int id);
        bool postUpVote(int postId);
        bool postDownVote(int postId);
        string UploadImagePost(string image, int id);
        bool updatePostPublishedAt(int id, DateTime publishedAt);

    }
}
