using Microsoft.EntityFrameworkCore;

namespace NewTask.Models
{
    public class MessageContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public MessageContext(DbContextOptions<MessageContext> options):base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
