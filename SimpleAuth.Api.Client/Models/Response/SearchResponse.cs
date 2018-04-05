using System.Collections.Generic;

namespace SimpleAuth.Api.Client.Models.Response
{
    public class SearchResponse<T>
    {
        public List<T> Items { get; set; }

        public PagedList Paging { get; set; }
    }
}
