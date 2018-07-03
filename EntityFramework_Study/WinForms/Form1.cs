using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private readonly ProductDbContext _context;
        public Form1()
        {
            InitializeComponent();
            _context = new ProductDbContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loja = new Loja
            {
                Nome = "Primeira Loja",
                Descricao = "Loja Teste",
                CNPJ = "41000/0010"
            };
            _context.Lojas.Add(loja);

            var produto = new Produto()
            {
                Nome = "Produto 1 ",
                Descricao = "Produto 1 teste",
                Loja = loja

            };

            _context.Produtos.Add(produto);

            _context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var loja = _context.Lojas.Find(1);

            var produto = new Produto
            {
                Nome = "Novo Produto ",
                LojaId = loja?.Id ?? 0,
                Loja = loja
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var produto = _context.Produtos.Find(2) ?? new Produto();

            var lojaProduto = produto.Loja;
            var nomeLoja = produto.Loja.Nome;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IEnumerable<Produto> produtosComA =
                _context.Produtos.Where(x => x.Nome.StartsWith("A"));

            var nro = produtosComA.Count();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var produtoUp = _context.Produtos.Find(100) ?? new Produto();

            produtoUp.Nome = "Novo Nome - Update";
            _context.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Encontra registro para remover.           
            var produtoDelete = _context.Produtos.FirstOrDefault() ?? new Produto();

            // Remove do DbSet Local.
            _context.Produtos.Remove(produtoDelete);

            // Realiza a alteração (delete) na base de dados.
            _context.SaveChanges();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var produto = new Produto
            {
                Id = 3,
                Nome = "Novo Produto - Update State",
                LojaId = 1
            };

            // Adicionando o produto em uma entrada com o estado "modificado".
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
