using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private ProductDbContext context;
        public Form1()
        {
            InitializeComponent();
            context = new ProductDbContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loja = new Loja
            {
                Nome = "Primeira Loja",
                Descricao = "Loja Teste",
                CNPJ = "41000/0010"
            };
            context.Lojas.Add(loja);

            var produto = new Produto()
            {
                Nome = "Produto 1 ",
                Descricao = "Produto 1 teste",
                Loja = loja

            };

            context.Produtos.Add(produto);

            context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var loja = context.Lojas.Find(1);

            var produto = new Produto
            {
                Nome = "Novo Produto ",
                LojaId = loja?.Id ?? 0,
                Loja = loja
            };

            context.Produtos.Add(produto);
            context.SaveChanges();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var produto = context.Produtos.Find(2);

            var lojaProduto = produto.Loja;
            var nomeLoja = produto.Loja.Nome;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IEnumerable<Produto> produtosComA =
                context.Produtos.Where(x => x.Nome.StartsWith("A"));

            var nro = produtosComA.Count();
        }
    }
}
