using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{         //essa é a classe responsável por criar o banco de dados
    public class MySqlContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public MySqlContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("ProductApiDataBase");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }
            //aqui estou pedindo para ele criar a tabela da classe products dentro do banco
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Name",
                Price = new decimal(69.9),
                Description = "Description",
                ImageURL = "https://ImageUrl.com/image",
                CategoryName = "T-shirt"

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Namee",
                Price = new decimal(79.9),
                Description = "Descriptionn",
                ImageURL = "https://ImageUrl.com/image",
                CategoryName = "T-shirt"

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Nameee",
                Price = new decimal(89.9),
                Description = "Descriptionnn",
                ImageURL = "https://ImageUrl.com/image",
                CategoryName = "T-shirt"

            });
        }
    }
}
