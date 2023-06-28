using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortLinkGenerator.Database.Models
{
    [Table("Urls")]
    public class ShortUrl : BaseEntity
    {
        [Column(TypeName = "nvarchar(256)"), Required]
        public string Url { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(8)"),Required]
        public string ShortUrlCode { get; set; } = string.Empty;
    }
}
