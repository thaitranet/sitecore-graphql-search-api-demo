using System.Collections.Generic;

namespace Feature.ContentSearch.Models
{
    public class SearchRequest
    {
        public string language { get; set; }
        public string rootItem { get; set; }
        public List<FieldsEqualValue> fieldsEqual { get; set; } = new List<FieldsEqualValue>();
        public List<string> facetOn { get; set; } = new List<string>();
        public string keyword { get; set; }
        public string after { get; set; }
        public int? first { get; set; }
        public class FieldsEqualValue
        {
            public FieldsEqualValue(string name, string value)
            {
                this.name = name;
                this.value = value;
            }

            public string name { get; set; }
            public string value { get; set; }
        }
    }
}