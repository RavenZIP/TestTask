using Microsoft.EntityFrameworkCore;

namespace ServerContactForm.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ContactData> ContactData => Set<ContactData>();
        public DbSet<MessagesData> MessagesData => Set<MessagesData>();
        public DbSet<ThemesMessagesData> ThemeMessagesData => Set<ThemesMessagesData>();
    }
}
