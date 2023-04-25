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
    }
}
