using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Media;
using System.Threading;
using System.IO;

namespace VerduraoDoJao.Melanciometro
{
    public static class Splash
    {
        public static void Show()
        {
            string e = "";
            Console.ReadLine();
            Buzina();
            for (int i = 0; i < 50; i++)
            {
                e += " ";
                string caminhao =
    $@"
{e}    O O O O O O O O O O O O O O
{e}   O O O O O O O O O O O O O O O
{e} _O_O_O_O_O_O_O_O_O_O_O_O_O_O_O_O__
{e}|__   ____   ____   ____   ___   __|_______
{e}|__| |____| |____| |____| |___| |__|  ____ \
{e}|__   ____   ____   ____   ___   __| |    \ \
{e}|__| |____| |____| |____| |___| |__| |_____\ \________
{e}|__   ____   ____   ____   ___   __| |     |   \______\ /
{e}|__| |____| |____| |____| |___| |__| |     |          O|--
{e}|        ___       ___             | |     |  ___     ||\
{e}|_______/   \_____/   \____________| |_____| /   \____||
{e}|______/  0  \___/  0  \____________________/  0  \____>
{e}        \___/     \___/                      \___/";

                Console.Clear();
                Console.WriteLine(caminhao);
                Thread.Sleep(50);
                //Console.ReadLine();
            }
        }
        static void Buzina()
        {
            var buzina = Path.Combine(Environment.CurrentDirectory, "buzina.wav");
            SoundPlayer player = new SoundPlayer(buzina);
            player.Play();
          
        }
    }



}
