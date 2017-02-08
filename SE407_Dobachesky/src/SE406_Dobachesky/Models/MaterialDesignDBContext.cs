using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SE406_Dobachesky
{
    public class MaterialDesignDBContext : DbContext
    {
        // DB Context properties
        public IConfigurationRoot Configuration { get; set; }
        public DbSet<MaterialDesign> MaterialDesigns { get; set; }

        // DB Context constructor
        public MaterialDesignDBContext()
        {
            var Builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = Builder.Build();
        }

        // DB Context OnConfiguring override for connection string
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
            base.OnConfiguring(OptionsBuilder);
        }
    }
}