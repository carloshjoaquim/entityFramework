using Domain;
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
        public  ProductDbContext() : base("Name=ProductDb")
        {
            // Cria a base de dados (ProductDb) caso não exista. Os parâmetros de configuração da base estão no app.config.
            Database.SetInitializer<ProductDbContext>(
                new CreateDatabaseIfNotExists<ProductDbContext>());
            Database.Initialize(false); // Valor falso para o inicializador ser executado apenas caso não tenha sido executado dentro do DbContext.

            // Usado apenas para análise das Querys geradas pelo EF.
            Database.Log = d => System.Diagnostics.Debug.WriteLine(d);
        }

        public DbSet<Produto> Produtos {get;set;}
        public DbSet<Loja> Lojas { get; set; }

    }
}
