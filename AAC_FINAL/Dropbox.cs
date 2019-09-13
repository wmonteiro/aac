using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AAC_FINAL
{
    class Dropbox
    {

        // Auth2 Dropbox 
        private const string AUTH_KEY = "";

        /// <summary>
        /// Deleta uma pasta no dropbox
        /// </summary>
        /// <param name="path">Diretório no dropbox onde a pasta que será deletada se encontra.</param>
        /// <returns></returns>
        public void Delete_Folder(string path)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.dropboxapi.com/2/files/delete_v2");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization: Bearer " + AUTH_KEY);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(new
                {
                    path = path
                }));
            }

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }

            string JSON;

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                JSON = streamReader.ReadToEnd();
            }

        }

        /// <summary>
        /// Cria uma pasta no dropbox
        /// </summary>
        /// <param name="path">Diretório no dropbox onde a pasta será criada.</param>
        /// <returns></returns>
        public void Create_Folder(string path)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.dropboxapi.com/2/files/create_folder_v2");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization: Bearer " + AUTH_KEY);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(new
                {
                    path = path
                }));
            }

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }

        }

        /// <summary>
        /// Verifica se existe uma pasta no dropbox
        /// </summary>
        /// <param name="path">Diretório onde a pasta está localizada.</param>
        /// /// <param name="foldername">Nome da pasta.</param>
        /// <returns></returns>
        public bool Folder_Exists(string path, string foldername)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.dropboxapi.com/2/files/list_folder");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization: Bearer " + AUTH_KEY);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(new
                {
                    path = path,
                    recursive = false,
                    include_deleted = false,
                    include_has_explicit_shared_members = false,
                    include_mounted_folders = true,
                    include_non_downloadable_files = true
                }));
            }

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }

            string JsonStr;

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                JsonStr = streamReader.ReadToEnd();
            }

            bool found = false;

            if (response.StatusCode.ToString() == "OK")
            {
                JObject json = JObject.Parse(JsonStr);
                JArray items = (JArray)json["entries"];
                foreach (var obj in items)
                {
                    string tag = obj[".tag"].ToString();
                    string name = obj["name"].ToString();
                    if (tag == "folder" && name == foldername)
                    {
                        found = true;
                    }
                }

            }

            return found;

        }

        /// <summary>
        /// Verifica se existe um arquivo no dropbox
        /// </summary>
        /// <param name="path">Diretório onde o arquivo está localizado.</param>
        /// /// <param name="foldername">Nome do arquivo.</param>
        /// <returns></returns>
        public bool File_Exists(string path, string filename)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.dropboxapi.com/2/files/list_folder");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization: Bearer " + AUTH_KEY);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(new
                {
                    path = path,
                    recursive = false,
                    include_deleted = false,
                    include_has_explicit_shared_members = false,
                    include_mounted_folders = true,
                    include_non_downloadable_files = true
                }));
            }

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }

            string JsonStr;

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                JsonStr = streamReader.ReadToEnd();
            }

            bool found = false;

            if (response.StatusCode.ToString() == "OK")
            {
                JObject json = JObject.Parse(JsonStr);
                JArray items = (JArray)json["entries"];
                foreach (var obj in items)
                {
                    string tag = obj[".tag"].ToString();
                    string name = obj["name"].ToString();
                    if (tag == "file" && name == filename)
                    {
                        found = true;
                    }
                }

            }

            return found;

        }

        /// <summary>
        /// Envia arquivos para o dropbox
        /// </summary>
        /// <param name="path">Diretório onde a pasta está localizada.</param>
        /// /// <param name="filename">Nome do arquivo.</param>
        /// <returns></returns>
        public void Upload_File(string path_dropbox, string path_local)
        {
            Stream requestStream = null;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://content.dropboxapi.com/2/files/upload");
            httpWebRequest.ContentType = "application/octet-stream";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization: Bearer " + AUTH_KEY);
            httpWebRequest.Headers.Add("Dropbox-API-Arg:" + JsonConvert.SerializeObject(new
            {
                path = path_dropbox,
                mode = "add",
                autorename = true,
                mute = false,
                strict_conflict = false
            }));

            byte[] file = GetFileByteArray(path_local);

            requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(file, 0, file.Length);

            requestStream.Close();

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }

        }

        /// <summary>
        /// Obtém um array byte[] do arquivo
        /// </summary>
        /// <param name="path">Diretório onde o arquivo está localizado.</param>
        /// /// <param name="path">Diretorio do arquivo.</param>
        /// <returns>Array byte[]</returns>
        private byte[] GetFileByteArray(string path)
        {
            FileStream oFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] FileByteArrayData = new byte[oFileStream.Length];
            oFileStream.Read(FileByteArrayData, 0, System.Convert.ToInt32(oFileStream.Length));
            oFileStream.Close();
            return FileByteArrayData;
        }
    }
}
