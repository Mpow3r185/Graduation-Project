using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using Bau.Seedit.Core.ServiceInterface;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Infra.Service
{
    public class PostActionService : IPostActionService
    {
        private readonly IPostActionRepository postActionRepository;

        public PostActionService(IPostActionRepository _postActionRepository)
        {
            postActionRepository = _postActionRepository;
        }
        public bool createPostAction(PostAction postAction)
        {
            return postActionRepository.createPostAction(postAction);
        }

        public bool deletePostAction(int id)
        {
            return postActionRepository.deletePostAction(id);
        }

        public List<PostAction> getAllPostActions()
        {
            return postActionRepository.getAllPostActions();
        }
        public List<PostActionDTO> getPostActionsByPostId(int id)
        {
            return postActionRepository.getPostActionsByPostId(id);
        }
    }
}
