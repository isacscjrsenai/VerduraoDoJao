using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerduraoDoJao.Melanciometro
{
    internal class Caminhao
    {
        public static Dictionary<object, Caminhao> caminhoes = new Dictionary<object, Caminhao>();
        public string Placa { set; get; }
        public string Proprietario { set; get;}

        public Dictionary<int, Carga> Cargas { set; get; }


        public Caminhao(string placa, string proprietario)
        {
            Placa = placa;
            Proprietario = proprietario;
            Cargas = new Dictionary<int, Carga>();
            caminhoes.Add(placa,this);
        }

        public int CriaCarga()
        {
            int idDaVenda = this.Cargas.Count;
            this.Cargas.Add(idDaVenda, new Carga(idDaVenda));
            return idDaVenda;
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
