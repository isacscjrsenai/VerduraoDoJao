using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VerduraoDoJao.Melanciometro
{
    internal class Program
    {
        static void Main()
        {
            Splash.Show();
            Login.Logar();
            Menu.CriaMenuPrincipal();
            Menu.CriaMenuSemana();
            new Produto("Melância Normal", 5.50, 2.5,"Kg");
            new Produto("Melância Baby", 8.56, 4.5, "Kg");

            while (true)
            {
                Menu.Menus["Principal"].ShowSelectable();           
            }
        }
        
        internal static void RegistraCaminhao()
        {
            
            Console.Clear();
            string placa = new Campo("Escreva a placa do caminhão", "Placa","Placa").Show();
            string id;
            if (Caminhao.caminhoes.ContainsKey(placa))
            {
                id = Caminhao.caminhoes[placa].Proprietario;
            }
            else
            {
                id = new Campo("Escreva o CPF ou CNPJ do Proprietário", "Id", "Id").Show();
                new Caminhao(placa, id);
            }
            int diaDaSemana = (int)Menu.Menus["Semana"].ShowSelectable();
      
            Menu MenuVenda = ConstroiMenuVenda(placa, diaDaSemana);
            bool vendaFechada = false;
            do
            {  
            var Result = MenuVenda.ShowSelectable();
            if (Result != null)
                {
                    vendaFechada = (bool)Result;
                }
            } while (vendaFechada != true);
        }
        internal static void DeletaCaminhao()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do Caminhão para Deletar");
            var placaADeletar = Console.ReadLine();
            if (Caminhao.caminhoes.ContainsKey(placaADeletar))
            {
               Caminhao.caminhoes.Remove(placaADeletar);
               Console.WriteLine("CAMINHÃO DELETADO");
               Console.ReadLine();
            }
            else 
            {
                Console.WriteLine($"Não existe o caminhão com a placa {placaADeletar} na base de dados");
                Console.ReadLine();
            }
            
        }
        internal static void ProcuraCaminhao()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do caminhão");
            var placaAProcurar = Console.ReadLine();
            if (Caminhao.caminhoes.ContainsKey(placaAProcurar))
            {
                ImprimiCaminhao(placaAProcurar);
            }
            else
            {
                Console.WriteLine($"Não existe o caminhão com a placa {placaAProcurar} na base de dados");
            }
            Console.ReadLine();
        }
        internal static void ProcuraId()
        {
            Console.Clear();
            Console.WriteLine("Digite o CPF/CNPJ");
            var id = Console.ReadLine();
            Console.WriteLine($"CAMINHÕES REGISTRADOS SOBRE O CPF/CNPJ:{id}");
            foreach (var caminhao in Caminhao.caminhoes)
            {
                if(caminhao.Value.Proprietario == id)
                {
                    ImprimiCaminhao(caminhao.Value.Placa);
                }
            }
            Console.ReadLine ();
        }
        internal static void RegistraProduto()
        {
            Console.Clear();
            Console.WriteLine("ADICIONAR UM PRODUTO");
            Console.WriteLine("Digite o nome do produto:");
            var nomeProduto = Console.ReadLine();
            nomeProduto = nomeProduto.Trim();
            var JaTaRegistrado = Produto.produtos.Any(x => x.Nome == nomeProduto);
            if (JaTaRegistrado)
            {
                Console.WriteLine("O produto já existe");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            double precoProduto =0, custoProduto = 0;
            string unidade;
            do
            {
                if (custoProduto != 0 && precoProduto != 0 && custoProduto >= precoProduto)
                {
                    Console.WriteLine("O preço não é maior que o custo");
                }
                precoProduto = double.Parse(new Campo("Digite o preço do produto","Quantidade").Show());
                Console.WriteLine("Digite o custo do produto:");
                custoProduto = double.Parse(new Campo("Digite o custo do produto", "Quantidade").Show());
                Console.WriteLine("Digite a unidade de medida (Kg, Unidade, Peça, Bandeja, Caixa)");
                unidade = Console.ReadLine();
            } while (custoProduto >= precoProduto);        
            new Produto(nomeProduto,precoProduto,custoProduto,unidade);
            Console.WriteLine("PRODUTO ADICIONADO");
            Console.ReadLine();
            Console.Clear();           
        }
        internal static void DeletaProduto()
        {
            Console.Clear();
            Console.WriteLine("DELETAR UM PRODUTO");
            Console.WriteLine("Digite o nome do produto:");
            var produtoADeletar = Console.ReadLine();
            bool removido = false;
            foreach (var produto in Produto.produtos)
            {
                if (produto.Nome == produtoADeletar)
                {
                    Produto.produtos.Remove(produto);
                    removido = true;
                    break;
                }
            }
            if (removido)
            {
                Console.WriteLine("PRODUTO DELETADO");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Não existe registro de produto com o nome:{produtoADeletar}");
                Console.ReadLine();
            }
        }
        internal static void Sair()
        {
            Console.Clear();
            Console.WriteLine("Você tem certeza que deseja sair? 'S' para sim ou qualquer outra tecla para não");
            var opcaoSair = Console.ReadLine();
            if (opcaoSair == "S")
            {
                Environment.Exit(0);
            }
        }
        static void ImprimiCaminhao(string placaAProcurar)
        {
            var id = Caminhao.caminhoes[placaAProcurar].Proprietario;
            Console.WriteLine($"CAMINHÃO {placaAProcurar}");
            Console.WriteLine($"PROPRIETÁRIO CPF/CNPJ: {id}");
            Console.WriteLine("VENDAS");
            var idDasVendas = Caminhao.caminhoes[placaAProcurar].Cargas.Keys.ToList();
            if (idDasVendas.Count == 0)
            {
                Console.WriteLine("SEM VENDAS REGISTRADAS");
            }
            foreach (var venda in idDasVendas)
            {
                Console.WriteLine($"VENDA {venda}");
                var carga = Caminhao.caminhoes[placaAProcurar].Cargas[venda].Produtos;
                double valorCarga = 0;
                foreach (var produto in carga)
                {
                    Console.WriteLine($"{produto.Key} - {produto.Value.QuantVendida} kg - R$ {produto.Value.ValorVendido} - {produto.Value.DescPromocao} ");
                    valorCarga += produto.Value.ValorVendido;
                }
                Console.WriteLine($"TOTAL DA VENDA {venda}: R${valorCarga}");
            }
            Console.WriteLine();
            
        }
        
        internal static int Semana(int dia)
        {
            return dia;
        } 

        internal static bool FechaVenda(string placa) 
        {
            int ultimaCarga = Caminhao.caminhoes[placa].Cargas.Count-1;
            if (ultimaCarga ==-1) //não comprou nada ainda
            {
                Console.WriteLine("Tem certeza que o cliente não quer levar nada? S(Sim) ou N(não)");
                var resposta = Console.ReadLine().ToString().Trim().ToUpper();
                if (resposta.Equals("S")) return true;
                else return false;
            }
            Caminhao.caminhoes[placa].Cargas[ultimaCarga].fechada = true;
            ImprimiCaminhao(placa);
            Console.ReadLine();
            return true;
        }

        internal static void RegistraVenda(string placa ,Produto produto, int diaDaSemana)
        {
            double quantProduto;
            if (!produto.Unidade.Equals("Kg"))
            {
                quantProduto = int.Parse(new Campo($"Digite a quantidade de {produto.Unidade} de {produto.Nome}", "Quantidade Inteira").Show());
            }
            else
            {
                quantProduto = double.Parse(new Campo($"Digite a quantidade de {produto.Unidade} de {produto.Nome}", "Quantidade").Show());
            }
            int idDaVenda = GetIdDaVenda(placa);
            Caminhao.caminhoes[placa].AdicionaCarga(produto, diaDaSemana, quantProduto, idDaVenda);
        }
        internal static Menu ConstroiMenuVenda(string placa, int diaDaSemana)
        {
            Menu MenuVenda = new Menu();
            MenuVenda.Caption = "Selecione o produto para adicionar";
            foreach (var produto in Produto.produtos)
            {
                var nome = produto.Nome;
                var promocao = Promocao.AplicaPromocao(produto, diaDaSemana);
                double preco = double.Parse(promocao[0]);
                var descricaoPromocao = promocao[1];
                MenuVenda.Opcoes.Add($"{nome} - R$ {preco} - {descricaoPromocao}", new Action( () => RegistraVenda(placa,produto, diaDaSemana)));
            }
            MenuVenda.Opcoes.Add("Fecha Venda", new Func<bool>( () => FechaVenda(placa) ));
            return MenuVenda;
        }
        internal static int GetIdDaVenda(string placa)
        {
            int idDaVenda;
            //se ainda não existe nenhuma carga cria a carga
            if(Caminhao.caminhoes[placa].Cargas.Count == 0)
            {
                return Caminhao.caminhoes[placa].CriaCarga();
            }

            int ultimaCarga = Caminhao.caminhoes[placa].Cargas.Count -1;

            if (Caminhao.caminhoes[placa].Cargas[ultimaCarga].fechada)
            {
                idDaVenda = Caminhao.caminhoes[placa].CriaCarga();
            }
            else
            {
                idDaVenda = ultimaCarga;
            }
            return idDaVenda;
        }
    }   
    

}
