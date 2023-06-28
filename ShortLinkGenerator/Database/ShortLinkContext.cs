using Microsoft.EntityFrameworkCore;
using ShortLinkGenerator.Database.Models;

namespace ShortLinkGenerator.Database
{
    public class ShortLinkContext : DbContext
    {
        public DbSet<ShortUrl> Urls { get; set; }

        public ShortLinkContext(DbContextOptions<ShortLinkContext> options) : base(options)
        {

        }
    }
}
