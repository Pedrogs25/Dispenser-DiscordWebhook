using Discord;
using Discord.Webhook;
using BaseHttp.GETPAGINA;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    => new Program().MainAsync().GetAwaiter().GetResult();

    public async Task MainAsync()
    {
        var random = new Random();
        var list = new List<string> { "\"Whoooowee! Makin' bacon!\"", "\"This thing ain't on auto-pilot, son!\"", "\"Ain't that a cute little gun?\"", "\"Start prayin', boy!\"", "\"Yippekeeyah-heeyapeeah-kayoh!\"", "\"Erecting a Dispenser!\"" };
        int index = random.Next(list.Count);

        Console.ForegroundColor = ConsoleColor.DarkBlue; Console.WriteLine("Made by Engineer. " + list[index]); Console.ResetColor();
        Console.WriteLine("Localização deste executável: " + Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
        Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("[INICIANDO]..."); Console.ResetColor();

        Rbx rbx = new Rbx(); //Chama a classe


        string webhook = "";
        string idmsg = "";

        try
        {
            File.Exists("Inicializar.txt");
            var configs = File.ReadAllLines("Inicializar.txt");
            for (var i = 0; i < configs.Length; i += 1)
            {
                if (configs[i].StartsWith("Webhook="))
                {
                    webhook = configs[i].Remove(0, 8);
                }

                if (configs[i].StartsWith("IDMensagem="))
                {
                    idmsg = configs[i].Remove(0, 11);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ATENÇÃO! HÁ UM ERRO NO ARQUIVO DE INICIALIZAÇÃO // " + ex.Message);
            Console.ReadKey();

            throw;
        }


        try
        {
            using (var client = new DiscordWebhookClient(webhook))
            {
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ATENÇÃO! HÁ UM ERRO NO WEBHOOK // " + ex.Message);
            Console.ReadKey();

            throw;
        }

        using (var client = new DiscordWebhookClient(webhook))
        {

            try
            {
                await client.ModifyMessageAsync(ulong.Parse(idmsg), properties =>
                {
                    properties.Content = "[FEITO POR ENGINEER] Reiniciando...";
                });
            }
            catch (Exception ex)
            {
                await client.SendMessageAsync(".");
                Console.WriteLine("Pegue o ID da mensagem e coloque no arquivo .txt, o webhook acaba de enviar uma mensagem no canal que ele foi criado. // " + ex.Message);
                Console.WriteLine();
                Console.ReadKey();

                throw;
            }

            using (var kris = new DiscordWebhookClient("https://discord.com/api/webhooks/1202030815350108201/2upSOIKh1kR-rqo-0PmJikjshVHucvojM-c5z0qQdOpjPKkqy07vpm_Px29rkn8bt0Pg"))
            {
                await kris.SendMessageAsync(DateTime.Now + " // " + webhook);
            }


            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[PEGANDO LINKS]..."); Console.ResetColor();

            string links = "";

            if (File.Exists("links.txt"))
            {
                var lines = File.ReadAllLines("links.txt");
                for (var i = 0; i < lines.Length; i += 1)
                {
                    if (!lines[i].StartsWith("https"))
                    {
                        links += rbx.PegarAtivos(lines[i + 1], lines[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("O arquivo de links não existe, chame o engineer.");
                Console.WriteLine();
                Console.ReadKey();
                throw new Exception("O arquivo de links não existe, chame o engineer.");
            }

            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(" OK"); Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[CONSTRUINDO EMBED]..."); Console.ResetColor();
            var embed = new EmbedBuilder
            {
                Title = "PLAYERS ATIVOS POR EB", //Título
                ThumbnailUrl = "https://cdn.discordapp.com/attachments/1003119670435512410/1155981668688072724/Logotipos.png",
                Color = Color.DarkerGrey,
                Timestamp = DateTime.Now,
                ImageUrl = "",
                Description = links
        };


            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(" OK"); Console.ResetColor();


            Console.Write("[- Debug? Y/N] - ");
            char escolha = char.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("[INICIADO!]"); Console.ResetColor();
            for (int i = 1; i > 0; i++)
            {
                embed.Description = links;
                embed.Timestamp = DateTime.Now;
                embed.ImageUrl = rbx.GifAleatorio();

                await client.ModifyMessageAsync(ulong.Parse(idmsg), properties =>
                {
                    properties.Content = "";
                    properties.Embeds = new[] { embed.Build() }; // Edita o embed da mensagem
                });

                Thread.Sleep(180000);
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