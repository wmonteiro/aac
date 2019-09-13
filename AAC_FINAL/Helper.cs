using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AAC_FINAL
{
    class Helper
    {

        /// <summary>
        /// Obtém um valor do registro
        /// </summary>
        /// <param name="path">Dir do registry</param>
        /// <param name="key">Chave dentro do registro</param>
        /// <returns>String</returns>
        public string Get_Registry_Value(string path, string key)
        {
            try
            {
                return (string)Registry.GetValue(path, key, null);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Seta um valor ao registro.
        /// </summary>
        /// <param name="path">Dir</param>
        /// <param name="key">Key</param>
        /// <param name="value">Valor</param>
        /// <returns>String</returns>
        public void Set_Registry_Value(string path, string key, string value)
        {
            try
            {
                Registry.SetValue(path, value, key);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Cria uma nova pasta.
        /// </summary>
        /// <param name="path">Diretório.</param>
        /// <returns></returns>
        public void Create_Folder(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch {}
        }

        /// <summary>
        /// Verifica se uma pasta existe.
        /// </summary>
        /// <param name="path">Diretório.</param>
        /// <returns></returns>
        public bool Folder_Exists(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Verifica se um arquivo existe.
        /// </summary>
        /// <param name="path">Diretório existe.</param>
        /// <returns></returns>
        public bool File_Exists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Remove uma linha ao final de um arquivo.
        /// </summary>
        /// <param name="path">Diretório.</param>
        /// <param name="key">Identificação da linha.</param>
        /// <returns></returns>
        public void File_Remove_Line(string path, string key)
        {
            if (!File_Exists(path))
            {
                return;
            }
            string[] Lines = File.ReadAllLines(path);
            File.Delete(path);
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (string line in Lines)
                {
                    if (line.IndexOf(key) >= 0 || line.Trim().Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }

        /// <summary>
        /// Add uma linha ao final de um arquivo.
        /// </summary>
        /// <param name="path">Diretório.</param>
        /// <param name="line_to_add">O que escrever.</param>
        /// <returns></returns>
        public void File_Add_Line(string path, string line_to_add)
        {
            File.AppendAllText(path, "\n" + line_to_add);
        }

        /// <summary>
        /// Inicia um processo.
        /// </summary>
        /// <param name="process_path">Diretório do processo.</param>
        /// <returns></returns>
        public void Process_Start(string process_path)
        {
            Process.Start(process_path);
        }

        /// <summary>
        /// Termina um processo.
        /// </summary>
        /// <param name="process_name">Nome do processo.</param>
        /// <returns></returns>
        public void Process_Kill(string process_name)
        {
            if (Process_Exists(process_name))
            {
                foreach (var process in Process.GetProcessesByName(process_name))
                {
                    process.Kill();
                }
            }
        }

        /// <summary>
        /// Verifica se um processo existe
        /// </summary>
        /// <param name="process">Nome do processo.</param>
        /// <returns>bool</returns>
        public bool Process_Exists(string process)
        {
            return Process.GetProcessesByName(process).Length > 0;
        }

        /// <summary>
        /// Retorna a quantidade de processos em execução
        /// </summary>
        /// <param name="process">Nome do processo.</param>
        /// <returns>int</returns>
        public int Process_Length(string process)
        {
            return Process.GetProcessesByName(process).Length;
        }

        /// <summary>
        /// Encode B64
        /// </summary>
        /// <param name="text">Texto</param>
        /// <returns>bool</returns>
        public string B64Enc(string text)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Obtém um range randomico
        /// </summary>
        /// <param name="from">Minimo</param>
        /// <param name="to">Máximo</param>
        /// <returns>{int}</returns>
        public int Get_Random_Range(int from, int to)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(from, to);
            return ticks;
        }

    }
}
