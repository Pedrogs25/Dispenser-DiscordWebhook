using System.Net;
using System.Threading;
using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using BaseHttp.GETPAGINA;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Reactive;
using static System.Net.WebRequestMethods;

class Program
{
    static void Main(string[] args)
    => new Program().MainAsync().GetAwaiter().GetResult();

    public async Task MainAsync()
    {

        Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("[INICIANDO]..."); Console.ResetColor();

        //ID DO WEBHOOK, LEMBRA DO ""
        using (var client = new DiscordWebhookClient("https://discord.com/api/webhooks/1155556405504380939/KEy8isC4kYcd_-xpAswFXve2cKfv21_X1mDf1NQgU8PxDvdrVZf1UBk15yQlDlmKlcti"))
        {
            //await client.SendMessageAsync("e"); //PRA QUANDO PERDER A MSG, TIRE AS BARRINHAS DO COMEÇO PARA ENVIAR OUTRA E PEGAR O ID DELA


            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[PEGANDO LINKS]..."); Console.ResetColor();
            //ADICIONE OS JOGOS COM O LINK
            string Jogo1 = "https://www.roblox.com/games/4874005928/Ex-rcito-Brasileiro-EB#!";
            string Jogo2 = "https://www.roblox.com/games/13132367906/EB-MAPA-NOVO-Ex-rcito-Brasileiro";
            string Jogo3 = "https://www.roblox.com/games/2069320852/Ex-rcito-Brasileiro-EB";
            string Jogo4 = "https://www.roblox.com/games/12512279965/MEGA-UPDATE-EB-Ex-rcito-Brasileiro";
            string Jogo5 = "https://www.roblox.com/games/6274206008/Ex-rcito-Brasileiro-EB";
            string Jogo6 = "https://www.roblox.com/games/13282270169/EB-2-Ex-rcito-Brasileiro-2";
            string Jogo7 = "https://www.roblox.com/games/12556807747/Eb-Ex-rcito-Brasileiro-Mega-Update";
            string Jogo8 = "https://www.roblox.com/games/12151996711/V2-EB-Ex-rcito-Brasileiro";
            string Jogo9 = "https://www.roblox.com/games/6735836427/V3-EB-Ex-rcito-Brasileiro";
            string Jogo10 = "https://www.roblox.com/games/14217740449/V1-EB-Ex-rcito-Brasileiro";
            string Jogo11 = "https://www.roblox.com/games/12152043299/V1-EB-Ex-rcito-Brasileiro";
            string Jogo12 = "https://www.roblox.com/games/12902059525/E-B-Ex-rcito-Brasileiro";
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(" OK"); Console.ResetColor();

            Rbx rbx = new Rbx(); //Chama a classe

            //COPIE E COLE O SEGUINTE MODELO MODIFICANDO O QUE FOR NECESSÁRIO NA PARTE DO DESCRIPTION
            /*
            "\n### (NOME JOGO) \n" + rbx.PegarAtivos(STRING Q VC COLOCOU OU O LINK DIRETO) +
             */

            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[CONSTRUINDO EMBED]..."); Console.ResetColor();
            var embed = new EmbedBuilder
            {
                Title = "PLAYERS ATIVOS POR EB", //Título
                ThumbnailUrl = "https://cdn.discordapp.com/attachments/1003119670435512410/1155981668688072724/Logotipos.png", //Link da imagem
                Color = Color.Red,
                Timestamp = DateTime.Now,
                Description =
                "### • Exército Brasileiro Flithy \n" + rbx.PegarAtivos(Jogo1) +
                "\n### • Exército Brasileiro Tevez \n" + rbx.PegarAtivos(Jogo2) +
                "\n### • Exército Brasileiro Apex_Hard \n" + rbx.PegarAtivos(Jogo3) +
                "\n### • Exército Brasileiro Victoryloop \n" + rbx.PegarAtivos(Jogo4) +
                "\n### • Exército Brasileiro Vegeta \n" + rbx.PegarAtivos(Jogo5) +
                "\n### • Exército Brasileiro Erikguest \n" + rbx.PegarAtivos(Jogo6) +
                "\n### • Exército Brasileiro KauezindoEB \n" + rbx.PegarAtivos(Jogo7) +
                "\n### • Exército Brasileiro xxGamer \n" + rbx.PegarAtivos(Jogo12) +
                "\n### • Exército Brasileiro Fonojonzo - V2 \n" + rbx.PegarAtivos(Jogo8) +
                "\n### • Exército Brasileiro Fonojonzo - V3 \n" + rbx.PegarAtivos(Jogo9) +
                "\n### • Exército Brasileiro Fonojonzo - V1 \n" + rbx.PegarAtivos(Jogo10) +
                "\n### • Exército Brasileiro Fonojonzo - V1 segundo \n" + rbx.PegarAtivos(Jogo11)
            };
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(" OK"); Console.ResetColor();



            Console.Write("Debug? Y/N - ");
            char escolha = char.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("[INICIADO!]"); Console.ResetColor();
            for (int i = 1; i > 0; i++)
            {
                //COPIE E COLE O QUE VOCÊ COLOCOU NO EMBED BUILDER (MENOS A PARTE DO TITLE)

                embed.Description =
                "### • Exército Brasileiro Flithy \n" + rbx.PegarAtivos(Jogo1) +
                "\n### • Exército Brasileiro Tevez \n" + rbx.PegarAtivos(Jogo2) +
                "\n### • Exército Brasileiro Apex_Hard \n" + rbx.PegarAtivos(Jogo3) +
                "\n### • Exército Brasileiro Victoryloop \n" + rbx.PegarAtivos(Jogo4) +
                "\n### • Exército Brasileiro Vegeta \n" + rbx.PegarAtivos(Jogo5) +
                "\n### • Exército Brasileiro Erikguest \n" + rbx.PegarAtivos(Jogo6) +
                "\n### • Exército Brasileiro KauezindoEB \n" + rbx.PegarAtivos(Jogo7) +
                "\n### • Exército Brasileiro xxGamer \n" + rbx.PegarAtivos(Jogo12) +
                "\n### • Exército Brasileiro Fonojonzo - V2 \n" + rbx.PegarAtivos(Jogo8) +
                "\n### • Exército Brasileiro Fonojonzo - V3 \n" + rbx.PegarAtivos(Jogo9) +
                "\n### • Exército Brasileiro Fonojonzo - V1 \n" + rbx.PegarAtivos(Jogo10) +
                "\n### • Exército Brasileiro Fonojonzo - V1 segundo \n" + rbx.PegarAtivos(Jogo11);
                embed.Timestamp = DateTime.Now;


                //NOS NÚMEROS ABAIXO COLOQUE O ID DE UMA MENSAGEM FEITA PELO WEBHOOK -- AVISO -- SE APAGAR A MSG CAPAZ DE DAR PAU

                await client.ModifyMessageAsync(1155991750519820408, properties =>
                {
                    properties.Content = "";
                    properties.Embeds = new[] { embed.Build() }; // Edita o embed da mensagem
                });

                Thread.Sleep(5000);
                if (escolha == 'Y' || escolha == 'y')
                {
                    Console.WriteLine("Atualizado - " + DateAndTime.TimeString);
                }
                else
                {
                }
            }
        }
    }
}









































