using System.Collections.Generic;

namespace SimpleAuth.Api.Client.Models
{
    public class PagedList
    {
        public PageOptions Options { get; set; }

        public UrlNavigator Navigator { get; set;  }
    }
    public class UrlNavigator
    {
        public int? NavigatorSize { get; set; }

        public PageLink First { get; set; }

        public PageLink Previous { get; set; }

        public PageLink Next { get; set; }

        public PageLink Last { get; set; }

        public List<PageLink> Numerics { get; set; }
    }

    public class PageLink
    {
        public string Url { get; set; }

        public int Number { get; set;  }
    }

    public class PageOptions
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public long ItemCount { get; set; }

        public int PageCount { get; set; }
    }
}
