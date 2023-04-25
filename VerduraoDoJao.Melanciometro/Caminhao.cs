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
            //se o produto já foi adicionado
            if (this.Cargas[idDaVenda].Produtos.ContainsKey(nomeProduto))
            {
                var op = new Campo("Já existe registro desse produto\n Você quer adicionar ou substituir o valor:\n1 - Adicionar\n2- Substituir", "Opções-2").Show();
                Console.WriteLine("Já existe registro desse produto\n Você quer adicionar ou substituir o valor:\n1 - Adicionar\n2- Substituir");
                if (int.Parse(op) == 1)
                {
                    var quantAnterior = this.Cargas[idDaVenda].Produtos[nomeProduto].QuantVendida;
                    ModificaCarga(Produto, diaDaSemana, quantProduto + quantAnterior, idDaVenda);
                }
                else //usuario digitou 2 e quer modificar a quantidade de produto comprado
                {
                    ModificaCarga(Produto, diaDaSemana, quantProduto, idDaVenda);
                }
            }
            else
            {
                this.Cargas[idDaVenda].Produtos.Add(nomeProduto, new ProdutoVendido(Produto, quantProduto, diaDaSemana));
            }
        }
        public void ModificaCarga(Produto Produto, int diaDaSemana, double novaQuantProduto, int idDaVenda)
        {
            string nomeProduto = Produto.Nome;
            this.Cargas[idDaVenda].Produtos[nomeProduto] = new ProdutoVendido(Produto, novaQuantProduto, diaDaSemana);
        }

    }
}
