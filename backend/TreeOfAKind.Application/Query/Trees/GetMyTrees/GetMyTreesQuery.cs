﻿using TreeOfAKind.Application.Configuration.Queries;

namespace TreeOfAKind.Application.Query.Trees.GetMyTrees
{
    public class GetMyTreesQuery : IQuery<TreeListDto>
    {
        public string UserAuthId { get; }

        public GetMyTreesQuery(string userAuthId)
        {
            UserAuthId = userAuthId;
        }
    }
}