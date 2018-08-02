namespace Teference.Zoho.Api.Internals
{
    public static class ZsPageExtensions
    {
        public static string AppendTo(this ZsPage page, string baseUri)
        {
            return page.AppendTo(new QueryStringBuilder(baseUri)).ToString();
        }

        public static  QueryStringBuilder AppendTo(this ZsPage page, QueryStringBuilder query)
        {
            if (page != null)
            {
                if (page.PageNumber > 0)
                {
                    query.Add("page", page.PageNumber.ToString());
                }

                if (page.RecordsPerPage > 0)
                {
                    query.Add("per_page", page.RecordsPerPage.ToString());
                }
            }

            return query;
        }

        public static ZsPage NextPage(this ZsPageContext pageContext)
        {
            return new ZsPage
            {
                PageNumber = pageContext.PageNumber + 1,
                RecordsPerPage = pageContext.RecordsPerPage
            };
        }
    }
}
