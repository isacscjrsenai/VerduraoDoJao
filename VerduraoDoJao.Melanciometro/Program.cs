using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VerduraoDoJao.Melanciometro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string usuario = "JOÃO", usuarioLogin, senha = "123", senhaLogin;
            int tentativasLogin = 0;
            Dictionary<string, Dictionary<string,string>> caminhoes = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, Dictionary<string, string>> produtos = new Dictionary<string, Dictionary<string, string>>
            {
                { "Melancia Normal", new Dictionary<string, string>()},
                { "Melancia Baby", new Dictionary<string, string>()}
            };
            produtos["Melancia Normal"].Add("preço", "5.5");
            produtos["Melancia Normal"].Add("custo", "2.5");
            produtos["Melancia Baby"].Add("preço", "8.56");
            produtos["Melancia Baby"].Add("custo", "4.5");
            do
            {
                Console.WriteLine("Digite o usuário");
                usuarioLogin = Console.ReadLine();
                Console.WriteLine("Digite a senha");
                senhaLogin = Console.ReadLine();

            } while (tentativasLogin <= 3 && usuarioLogin != usuario && senhaLogin != senha );
            
            
            if (tentativasLogin > 3)
            {
                Console.WriteLine("Tentativas de Login Excedidas");
                Console.ReadLine();
                Environment.Exit(0);
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"1 - Registrar caminhão \n" +
                                  $"2 - Deletar caminhão \n" +
                                  $"3 - Ver registro de caminhão por placa \n" +
                                  $"4 - Ver registro por CPF/CNPJ \n" +
                                  $"5 - Registrar produto \n"+
                                  $"6 - Deletar produto \n" +
                                  $"7 - Sair");
                                
                var option = Console.ReadLine();                    
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Escreva a placa do caminhão");
                        string placa = Console.ReadLine();
                        Console.WriteLine("Escreva o cpf ou cnpj do  Proprietário"); 
                        string id  = Console.ReadLine();
                        int numMenu = 1;
                        foreach (string key in produtos.Keys)
                        {
                            Console.WriteLine($"{numMenu} - {key}");
                            numMenu++;
                        }
                        Console.WriteLine("Digite a opção de produto para adicionar");
                        var opMenu = int.Parse(Console.ReadLine());
                        while (true)
                        {
                            Console.WriteLine($"Digite quantos kg de {produtos.Keys.ToList()[opMenu]}:");

                        }
                        Console.WriteLine("Escreva quantas Kg de melâncias normal?");
                        int numMelancia = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva quantos Kg de melância Baby?");
                        int numMelanciaBaby = int.Parse(Console.ReadLine());
                        if (!caminhoes.ContainsKey(placa))
                        {
                            caminhoes.Add(placa, new Dictionary<string, string>());
                            caminhoes[placa].Add("Melancia Normal", (numMelancia * precoNormal).ToString());
                            caminhoes[placa].Add("Melancia Baby", (numMelanciaBaby * precoBaby).ToString());
                            caminhoes[placa].Add("id", id);
                            Console.WriteLine($"CAMINHÃO PLACA:{placa} \n " +
                                              $"PROPRIETÁRIO CPF/CNPJ:{caminhoes[placa]["id"]}\n" +
                                              $"QUANTIDADE DE MELANCIA NORMAL R$:{caminhoes[placa]["Melancia Normal"]}\n" +
                                              $"QUANTIDADE DE MELANCIA BABY R$:{caminhoes[placa]["Melancia Baby"]}");
                            Console.WriteLine("CAMINHÃO REGISTRADO");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                           Console.WriteLine("Caminhão já registrado de baixa para registrar nova carga");
                           Console.ReadLine();
                           Console.Clear();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Digite a placa do caminhão para deletar");
                        var placaADeletar = Console.ReadLine();
                        if (!caminhoes.ContainsKey(placaADeletar))
                        {
                            Console.WriteLine($"Não existe o caminhão com a placa {placaADeletar} no registro de caminhões");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else 
                        {
                            Console.WriteLine($"Você tem certeza que quer deletar o caminhão de placa {placaADeletar}. S (Sim) ou N(não)");
                            var question = Console.ReadLine();
                            if (question == "S")
                            {
                                caminhoes.Remove(placaADeletar);
                                Console.WriteLine($"Caminhão de placa {placaADeletar} deletado!");
                            }
                           
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Digite a placa do caminhão:");
                        var placaAMostrar = Console.ReadLine();
                        if(!caminhoes.ContainsKey(placaAMostrar))
                        {
                            Console.WriteLine($"Não existe caminhão com a placa {placaAMostrar} no nosso registro");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"CAMINHÃO PLACA:{placaAMostrar} \n " +
                                              $"QUANTIDADE DE MELANCIA NORMAL R$:{caminhoes[placaAMostrar]["Melancia Normal"]} \n" +
                                              $"QUANTIDADE DE MELANCIA BABY R$:{caminhoes[placaAMostrar]["Melancia Baby"]}");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                     case "4":
                            Console.Clear();
                            Console.WriteLine("Digite o CPF/CNPJ");
                            var idAProcurar = Console.ReadLine();
                            Console.WriteLine($"CAMINHÕES COM CARGAS REGISTRADAS NO CPF/CNPJ:{idAProcurar} \n");
                            double cargaNormal = 0 , cargaBaby = 0;
                            foreach(string placaCaminhao  in caminhoes.Keys.ToList())
                            {
                                if (caminhoes[placaCaminhao]["id"] == idAProcurar)
                                {
                                    Console.WriteLine($"CAMINHÃO PLACA:{placaCaminhao}\n" +
                                                      $"CARGA DE MELÂNCIA NORMAL:R${caminhoes[placaCaminhao]["Melancia Normal"]}\n" +
                                                      $"CARGA DE MELÂNCIA BABY:R${caminhoes[placaCaminhao]["Melancia Baby"]}");
                                    Console.WriteLine("\n");
                                    cargaNormal += double.Parse(caminhoes[placaCaminhao]["Melancia Normal"]);
                                    cargaBaby   += double.Parse(caminhoes[placaCaminhao]["Melancia Baby"]);
                                }
                            }
                            Console.WriteLine($"CARGA TOTAL SOBRE O CPF/CNPJ {idAProcurar}");
                            Console.WriteLine($"CARGA DE MELÂNCIA NORMAL:R${cargaNormal} ");
                            Console.WriteLine($"CARGA DE MELÂNCIA BABY:R${cargaBaby}");
                            Console.ReadLine();
                            Console.Clear();

                        break;

                    case "5": 
                        Console.Clear();
                        Console.WriteLine("ADICIONAR UM PRODUTO");
                        Console.WriteLine("Digite o nome do produto:");
                        var nomeProduto = Console.ReadLine();
                        Console.WriteLine("Digite o preço do produto:");
                        var precoProduto = Console.ReadLine();
                        Console.WriteLine("Digite o custo do produto:");
                        var custoProduto = Console.ReadLine();
                        produtos.Add(nomeProduto, new Dictionary<string, string>());
                        produtos[nomeProduto].Add("preço", precoProduto);
                        produtos[nomeProduto].Add("custo", custoProduto);
                        Console.WriteLine("PRODUTO ADICIONADO");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    
                    case "6": 

                        Console.Clear();
                        Console.WriteLine("DELETAR UM PRODUTO");
                        Console.WriteLine("Digite o nome do produto:");
                        var produtoADeletar = Console.ReadLine();
                        if (produtos.ContainsKey(produtoADeletar))
                        {
                            produtos[produtoADeletar].Remove(produtoADeletar);
                            Console.WriteLine("PRODUTO DELETADO");
                        }
                        else 
                        {
                            Console.WriteLine($"Não existe registro de produto com o nome:{produtoADeletar}");
                        }
                        break;

                    case "7":
                            Console.Clear();
                            Console.WriteLine("Você tem certeza que deseja sair? 'S' para sim ou qualquer outra tecla para não");
                            var opcaoSair = Console.ReadLine();
                            if ( opcaoSair == "S")
                            {
                            Environment.Exit(0);
                            }
                            
                        break;

                }
                


            }
        }
    }   
}
