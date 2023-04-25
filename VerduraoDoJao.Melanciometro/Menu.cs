using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace VerduraoDoJao.Melanciometro
{
	internal  class Menu
	{

        public Dictionary<string, Delegate> Opcoes = new Dictionary<string, Delegate>() ;
        public string Caption,Titulo;
        public ConsoleColor? CorDoTexto,CorDaSelecao, CorDoFundo;
        public static Dictionary<string, Menu> Menus = new Dictionary<string, Menu>();
		
		
		public Menu() { }
		public Menu(string nome)
		{
			Menus.Add(nome,this);
        }
        public Menu(string nome, string Caption)
        {
            this.Caption = Caption;
            Menus.Add(nome, this);
        }

        public Menu(string nome, string caption, string titulo)
        {
            Caption = caption;
            Titulo = titulo;
        }

        public Menu(string[] caption_e_titulo)
        {
            Caption = caption_e_titulo[0];
            Titulo = caption_e_titulo[1];
        }

        public Menu(string[] caption_e_titulo, string[] textosDasOpcoes, object[] funcoes)
        {
            Caption = caption_e_titulo[0];
            Titulo = caption_e_titulo[1];
            PopulaOpcoes(textosDasOpcoes, funcoes);  
        }

        public Menu(string nome, string[] caption_e_titulo, string[] textosDasOpcoes, object[] funcoes)
        {
            Caption = caption_e_titulo[0];
            Titulo = caption_e_titulo[1];
            PopulaOpcoes(textosDasOpcoes, funcoes);
            Menus.Add(nome, this);
        }

        public Menu(ConsoleColor corDoTexto, ConsoleColor corDaSelecao) 
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
        }
        public Menu(string nome, ConsoleColor corDoTexto, ConsoleColor corDaSelecao)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            Menus.Add(nome, this);
        }
        public Menu(string nome, string Caption, ConsoleColor corDoTexto, ConsoleColor corDaSelecao)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            this.Caption = Caption;
            Menus.Add(nome, this);
        }

        public Menu(string nome, string caption, string titulo, ConsoleColor corDoTexto, ConsoleColor corDaSelecao)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            Caption = caption;
            Titulo = titulo;
        }

        public Menu(string[] caption_e_titulo, ConsoleColor corDoTexto, ConsoleColor corDaSelecao)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            Caption = caption_e_titulo[0];
            Titulo = caption_e_titulo[1];
        }

        public Menu(string[] caption_e_titulo, string[] textosDasOpcoes, object[] funcoes, ConsoleColor corDoTexto, ConsoleColor corDaSelecao)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            Caption = caption_e_titulo[0];
            Titulo = caption_e_titulo[1];
            PopulaOpcoes(textosDasOpcoes, funcoes);
        }

        public Menu(string nome, string[] caption_e_titulo, string[] textosDasOpcoes, object[] funcoes, ConsoleColor corDoTexto, ConsoleColor corDaSelecao)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            Caption = caption_e_titulo[0];
            Titulo = caption_e_titulo[1];
            PopulaOpcoes(textosDasOpcoes, funcoes);
            Menus.Add(nome, this);
        }

        public Menu(ConsoleColor corDoTexto, ConsoleColor corDaSelecao, ConsoleColor corDeFundo)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            CorDoFundo = corDeFundo;
        }
        public Menu(string nome, ConsoleColor corDoTexto, ConsoleColor corDaSelecao, ConsoleColor corDeFundo)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            CorDoFundo = corDeFundo;
            Menus.Add(nome, this);
        }
        public Menu(string nome, string Caption, ConsoleColor corDoTexto, ConsoleColor corDaSelecao, ConsoleColor corDeFundo)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            CorDoFundo = corDeFundo;
            this.Caption = Caption;
            Menus.Add(nome, this);
        }

        public Menu(string nome, string caption, string titulo, ConsoleColor corDoTexto, ConsoleColor corDaSelecao, ConsoleColor corDeFundo)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            CorDoFundo = corDeFundo;
            Caption = caption;
            Titulo = titulo;
        }

        public Menu(string[] caption_e_titulo, ConsoleColor corDoTexto, ConsoleColor corDaSelecao, ConsoleColor corDeFundo)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            CorDoFundo = corDeFundo;
            Caption = caption_e_titulo[0];
            Titulo = caption_e_titulo[1];
        }

        public Menu(string[] caption_e_titulo, string[] textosDasOpcoes, object[] funcoes, ConsoleColor corDoTexto, ConsoleColor corDaSelecao, ConsoleColor corDeFundo)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            CorDoFundo = corDeFundo;
            Caption = caption_e_titulo[0];
            Titulo = caption_e_titulo[1];
            PopulaOpcoes(textosDasOpcoes, funcoes);
        }

        public Menu(string nome, string[] caption_e_titulo, string[] textosDasOpcoes, object[] funcoes, ConsoleColor corDoTexto, ConsoleColor corDaSelecao, ConsoleColor corDeFundo)
        {
            CorDaSelecao = corDaSelecao;
            CorDoTexto = corDoTexto;
            CorDoFundo = corDeFundo;
            Caption = caption_e_titulo[0];
            Titulo = caption_e_titulo[1];
            PopulaOpcoes(textosDasOpcoes, funcoes);
            Menus.Add(nome, this);
        }


        private void PopulaOpcoes(string[] textosDasOpcoes, object[] funcoes)
        {
            for (var i = 0; i <= textosDasOpcoes.Length; i++)
            {
                Opcoes.Add(textosDasOpcoes[0], (Action)funcoes[0]);
            }
        }
        public static void CriaMenuPrincipal()
		{
            new Menu("Principal");   
			Menus["Principal"].Opcoes.Add("Registrar Caminhão", new Action(Program.RegistraCaminhao) );
            Menus["Principal"].Opcoes.Add("Deletar Caminhão", new Action(Program.DeletaCaminhao));
            Menus["Principal"].Opcoes.Add("Procurar Caminhão pela Placa", new Action(Program.ProcuraCaminhao));
            Menus["Principal"].Opcoes.Add("Procurar Caminhão pelo CPF/CNPJ do proprietário", new Action(Program.ProcuraId));
            Menus["Principal"].Opcoes.Add("Registrar Produto", new Action(Program.RegistraProduto));
            Menus["Principal"].Opcoes.Add("Deletar Produto", new Action(Program.DeletaProduto));
            Menus["Principal"].Opcoes.Add("Sair", new Action(Program.Sair));
        }
        public static void CriaMenuSemana()
        {
            string[] diaDaSemana = {"Segunda-Feira", "Terça-Feira" ,
                                    "Quarta-Feira" , "Quinta-Feira", 
                                    "Sexta-Feira"  , "Sabádo", "Domingo" };
            new Menu("Semana");
            for(var i =0; i <= diaDaSemana.Count()-1; i++ )
            {
                var dia = i + 1;
                Menus["Semana"].Opcoes.Add(diaDaSemana[i], new Func<int>( () =>Program.Semana(dia)));
            }
            Menus["Semana"].Caption = "Selecione o dia da semana";
        }
		public object ShowEnumerable()
		{
			
			string saida ="";
			int numOp = 1;
			foreach (var opcao in Opcoes)
			{

				saida += $"{numOp}-{opcao.Key}\n";
				numOp++;
			}

            var catchErro = true;
			do
			{
                Console.Clear();
                Console.WriteLine(saida);
                try
                {
                    var Opcao = int.Parse(Console.ReadLine());
                    var OpcaoList = Opcoes.Keys.ToList();
                    var Acao = Opcoes[OpcaoList[Opcao - 1]];
                    catchErro = false; //Não deu nenhum erro
                    return Acao.DynamicInvoke();
                }
                catch (FormatException)
                {
                    MensagemDeErro();
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    MensagemDeErro();
                    continue;
                }
            } while (catchErro);
            return null;
		}
        public object ShowSelectable()
        {
            Console.CursorVisible = false; //desliga a visibilidade do cursor
            int numOp = 1;
            ConsoleKeyInfo tecla;
            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                if(Titulo != null)
                {
                    Console.WriteLine(Titulo);
                }
                
                var OpcaoList = Opcoes.Keys.ToList();
                //Escreve as opções
                foreach (var opcao in Opcoes)
                {
                    var IndexOpcao = OpcaoList.IndexOf(opcao.Key) +1;
                    if (numOp == IndexOpcao) //Se tiver selecionada
                    {
                        if(CorDaSelecao == null) //Se não tiver sido atribuida nenhuma cor
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else //Se tiver sido atribuida alguma cor coloca a cor
                        {
                            Console.BackgroundColor = CorDaSelecao.Value;
                            Console.ForegroundColor = CorDoTexto.Value;
                        }
                        
                    }
                    else //Se não tiver selecionada
                    {
                        if(CorDaSelecao == null) //Se não tiver sido atribuida nenhuma cor
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = CorDoTexto.Value;
                        }

                    }
                    Console.WriteLine(opcao.Key);
                }
                if (Caption != null)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Caption);
                }
                tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (numOp == 1)
                        {
                            numOp = Opcoes.Count;
                        }
                        else
                        {
                            numOp--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (numOp == Opcoes.Count)
                        {
                            numOp = 1;
                        }
                        else
                        {
                            numOp++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        var Acao = Opcoes[OpcaoList[numOp - 1]];
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorVisible = true;
                        return  Acao.DynamicInvoke();
                }
            } while(tecla.Key != ConsoleKey.Enter);
            return null;
        }
        public void MensagemDeErro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("COMANDO INVÁLIDO");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Digite uma opção entre 1 e {Opcoes.Count}\n" +
                              $"Aperte ENTER para digitar uma nova opção");
            Console.ReadLine();
        }
	}
}

