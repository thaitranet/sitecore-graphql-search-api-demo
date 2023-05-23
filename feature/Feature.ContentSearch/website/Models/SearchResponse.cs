using System.Collections.Generic;

namespace Feature.ContentSearch.Models
{
    public class SearchResponse
    {
        public string keyword { get; set; }

        public Search search { get; set; }

        public class Search
        {
            public List<Facet> facets { get; set; }
            public Results results { get; set; }

            public class Facet
            {
                public string name { get; set; }
                public List<FacetValue> values { get; set; }

                public class FacetValue
                {
                    public string value { get; set; }
                    public int count { get; set; }
                }
            }

            public class Results
            {
                public List<Item> items { get; set; }
                public int totalCount { get; set; }
                public PageInfo pageInfo { get; set; }

                public class Item
                {
                    public string id { get; set; }
                    public string name { get; set; }
                    public string path { get; set; }
                    public string templateName { get; set; }
                    public string language { get; set; }
                    public int version { get; set; }
                    public double score { get; set; }
                }

                public class PageInfo
                {
                    public string endCursor { get; set; }
                    public bool hasNextPage { get; set; }
                    public bool hasPreviousPage { get; set; }
                    public string startCursor { get; set; }
                }
            }
        }
    }
}
