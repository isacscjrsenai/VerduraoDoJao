using System;

namespace VerduraoDoJao.Melanciometro
{
    public class Login
    {
        static readonly string usuario = "João";
        static readonly string senha = "123";
        static string usuarioLogin, senhaLogin;
        static int tentativasLogin = 0;

        static public void Logar()
        {

            do
            {
                Console.Clear();
                var Height = Console.WindowHeight;
                var Width = Console.WindowWidth;
                int MiddleHeigt = (Height/2);
                int MiddleWidth = (Width/2);
                string e = "";
                string c = "";
                //metade da tela menos a metade do tamanho dos campos
                for(var i = 0; i <= MiddleWidth-13; i++)
                {
                    e += " ";
                }
                for (var i = 0;i <= MiddleWidth/2; i++) 
                { 
                    c += " "; 
                }
                string usuario = $@"
{e} ----------USUÁRIO----------
{e}|                           |
{e} --------------------------- ";
                string senha = $@"
{e} -----------SENHA-----------
{e}|                           |
{e} --------------------------- ";
                string logo = $@"
{c}                                  /\/
{c}                    |   ____    ______    ____
{c}                    |  /    \  |      |  /    \
{c}                    | |      | |      | |      |
{c}             |      | |      | |______| |      |
{c}             |______|  \____/  |      |  \____/
{c}                                               /\/
{c}  _____  ______                               ____    ____  ____
{c} /      |      | |\      /| | |\   | |    |  /    \  |     |
{c}/       |      | | \    / | | | \  | |____| |      | |____ |____   
{c}\       |------| |  \  /  | | |  \ | |    | |      | |          |
{c} \_____ |      | |   \/   | | |   \| |    |  \____/  |____ _____|";

string verdurao = $@"                
{c}                      __ __        __   ~
{c}                \  / | - |/ |\ | | |/  /_\  /\
{c}                 \/  |__ |\ |/ |_| |\ /   \ \/ ";


                int numLinhasNoLogo = logo.Split('\n').Length + verdurao.Split('\n').Length;
                int numLinhasNosCampo = (usuario.Split('\n').Length);
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(verdurao);
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine(logo);
                Console.WriteLine(usuario);
                Console.WriteLine(senha);
                Console.SetCursorPosition(MiddleWidth-11, (numLinhasNoLogo+numLinhasNosCampo)-2);
                usuarioLogin = Console.ReadLine();
                Console.SetCursorPosition(MiddleWidth-11, (numLinhasNoLogo + numLinhasNosCampo*2) - 2);
                senhaLogin = Console.ReadLine();
                //Console.WriteLine("Digite o usuário");
                //usuarioLogin = Console.ReadLine();
                //Console.WriteLine("Digite a senha");
                //senhaLogin = Console.ReadLine();
                tentativasLogin++;

            } while (tentativasLogin < 3 && (!usuarioLogin.Equals(usuario) || !senhaLogin.Equals(senha)));


            //Não conseguiu logar
            if (tentativasLogin == 3)
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Title = "NÃO É O JOÃO CAMINHÕES-SAMA";
                Console.WriteLine("ARA ARA CAMINHÕES");
                Console.WriteLine("Tentativas de Login Excedidas");
                Console.ReadLine();
                Environment.Exit(0);
            }

        }
    }
}

