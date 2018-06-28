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
    }
}
