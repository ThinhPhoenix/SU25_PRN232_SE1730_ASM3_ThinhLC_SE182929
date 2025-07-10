using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Repository.ThinhLC.ModelExtensions
{
    public class SearchRequest
    {
        public int? CurrentPage { get; set; } = 1;
        public int? PageSize { get; set;} = 10;
    }
    public class SearchSampleThinhLCRequest : SearchRequest
    {
        public int sampleId { get; set; }
        public string? notes { get; set; }
        public string? typeName { get; set; }
    }
}
