using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using Bau.Seedit.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Infra.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository _postRepository)
        {
            postRepository = _postRepository;
        }
        public bool createPost(Post post)
        {
            return postRepository.createPost(post);
        }

        public bool deletePost(int id)
        {
            return postRepository.deletePost(id);
        }

        public List<Post> getAllPosts()
        {
            return postRepository.getAllPosts();
        }

        public bool postDownVote(int postId)
        {
            return postRepository.postDownVote(postId);
        }

        public bool postUpVote(int postId)
        {
            return postRepository.postUpVote(postId);
        }

        public bool updatePost(Post post)
        {
            return postRepository.updatePost(post);
        }
        public string UploadImagePost(string image, int id)
        {
            return postRepository.UploadImagePost(image, id);
        }
        public bool updatePostPublishedAt(int id, DateTime publishedAt)
        {
            return postRepository.updatePostPublishedAt(id, publishedAt);
        }
    }
}
