using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.RepositoryInterface
{
    public interface IPostActionRepository
    {
        List<PostAction> getAllPostActions();
        bool createPostAction(PostAction postAction);
        bool deletePostAction(int id);
        PostActionDTO getPostActionsByPostId(int id);


    }
}
