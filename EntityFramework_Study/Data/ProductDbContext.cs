using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductDbContext : DbContext
    {
        protected ProductDbContext() : base("Name=ProductDb")
        {
            // Cria a base de dados (ProductDb) caso não exista. Os parâmetros de configuração da base estão no app.config.
            Database.SetInitializer<ProductDbContext>(
                new CreateDatabaseIfNotExists<ProductDbContext>());
        }
    }
}
