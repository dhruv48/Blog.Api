using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blog.Common.Helpers.Enum;

namespace Blog.Common.Models
{
    public class ContactModel:BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailId { get; set; }
        public string Message { get; set; }
        public Subject Subject { get; set; }
        public Status Status { get; set; }
    }
}
