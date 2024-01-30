using System.Net;
using System.Web;

namespace BaseHttp.GETPAGINA
{
    public class Rbx
    {

        public string PegarAtivos(string jogos)
        {
            var site = WebRequest.CreateHttp(jogos);
            site.Method = "GET";

            try
            {
                using (var resposta = site.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();


                    static string entre(string strSource, string strStart, string strEnd)
                    {
                        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
                        {
                            int Start;
                            int End;
                            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                            End = strSource.IndexOf(strEnd, Start);
                            return strSource.Substring(Start, End - Start);
                        }

                        return "";
                    }

                    string nome = entre(objResponse.ToString(), "<title>", "- Roblox</title>");
                    string database = entre(objResponse.ToString(), "<p class=\"text-label text-overflow font-caption-header\">Active</p>\r\n                                        <p class=\"text-lead font-caption-body wait-for-i18n-format-render \">", "</p>");

                    nome = HttpUtility.HtmlDecode(nome);

                    return "\n### • " + nome + "\n" + "Players ativos: " + database;
                }
            }
            catch (WebException e)
            {
                Console.WriteLine();

                var resp = (HttpWebResponse) e.Response;
                Console.WriteLine("ATENÇÃO! HÁ UM ERRO NO JOGO: {" + jogos + "}. Código de erro: " + resp.StatusCode);
                return "Error, call engineer.";
            }
        }

        public string GifAleatorio()
        {
            Random rnd = new Random();
            int aleatorio = rnd.Next(100);

            if (aleatorio == 0)
            {
                return "https://i1.sndcdn.com/artworks-k1UFwwzHPwZ4RSnE-ZWxOWw-t500x500.jpg";
            }
            else { return "https://wiki.teamfortress.com/w/images/thumb/d/d8/Engineer.png/375px-Engineer.png"; }//"https://cdn.discordapp.com/attachments/1001630451116548096/1201698398516809818/image0.jpg?ex=65cac3d8&is=65b84ed8&hm=773afe34678be26d2ab4756dfe53614406dd73e5aa027f3a3b62a7317d36a9a9&"; }

        }
    }
}
