using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerduraoDoJao.Melanciometro
{

    internal class Produto
    {
        public static List<Produto> produtos = new List<Produto>();
        
        public string Nome { set; get; }
        public double Preco { set; get; }
        public double Custo { set; get; }
        public string Unidade { set; get; } 
        public Produto(string nome, double preco, double custo, string unidade)
        {
            Nome = nome;
            Preco = preco;
            Custo = custo;
            Unidade = unidade;
            produtos.Add(this);
        }
    }
}
