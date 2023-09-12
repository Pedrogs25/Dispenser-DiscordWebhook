using System.Net;
using System.Threading;
using BaseHttp.GETPAGINA;

string Jogo1 = "https://www.roblox.com/games/12334109280/Guts-Blackpowder-MOBILE-VC-Servers";
string Jogo2 = "https://www.roblox.com/games/14437001043/Residence-Massacre";
string Jogo3 = "https://www.roblox.com/games/4766797229/ABERTO-Mini-City-RP-Paran";



for (int i=1; i > 0; i++)
{
    Rbx rbx = new Rbx();
    rbx.PegarAtivos(Jogo1);
    rbx.PegarAtivos(Jogo2);
    rbx.PegarAtivos(Jogo3);
    Thread.Sleep(3000);
}






































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