/*
class Program
{
    static void Main(string[] args)
    => new Program().MainAsync().GetAwaiter().GetResult();


    public async Task MainAsync()
    {
        using (var client = new DiscordWebhookClient("https://discord.com/api/webhooks/1151231840032665600/g8bspn2qbOkHIK8nUz99d4C3_Gjl_paqU1zGkHdBvcRuOKh1nZMrhTyAhGe0VkBnjqMn"))
        {
            //ADICIONE OS JOGOS COM O LINK
            string Jogo1 = "https://www.roblox.com/games/12334109280/Guts-Blackpowder-MOBILE-VC-Servers";
            string Jogo2 = "https://www.roblox.com/games/14437001043/Residence-Massacre";
            string Jogo3 = "https://www.roblox.com/games/4766797229/ABERTO-Mini-City-RP-Paran";

            Rbx rbx = new Rbx();

            //COPIE E COLE O SEGUINTE MODELO MODIFICANDO O QUE FOR NECESSÁRIO NA PARTE DO DESCRIPTION
            /*
            "\n### (NOME JOGO) \n" + rbx.PegarAtivos(STRING Q VC COLOCOU OU O LINK DIRETO) +

            var embed = new EmbedBuilder
            {
                Title = "DISPENSER, POWERED BY ENGINEER GAMING",
                Description =
                "### Guts \n" + rbx.PegarAtivos(Jogo1) +
                "\n### Residence \n" + rbx.PegarAtivos(Jogo2) +
                "\n### Mini city\n" + rbx.PegarAtivos(Jogo3)
            };

            for (int i = 1; i > 0; i++)
            {
                //COPIE E COLE O QUE VOCÊ COLOCOU NO EMBED BUILDER (MENOS A PARTE DO TITLE)

                embed.Description =
                "### Guts \n" + rbx.PegarAtivos(Jogo1) +
                "\n### Residence \n" + rbx.PegarAtivos(Jogo2) +
                "\n### Mini city\n" + rbx.PegarAtivos(Jogo3);

                await client.ModifyMessageAsync(1155976560277475370, properties =>
                {
                    properties.Embeds = new[] { embed.Build() }; // Edita o embed da mensagem
                });

                Thread.Sleep(1000);

                await client.SendMessageAsync(text: "foi");
            }
        }
    }
}
*/



