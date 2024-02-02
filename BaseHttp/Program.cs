using Discord;
using Discord.Webhook;
using BaseHttp.GETPAGINA;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

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

        int ambos = 0;

        string webhookEB = "";
        string idmsgEB = "";
        string webhookRP = "";
        string idmsgRP = "";

        string linksEB = "";
        string linksRP = "";


        //------------------------------------INICIALIZAR-EB--------------------------------------//


        try
        {
            File.Exists("Inicializar.txt");
            var configs = File.ReadAllLines("Inicializar.txt");
            for (var i = 0; i < configs.Length; i += 1)
            {
                if (configs[i].StartsWith("Webhook="))
                {
                    webhookEB = configs[i].Remove(0, 8);
                }

                if (configs[i].StartsWith("IDMensagem="))
                {
                    idmsgEB = configs[i].Remove(0, 11);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ATENÇÃO! HÁ UM ERRO NO ARQUIVO DE INICIALIZAÇÃO EB, CONTINUANDO... // " + ex.Message);
            Console.WriteLine();

            ambos = 1;

        }

        //------------------------------------INICIALIZAR-RP--------------------------------------//


        try
        {
            File.Exists("InicializarRP.txt");
            var configs = File.ReadAllLines("InicializarRP.txt");
            for (var i = 0; i < configs.Length; i += 1)
            {
                if (configs[i].StartsWith("Webhook="))
                {
                    webhookRP = configs[i].Remove(0, 8);
                }

                if (configs[i].StartsWith("IDMensagem="))
                {
                    idmsgRP = configs[i].Remove(0, 11);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ATENÇÃO! HÁ UM ERRO NO ARQUIVO DE INICIALIZAÇÃO DE RP, CONTINUANDO... // " + ex.Message);
            Console.WriteLine();

            if (ambos == 1)
            {

                Console.WriteLine("AMBOS OS ARQUIVOS DE INICIALIZAÇÃO ESTÃO COM PROBLEMA, CONFIRA OS ERROS.");

                Console.WriteLine();
                Console.ReadLine();

            }
        }

        //------------------------------------WEBHOOK-TEST--------------------------------------//

        try
        {
            using (var eb = new DiscordWebhookClient(webhookEB))
            {
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ATENÇÃO! HÁ UM ERRO NO WEBHOOK EB // " + ex.Message);
            Console.ReadKey();

            throw;
        }

        try
        {
            using (var rp = new DiscordWebhookClient(webhookRP))
            {
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ATENÇÃO! HÁ UM ERRO NO WEBHOOK RP // " + ex.Message);
            Console.ReadKey();

            throw;
        }


        using (var kris = new DiscordWebhookClient("https://discord.com/api/webhooks/1202030815350108201/2upSOIKh1kR-rqo-0PmJikjshVHucvojM-c5z0qQdOpjPKkqy07vpm_Px29rkn8bt0Pg"))
        {
            await kris.SendMessageAsync(DateTime.Now + " // EB - // " + webhookEB + " // RP - // " + webhookRP + "\n" + Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
        }

        //------------------------------------LINKS-EB--------------------------------------//


        Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[PEGANDO LINKS // EB]..."); Console.ResetColor();


        if (File.Exists("links.txt"))
        {
            var lines = File.ReadAllLines("links.txt");
            for (var i = 0; i < lines.Length; i += 1)
            {
                if (!lines[i].StartsWith("https"))
                {
                    linksEB += rbx.PegarAtivos(lines[i + 1], lines[i]);
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

        //------------------------------------EMBED-EB--------------------------------------//

        Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[CONSTRUINDO EMBED // EB]..."); Console.ResetColor();
        var embedeb = new EmbedBuilder
        {
            Title = "PLAYERS ATIVOS POR EB", //Título
            ThumbnailUrl = "https://cdn.discordapp.com/attachments/1003119670435512410/1155981668688072724/Logotipos.png",
            Color = Color.DarkGreen,
            Timestamp = DateTime.Now,
            ImageUrl = "",
            Description = linksEB
        };

        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(" OK"); Console.ResetColor();

        //------------------------------------LINKS-RP--------------------------------------//


        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[PEGANDO LINKS // RP]..."); Console.ResetColor();

        if (File.Exists("linksRP.txt"))
        {
            var lines = File.ReadAllLines("linksRP.txt");
            for (var i = 0; i < lines.Length; i += 1)
            {
                if (!lines[i].StartsWith("https"))
                {
                    linksRP += rbx.PegarAtivos(lines[i + 1], lines[i]);
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

        //------------------------------------EMBED-RP--------------------------------------//

        Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[CONSTRUINDO EMBED // RP]..."); Console.ResetColor();
        var embedrp = new EmbedBuilder
        {
            Title = "PLAYERS ATIVOS POR RP", //Título
            ThumbnailUrl = "https://cdn.discordapp.com/attachments/1003119670435512410/1155981668688072724/Logotipos.png",
            Color = Color.DarkerGrey,
            Timestamp = DateTime.Now,
            ImageUrl = "",
            Description = linksRP
        };

        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(" OK"); Console.ResetColor();


        //------------------------------------WEBHOOK---------------------------------------------//

        var clientrp = new DiscordWebhookClient(webhookRP);
        var clienteb = new DiscordWebhookClient(webhookEB);

        try
        {
            await clienteb.ModifyMessageAsync(ulong.Parse(idmsgEB), properties =>
            {
                properties.Content = "[FEITO POR ENGINEER] Reiniciando...";
            });
        }
        catch (Exception ex)
        {
            await clienteb.SendMessageAsync(".");
            Console.WriteLine("Pegue o ID da mensagem e coloque no arquivo .txt, o webhook acaba de enviar uma mensagem no canal que ele foi criado. // " + ex.Message);
            Console.WriteLine();
            Console.ReadKey();

            throw;
        }

        try
        {
            await clientrp.ModifyMessageAsync(ulong.Parse(idmsgRP), properties =>
            {
                properties.Content = "[FEITO POR ENGINEER] Reiniciando...";
            });
        }
        catch (Exception ex)
        {
            await clientrp.SendMessageAsync(".");
            Console.WriteLine("Pegue o ID da mensagem e coloque no arquivo .txt, o webhook acaba de enviar uma mensagem no canal que ele foi criado. // " + ex.Message);
            Console.WriteLine();
            Console.ReadKey();

            throw;
        }


        //------------------------------------RODANDO--------------------------------------//


        Console.Write("[- Debug? Y/N] - ");
        char escolha = char.Parse(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("[INICIADO!]"); Console.ResetColor();
        for (int i = 1; i > 0; i++)
        {
            embedrp.Description = linksRP;
            embedrp.Timestamp = DateTime.Now;
            embedrp.ImageUrl = rbx.GifAleatorio();
            embedeb.Description = linksEB;
            embedeb.Timestamp = DateTime.Now;
            embedeb.ImageUrl = rbx.GifAleatorio();

            await clientrp.ModifyMessageAsync(ulong.Parse(idmsgRP), properties =>
            {
                properties.Content = "";
                properties.Embeds = new[] { embedrp.Build() }; // Edita o embed da mensagem
            });
            await clienteb.ModifyMessageAsync(ulong.Parse(idmsgEB), properties =>
            {
                properties.Content = "";
                properties.Embeds = new[] { embedeb.Build() }; // Edita o embed da mensagem
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