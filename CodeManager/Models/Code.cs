using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace CodeManager.Models
{
    public class Code
    {
        public Code()
        {
            CreatedDate= DateTime.Now;
        }

        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MinLength(1)]
        public string? Title { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MinLength(1)]
        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
