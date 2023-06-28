using System.ComponentModel.DataAnnotations;

namespace ShortLinkGenerator.Dtos
{
    public class UrlDto
    {
        [Required]
        public string Url { get; set; }
    }
}
