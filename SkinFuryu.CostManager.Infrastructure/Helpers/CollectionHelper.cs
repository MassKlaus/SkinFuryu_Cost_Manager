using SkinFuryu.CostManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.Infrastructure.Helpers
{
    public static class CollectionHelper
    {
        public static int GetNewId<T>(this IEnumerable<T> collection) where T : IHasId
        {
            return collection.Select(x => x.Id).DefaultIfEmpty().Max() + 1;
        }
    }
}
