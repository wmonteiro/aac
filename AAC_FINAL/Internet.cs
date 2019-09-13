using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace AAC_FINAL
{
    class Internet
    {
        /// <summary>
        /// Baixa um arquivo de texto e retorna o conteúdo.
        /// </summary>
        /// <param name="URI">Endereço web.</param>
        /// <returns>{string} conteúdo.</returns>
        public string Download_Text(string URI)
        {
            try
            {
                var webRequest = WebRequest.Create(URI);
                string strContent;
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())

                using (var reader = new StreamReader(content))
                {
                    strContent = reader.ReadToEnd();
                }

                return strContent;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Baixa um arquivo da internet o salva.
        /// </summary>
        /// <param name="URI">Endereço web.</param>
        /// <param name="path">Local no computador.</param>
        /// <returns></returns>
        public void Download_File(string URI, string path)
        {
            try
            {
                WebClient WC = new WebClient();
                WC.DownloadFile(URI, path);
            }
            catch {}
        }

        /// <summary>
        /// Executa um ping em um IP.
        /// </summary>
        /// <param name="ip_address">Endereço IP.</param>
        /// <returns></returns>
        public bool Ping_Host(string ip_address)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(ip_address, 1000);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {}
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        /// <summary>
        /// Verifica a conexão com a internet.
        /// </summary>
        /// <returns>bool</returns>
        public bool Is_Connected()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
