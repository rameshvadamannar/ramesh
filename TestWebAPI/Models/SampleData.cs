using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebAPI.Models
{
    public class SampleData
    {
       
            public string Id { get; set; }

            public int ApplicationId { get; set; }

            public string Type { get; set; }
           public string Summary { get; set; }

           public double Amount { get; set; }

           public string PostingDate { get; set; }
           public bool IsCleared { get; set; }

           public string ClearedDate { get; set; }

    }
}