/*
string Jogo1 = "https://www.roblox.com/games/12334109280/Guts-Blackpowder-MOBILE-VC-Servers";
string Jogo2 = "https://www.roblox.com/games/14437001043/Residence-Massacre";
string Jogo3 = "https://www.roblox.com/games/4766797229/ABERTO-Mini-City-RP-Paran";



for (int i = 1; i > 0; i++)
{
    Rbx rbx = new Rbx();
    rbx.PegarAtivos(Jogo1);
    rbx.PegarAtivos(Jogo2);
    rbx.PegarAtivos(Jogo3);
    Thread.Sleep(3000);
}
*/




































/*
var jogo2 = WebRequest.CreateHttp("https://www.roblox.com/games/12334109280/Guts-Blackpowder-MOBILE-VC-Servers");
jogo2.Method = "GET";

using (var resposta = jogo2.GetResponse())
{
    var streamDados = resposta.GetResponseStream();
    StreamReader reader = new StreamReader(streamDados);
    object objResponse = reader.ReadToEnd();


    static string entre(string strSource, string strStart, string strEnd)
    {
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            int Start, End;
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }

        return "";
    }

    string database = entre(objResponse.ToString(), "<p class=\"text-label text-overflow font-caption-header\">Active</p>\r\n                                        <p class=\"text-lead font-caption-body wait-for-i18n-format-render \">", "</p>");
    Console.WriteLine(database);
}

var jogo1 = WebRequest.CreateHttp("https://www.roblox.com/games/14437001043/Residence-Massacre");
jogo1.Method = "GET";

using (var resposta = jogo1.GetResponse())
{
    var streamDados = resposta.GetResponseStream();
    StreamReader reader = new StreamReader(streamDados);
    object objResponse = reader.ReadToEnd();


    static string entre(string strSource, string strStart, string strEnd)
    {
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            int Start, End;
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }

        return "";
    }

    string database = entre(objResponse.ToString(), "<p class=\"text-label text-overflow font-caption-header\">Active</p>\r\n                                        <p class=\"text-lead font-caption-body wait-for-i18n-format-render \">", "</p>");
    Console.WriteLine(database);
}
*/