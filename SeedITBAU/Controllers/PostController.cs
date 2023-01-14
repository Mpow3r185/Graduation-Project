using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.ServiceInterface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bau.Seedit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly IPostActionService postActionService;
        private readonly ICommentService commentService;

        public PostController(IPostService postService, IPostActionService postActionService, ICommentService commentService)
        {
            this.postService = postService;
            this.postActionService = postActionService;
            this.commentService = commentService;

        }

        //Post

        [HttpGet]
        public List<Post> getAllPosts()
        {
            return postService.getAllPosts();
        }
        [HttpPost]
        public bool createPost(Post post)
        {
            return postService.createPost(post);
        }
        [HttpPut]
        public bool updatePost(Post post)
        {
            return postService.updatePost(post);
        }
        [HttpDelete]
        [Route("deletePost/{id}")]
        public bool deletePost(int id)
        {
            return postService.deletePost(id);
        }
        [HttpPut]
        [Route("postUpVote/{id}")]
        public bool PostUpVote(int id)
        {
            return postService.postUpVote(id);
        }
        [HttpPut]
        [Route("postDownVote/{id}")]
        public bool PostDownVote(int id)
        {
            return postService.postDownVote(id);
        }

        [HttpPut]
        [Route("setPublishedAt/{id}")]
        public bool updatePostPublishedAt(int id, DateTime publishedAt)
        {
            return postService.updatePostPublishedAt(id, publishedAt);

        }
        //Post Action

        [HttpGet]
        [Route("getPostActions")]
        public List<PostAction> GetPostActions()
        {
            return postActionService.getAllPostActions();
        }

        [HttpPost]
        [Route("createPostAction")]
        public bool createPostAction(PostAction postAction)
        {
            return postActionService.createPostAction(postAction);
        }
        [HttpDelete]
        [Route("deletePostAction")]
        public bool deletePostAction(int id)
        {
            return postActionService.deletePostAction(id);
        }

        //Comment

        [HttpGet]
        [Route("getComments")]
        public List<Comment> getAllComments()
        {
            return commentService.getAllComments();
        }

        [HttpPost]
        [Route("createComment")]
        public bool createComment(Comment comment)
        {
            return commentService.createComment(comment);
        }

        [HttpPut]
        [Route("updateComment")]
        public bool updateComment(Comment comment)
        {
            return commentService.updateComment(comment);
        }

        [HttpDelete]
        [Route("deleteComment")]
        public bool deleteComment(int id)
        {
            return commentService.deleteComment(id);

        }

        [HttpPost]
        [Route("commentUpVote")]
        public bool CommentUpVote(int id)
        {
            return commentService.CommentUpVote(id);
        }
        [HttpPost]
        [Route("commentDownVote")]
        public bool CommentDownVote(int id)
        {
            return commentService.CommentDownVote(id);
        }

      

        [HttpPost]
        [Route("Upload/{id}")]
        public async Task<string> UploadPostImageAsync(IFormFile image, int id)
        {
            try
            {
                var cloudinary = new Cloudinary(new CloudinaryDotNet.Account(
                        "dotbqgdma",
                      "129178149167614",
                      "MVIwDYZkH6Ra7PX-VIINQDUY50s"
                ));
                var result = await cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                    Transformation = new Transformation().Width(300).Height(167)
                });


                Console.WriteLine(id);
                Console.WriteLine(result.Uri.ToString());
                return postService.UploadImagePost(result.Uri.ToString(), id);

            }


            catch (Exception)
            {
                return null;
            }
        }



    }
}
