using System.Collections.Generic;
using System.Linq;

namespace AwesomeBackend.Shared.Models.Responses
{
    public class ListResult<T>
    {
        public IEnumerable<T> Content { get; }

        public bool HasNextPage { get; }

        public long TotalCount { get; }

        public ListResult(IEnumerable<T> content, bool hasNextPage = false)
        {
            Content = content;
            TotalCount = content?.LongCount() ?? 0;
            HasNextPage = hasNextPage;
        }

        public ListResult(IEnumerable<T> content, long totalCount, bool hasNextPage = false)
        {
            Content = content;
            TotalCount = totalCount;
            HasNextPage = hasNextPage;
        }

        public static ListResult<T> Empty => new ListResult<T>(new List<T>());
    }
}
