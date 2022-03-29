using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Common.Helpers
{
    public static partial class Enum
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Status
        {
           IsActive =1,
           IsDeleted = 2

        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Subject
        {
            Feedback = 1,
            Complaint = 2,
            Suggestion = 3
        }


      
    }
}
