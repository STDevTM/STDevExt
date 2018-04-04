using System.Collections.Generic;
using System.Linq;

namespace STDevExt.Extensions
{
    public static class CollectionExtensions
    {
        public static IList<TElement> Inserting<TElement>(this IList<TElement> source, int index, TElement element)
        {
            var newList = source;
            newList.Insert(index, element);
            return newList;
        }

        public static ICollection<TElement> Adding<TElement>(this ICollection<TElement> source, TElement element)
        {
            var newCollection = source;
            newCollection.Add(element);
            return newCollection;
        }

        public static IEnumerable<TElement> WhereNotNull<TElement>(this IEnumerable<TElement> source) where TElement : class
        {
            return source.Where(value => value != null);
        }

    }
}
