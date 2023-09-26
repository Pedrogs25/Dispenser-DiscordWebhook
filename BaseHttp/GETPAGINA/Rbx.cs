using System;
using System.Net;

namespace BaseHttp.GETPAGINA
{
    public class Rbx
    {

        public string PegarAtivos(string jogos)
        {
            var site = WebRequest.CreateHttp(jogos);
            site.Method = "GET";

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

                string database = entre(objResponse.ToString(), "<p class=\"text-label text-overflow font-caption-header\">Active</p>\r\n                                        <p class=\"text-lead font-caption-body wait-for-i18n-format-render \">", "</p>");

                return "Players ativos: " + database;
            }
        }
    }
}
