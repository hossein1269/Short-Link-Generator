using System.ComponentModel.DataAnnotations;

namespace ShortLinkGenerator.Database.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
