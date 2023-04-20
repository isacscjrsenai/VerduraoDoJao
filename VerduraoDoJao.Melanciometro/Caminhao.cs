using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerduraoDoJao.Melanciometro
{
    internal class Caminhao
    {
        private string placa;
        public string Placa { set; get; }
        private string proprietario;
        public string Proprietario { set; get;}

        private Dictionary<int, Carga> cargas;
        public Dictionary<int, Carga> Cargas;


        public Caminhao(string placa, string proprietario)
        {
            this.Placa = placa;
            this.Proprietario = proprietario;
        }

        public void CriaCarga()
        {
            int idDaVenda = this.Cargas.Count;
            this.Cargas.Add(idDaVenda, new Carga(idDaVenda));
        }

        public void AdicionaCarga(Produto Produto, int diaDaSemana, double quantProduto, int idDaVenda)
        {
            string nomeProduto = Produto.Nome;
            this.Cargas[idDaVenda].Produtos.Add(nomeProduto, new ProdutoVendido(Produto, quantProduto, diaDaSemana));
        }
        public void ModificaCarga(Produto Produto, int diaDaSemana, double novaQuantProduto, int idDaVenda)
        {
            string nomeProduto = Produto.Nome;
            this.Cargas[idDaVenda].Produtos[nomeProduto] = new ProdutoVendido(Produto, novaQuantProduto, diaDaSemana);
        }

    }
}
