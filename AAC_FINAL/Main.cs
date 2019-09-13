using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace AAC_FINAL
{
    public partial class Main : Form
    {

        static string roaming_folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string settings_folder = roaming_folder + @"\AAC";
        static string settings_file = roaming_folder + @"\AAC\settings.xml";
        string steam_path_reg = @"HKEY_CURRENT_USER\Software\Valve\Steam";

        private static Mutex mutex = null;

        Dropbox DB = new Dropbox();
        Settings ST = new Settings();
        Internet IN = new Internet();
        Helper HP = new Helper();
        CaptureScreen CS = new CaptureScreen();

        DateTime last_auth_key;

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Eventos
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = ST._APP_TITLE + ST._APP_VERSION;
            notifyIcon1.Text = ST._APP_TITLE + ST._APP_VERSION;

            Check_Duplicated_App();

            if (!Check_Connection())
            {
                Message("Você precisa estar conectado à internet para iniciar o AAC, feche o outro programa.", String.Empty, "ok", "info");
                Exit_Application(1);
            }

            Check_App_Version();

            ST._USER_NAME = HP.Get_Registry_Value(steam_path_reg, "LastGameNameUsed");

            Check_If_User_Is_Banned();
            Make_User_Online();
            Check_Settings();

            ST._STEAM_PATH = Load_Settings("SteamPath");
            ST._L4D2_PATH = Load_Settings("L4D2Path");

            if (!Check_Installation_Folder(ST._STEAM_PATH, "steam"))
            {
                Message("Selecione o diretório principal do Steam.", "", "ok", "info");
                Folder_Browser_Dialog("ST");
            }
            if (!Check_Installation_Folder(ST._L4D2_PATH, "left4dead2"))
            {
                Message("Selecione o diretório principal do L4D2.", "", "ok", "info");
                Folder_Browser_Dialog("LP");
            }

            ST._STEAM_PATH = Load_Settings("SteamPath");
            ST._L4D2_PATH = Load_Settings("L4D2Path");
            ST._CFG_FULL_PATH = ST._L4D2_PATH + @"\left4dead2\cfg\" + ST._CONFIG_FILE_NAME;

            Remove_Key();
            Start_Main_Timers();
            Make_User_Offline();
            Check_IPs();
            Check_L4D2_OnStartup();
        }

        private void Main_Closing(object sender, FormClosingEventArgs e) {
            Exit_Application(1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Show_Notification();
        }

        private void Sv2_connect_Click(object sender, EventArgs e)
        {
            HP.Process_Start("steam://connect/35.199.83.57:27015");
        }
        private void Sv1_connect_Click(object sender, EventArgs e)
        {
            HP.Process_Start("steam://connect/177.73.24.225:27015");
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide_Notification();
        }

        private void FecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Notification();
            Exit_Application(1);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Hide_Notification();
        }

        private void Update_servers_Click(object sender, EventArgs e)
        {
            Check_IPs();
        }

        void Message(string text, string title, string btn, string type, Action<bool> callback = null)
        {
            title = ST._APP_TITLE + ST._APP_VERSION;

            MessageBoxIcon _type;
            switch (type)
            {
                case "info":
                    _type = MessageBoxIcon.Information;
                    break;
                case "error":
                    _type = MessageBoxIcon.Error;
                    break;
                case "warning":
                    _type = MessageBoxIcon.Warning;
                    break;
                case "question":
                    _type = MessageBoxIcon.Question;
                    break;
                default:
                    _type = MessageBoxIcon.Information;
                    break;
            }

            MessageBoxButtons _btn;
            switch (btn)
            {
                case "ok":
                    _btn = MessageBoxButtons.OK;
                    break;
                case "yesno":
                    _btn = MessageBoxButtons.YesNo;
                    break;
                default:
                    _btn = MessageBoxButtons.OK;
                    break;
            }

            if (_btn == MessageBoxButtons.YesNo)
            {
                DialogResult dialogResult = MessageBox.Show(text, title, _btn, _type);
                if (dialogResult == DialogResult.Yes)
                {
                    callback(true);
                }
                else if (dialogResult == DialogResult.No)
                {
                    callback(false);
                }

            }
            else
            {
                MessageBox.Show(text, title, _btn, _type);
            }
        }

        [STAThread]
        void Check_Duplicated_App()
        {
            const string appName = "AAC";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                Message("Já existe uma instancia do aplicativo em execução.", "", "ok", "error");
                Exit_Application(1);
            }
        }

        /// <summary>
        /// Funções de checking
        /// </summary>

        void Check_L4D2_OnStartup()
        {
            if(HP.Process_Exists("left4dead2"))
            {
                Message("Você está abrindo o AAC com o L4D2 aberto, digite no console do seu jogo: exec autoexec.cfg", "", "ok", "info");
            }
        }

        void Check_Settings()
        {
            if (!HP.Folder_Exists(settings_folder))
            {
                HP.Create_Folder(settings_folder);
            }
            if (!HP.File_Exists(settings_file))
            {
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode xmlnode = doc.CreateElement("xml");
                doc.AppendChild(xmlnode);

                string steam_path_from_reg = HP.Get_Registry_Value(steam_path_reg, "SteamPath");
                if (String.IsNullOrEmpty(steam_path_from_reg))
                {
                    steam_path_from_reg = @"C:\Program Files (x86)\Steam\";
                }
                XmlNode steampathnode = doc.CreateElement("SteamPath");
                steampathnode.InnerText = steam_path_from_reg;
                xmlnode.AppendChild(steampathnode);

                XmlNode l4d2path = doc.CreateElement("L4D2Path");
                string l4d_path = steam_path_from_reg + @"\steamapps\common\Left 4 Dead 2";

                if (HP.Folder_Exists(l4d_path))
                {
                    l4d2path.InnerText = l4d_path;
                }
                else
                {
                    l4d_path = @"C:\Program Files (x86)\Steam\steamapps\common\Left 4 Dead 2\";
                    l4d2path.InnerText = l4d_path;
                }
                xmlnode.AppendChild(l4d2path);

                XmlNode lastusername = doc.CreateElement("LastUserName");
                string last_username = ST._USER_NAME;
                lastusername.InnerText = last_username;
                xmlnode.AppendChild(lastusername);

                string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                XmlNode lastconnection = doc.CreateElement("LastConnection");
                string last_connection = date;
                lastconnection.InnerText = last_connection;
                xmlnode.AppendChild(lastconnection);

                XmlNode isbanned = doc.CreateElement("IsBanned");
                bool is_banned = DB.Folder_Exists("/BANNED_NAMES/", ST._USER_NAME);
                isbanned.InnerText = (is_banned) ? "1" : "0";
                xmlnode.AppendChild(isbanned);

                doc.Save(settings_file);
            }
        }

        void Check_If_User_Is_Banned()
        {
            bool is_banned = DB.Folder_Exists("/BANNED_NAMES", ST._USER_NAME);
            if (is_banned)
            {
                string exeFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", string.Empty).Replace("/", "\\");
                Message("Você está banido do AAC.", "", "ok", "error");
                Change_Settings("IsBanned", "1");
                Exit_Application(1);
            }
        }

        bool Check_Installation_Folder(string path, string folder_required)
        {
            if (!HP.Folder_Exists(path))
            {
                return false;
            }
            if (HP.Folder_Exists(path + "/" + folder_required))
            {
                return true;
            }
            return false;
        }

        bool Check_Connection()
        {
            return IN.Is_Connected();
        }

        void Check_App_Version()
        {
            string this_version = ST._APP_VERSION;
            string online_version = IN.Download_Text(ST._VERSION_URL);
            if (online_version != this_version)
            {
                string exeFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", string.Empty).Replace("/", "\\");
                Message("Você está usando uma versão desatualizada do AAC. Uma nova versão será baixada.", "", "ok", "info");
                HP.Process_Start("http://rebrand.ly/aacvalidator");
                File.AppendAllText("aac_update.bat", @"@echo off" + "\n" + @"del /F """ + exeFileName + @"""" + "\n" + "del aac_update.bat" + "\n" + "exit");
                Process.Start("aac_update.bat");
                Exit_Application(1);
            }
        }

        void Check_IPs()
        {
            string sv1_ip = "177.73.24.225";
            string sv2_ip = "35.199.83.57";

            if (IN.Ping_Host(sv1_ip))
            {
                sv1_status.Text = "ON";
                sv1_status.ForeColor = Color.Green;
            }
            else
            {
                sv1_status.Text = "OFF";
                sv1_status.ForeColor = Color.Red;
            }
            if (IN.Ping_Host(sv2_ip))
            {
                sv2_status.Text = "ON";
                sv2_status.ForeColor = Color.Green;
            }
            else
            {
                sv2_status.Text = "OFF";
                sv2_status.ForeColor = Color.Red;
            }
        }

        void Remove_Key()
        {
            HP.File_Remove_Line(ST._CFG_FULL_PATH, "sv_tags");
        }

        void Append_Key()
        {
            if (!HP.File_Exists(ST._CFG_FULL_PATH))
            {
                File.Create(ST._CFG_FULL_PATH).Close();
            }
            HP.File_Add_Line(ST._CFG_FULL_PATH, "sv_tags" + " " + Get_Auth_Key());
        }

        string Get_Auth_Key()
        {
            DateTime currentTime = DateTime.UtcNow;
            currentTime = currentTime.AddHours(ST._EXPIRATION_TIME);
            last_auth_key = currentTime;
            string unix_date = Convert_To_Timestamp(currentTime).ToString();
            string B64E = HP.B64Enc(HP.B64Enc(HP.B64Enc(HP.B64Enc(HP.B64Enc(ST._APP_VERSION + unix_date).Replace("==", "").Replace("=", ""))))).Replace("==", "");
            return B64E;
        }

        private static long Convert_To_Timestamp(DateTime target)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(target - sTime).TotalSeconds;
        }

        void Folder_Browser_Dialog(string ID)
        {

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult folderBrowserDialog = folderBrowserDialog1.ShowDialog();

            if (folderBrowserDialog == DialogResult.OK)
            {
                string selectedFolder = folderBrowserDialog1.SelectedPath;

                if (ID == "SP")
                {
                    bool is_valid_steam_folder = Check_Installation_Folder(selectedFolder, "steam");
                    if (is_valid_steam_folder == true)
                    {
                        Change_Settings("SteamPath", selectedFolder);
                    }
                    else
                    {
                        Message("Diretório inválido, tente novamente.", "", "ok", "error");
                        Folder_Browser_Dialog("SP");
                    }
                }
                else
                {
                    bool is_valid_L4D2_folder = Check_Installation_Folder(selectedFolder, "left4dead2");
                    if (is_valid_L4D2_folder == true)
                    {
                        Change_Settings("L4D2Path", selectedFolder);
                    }
                    else
                    {
                        Message("Diretório inválido, tente novamente.", "", "ok", "error");
                        Folder_Browser_Dialog("LP");
                    }
                }
            }
            if (folderBrowserDialog == DialogResult.Cancel)
            {
                Exit_Application(1);
            }
        }

        void Exit_Application(int code)
        {
            Remove_Key();
            Make_User_Offline();
            Environment.Exit(code);
        }

        string Load_Settings(string setting)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(settings_file);
            XmlNode node = doc.DocumentElement.SelectSingleNode(setting);
            return node.InnerText;
        }

        void Change_Settings(string setting, string setting_value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(settings_file);
            XmlNode node = doc.DocumentElement.SelectSingleNode(setting);
            node.InnerText = setting_value;
            doc.Save(settings_file);
        }

        void Make_User_Online()
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            Change_Settings("LastConnection", date);
            if (!DB.Folder_Exists("/ONLINE_USERS", ST._USER_NAME))
            {
                DB.Create_Folder("/ONLINE_USERS/" + ST._USER_NAME);
            }
        }

        void Make_User_Offline()
        {
            if (DB.Folder_Exists("/ONLINE_USERS", ST._USER_NAME))
            {
                DB.Delete_Folder("/ONLINE_USERS/" + ST._USER_NAME);
            }
        }

        /// <summary>
        /// Funções relacionadas ao dropbox
        /// </summary>

        void Root_Folder_Check()
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            if (!DB.Folder_Exists("/PUBLIC_SCREENSHOTS/", date))
            {
                DB.Create_Folder("/PUBLIC_SCREENSHOTS/" + date);
            }
        }

        void Player_Folder_Check()
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            if (!DB.Folder_Exists("/PUBLIC_SCREENSHOTS/" + date, ST._USER_NAME))
            {
                DB.Create_Folder("/PUBLIC_SCREENSHOTS/" + date + "/" + ST._USER_NAME);
            }
        }

        bool Is_Recordable_Player()
        {
            if (DB.Folder_Exists("/RECORD_USERS", ST._USER_NAME))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool Is_Instant_Record()
        {
            if (DB.Folder_Exists("/RECORD_USERS/" + ST._USER_NAME, "IR"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void Start_Main_Timers()
        {
            main_photo_timer.Enabled = false;
            general_checking.Enabled = true;
            general_checking.Start();
        }
        void Stop_Photo_Timers()
        {
            photo_1.Enabled = false;
            photo_1.Stop();
            photo_2.Enabled = false;
            photo_2.Stop();
            photo_3.Enabled = false;
            photo_3.Stop();
        }

        void Start_Main_Photo_Timer()
        {
            if (Is_Instant_Record())
            {
                main_photo_timer.Interval = HP.Get_Random_Range(HP.Get_Random_Range(3215, 4741), HP.Get_Random_Range(4741, 9992));
            }
            else
            {
                main_photo_timer.Interval = HP.Get_Random_Range(HP.Get_Random_Range(375107, 657610), HP.Get_Random_Range(657611, 954701)); ;
            }
            main_photo_timer.Enabled = true;
            main_photo_timer.Start();
        }

        void Stop_Main_Photo_Timer()
        {
            main_photo_timer.Enabled = false;
            main_photo_timer.Stop();
        }

        void Reset_Main_Photos_Timer()
        {
            Stop_Main_Photo_Timer();
            Start_Main_Photo_Timer();
        }

        string Get_Photo_Name()
        {
            string date = DateTime.Now.ToString("dd_MM_yyyy");
            string time = DateTime.Now.ToString("HH_mm_ss_FFF");
            return date + "_" + time + "_" + ST._USER_NAME;
        }

        void Hide_Notification()
        {
            Show();
            notifyIcon1.Visible = false;
        }

        void Show_Notification()
        {
            Hide();
            notifyIcon1.Visible = true;
        }

        /// <summary>
        /// Previne capturas do desktop, verificando se o jogo está minimizado.
        /// </summary>
        /// <returns>{bool}</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(IntPtr hWnd);
        bool Is_Left4dead2_Accessible()
        {
            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (process.MainWindowTitle == "Left 4 Dead 2")
                {
                    IntPtr wHnd = process.MainWindowHandle;
                    return !IsIconic(wHnd);
                }
            }
            return false;
        }

        /// <summary>
        /// Previne capturas do overlay da Steam.
        /// </summary>
        /// <returns>{bool}</returns>
        void Kill_Overlay()
        {
            if(HP.Process_Exists("gameoverlayui"))
            {
                HP.Process_Kill("gameoverlayui");
            }
        }

        bool Key_Appended = false;
        /// <summary>
        /// Timers
        /// </summary>
        private void General_checking_Tick(object sender, EventArgs e)
        {

            if (HP.Process_Length("left4dead2") > 0)
            {
                Start_Main_Photo_Timer();
                l4d2_status.Text = "Executando";
            } else
            {
                Stop_Main_Photo_Timer();
                Stop_Photo_Timers();
            }

            if (HP.Process_Length("steamwebhelper") == 0)
            {
                steam_status.Text = "Não executado";
            }
            else if(HP.Process_Length("steamwebhelper") > 3)
            {
                user_name.Text = ST._USER_NAME;
                aac_status.Text = "Validado";
                steam_status.Text = "Executando";
                revalid_key.Visible = true;
                if (!Key_Appended)
                {
                    validation_timer.Enabled = true;
                    validation_timer.Start();
                    Append_Key();
                    Key_Appended = true;
                }
            } else
            {
                steam_status.Text = "Carregando...";
                l4d2_status.Text = "-";
            }

        }
        private void Validation_timer_Tick(object sender, EventArgs e)
        {
            DateTime curTime = DateTime.UtcNow;
            TimeSpan diff = (last_auth_key - curTime);
            DateTime myDateTime = DateTime.Parse(diff.ToString());
            ExpireTime.Text = myDateTime.ToString("HH:mm:ss");
        }
        private void Main_photo_timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("1");
            if (HP.Process_Exists("left4dead2"))
            {
                MessageBox.Show("2");
                if (Is_Recordable_Player())
                {
                    MessageBox.Show("3");
                    if (Is_Instant_Record())
                    {
                        MessageBox.Show("4");
                        photo_1.Interval = HP.Get_Random_Range(HP.Get_Random_Range(2750, 3830), HP.Get_Random_Range(3831, 6511));
                    }
                    else
                    {
                        MessageBox.Show("5");
                        photo_1.Interval = HP.Get_Random_Range(HP.Get_Random_Range(6718, 7341), HP.Get_Random_Range(7342, 12821));
                    }
                    photo_1.Enabled = true;
                    photo_1.Start();
                    Stop_Main_Photo_Timer();
                } else
                {
                    Reset_Main_Photos_Timer();
                }
            }
        }

        private void Photo_1_Tick_1(object sender, EventArgs e)
        {
            if (Is_Left4dead2_Accessible())
            {
                string date = DateTime.Now.ToString("dd-MM-yyyy");

                photo_1.Enabled = false;
                photo_1.Stop();

                if (HP.File_Exists(settings_folder + "/p1.jpg"))
                {
                    File.Delete(settings_folder + "/p1.jpg");
                }

                Kill_Overlay();
                CS.Capture(settings_folder + "/p1.jpg", ST._USER_NAME);

                Root_Folder_Check();
                Player_Folder_Check();

                if (HP.File_Exists(settings_folder + "/p1.jpg"))
                {
                    DB.Upload_File("/PUBLIC_SCREENSHOTS/" + date + "/" + ST._USER_NAME + "/" + Get_Photo_Name() + ".jpg", settings_folder + "/p1.jpg");
                }

                if (Is_Instant_Record())
                {
                    photo_2.Interval = HP.Get_Random_Range(HP.Get_Random_Range(2750, 3830), HP.Get_Random_Range(3831, 6511));
                }
                else
                {
                    photo_2.Interval = HP.Get_Random_Range(HP.Get_Random_Range(6718, 7341), HP.Get_Random_Range(7342, 12821));
                }

                photo_2.Enabled = true;
                photo_2.Start();
            }
            else
            {
                photo_1.Enabled = false;
                photo_1.Stop();
                if (Is_Instant_Record())
                {
                    photo_2.Interval = HP.Get_Random_Range(HP.Get_Random_Range(2750, 3830), HP.Get_Random_Range(3831, 6511));
                }
                else
                {
                    photo_2.Interval = HP.Get_Random_Range(HP.Get_Random_Range(6718, 7341), HP.Get_Random_Range(7342, 12821));
                }
                photo_2.Enabled = true;
                photo_2.Start();
            }
        }

        private void Photo_2_Tick_1(object sender, EventArgs e)
        {
            if (Is_Left4dead2_Accessible())
            {
                string date = DateTime.Now.ToString("dd-MM-yyyy");

                photo_2.Enabled = false;
                photo_2.Stop();

                if (HP.File_Exists(settings_folder + "/p2.jpg"))
                {
                    File.Delete(settings_folder + "/p2.jpg");
                }

                Kill_Overlay();
                CS.Capture(settings_folder + "/p2.jpg", ST._USER_NAME);

                Root_Folder_Check();
                Player_Folder_Check();

                if (HP.File_Exists(settings_folder + "/p2.jpg"))
                {
                    DB.Upload_File("/PUBLIC_SCREENSHOTS/" + date + "/" + ST._USER_NAME + "/" + Get_Photo_Name() + ".jpg", settings_folder + "/p2.jpg");
                }

                if (Is_Instant_Record())
                {
                    photo_3.Interval = HP.Get_Random_Range(HP.Get_Random_Range(2750, 3830), HP.Get_Random_Range(3831, 6511));
                }
                else
                {
                    photo_3.Interval = HP.Get_Random_Range(HP.Get_Random_Range(6718, 7341), HP.Get_Random_Range(7342, 12821));
                }
                photo_3.Enabled = true;
                photo_3.Start();
            }
            else
            {
                photo_2.Enabled = false;
                photo_2.Stop();
                if (Is_Instant_Record())
                {
                    photo_3.Interval = HP.Get_Random_Range(HP.Get_Random_Range(2750, 3830), HP.Get_Random_Range(3831, 6511));
                }
                else
                {
                    photo_3.Interval = HP.Get_Random_Range(HP.Get_Random_Range(6718, 7341), HP.Get_Random_Range(7342, 12821));
                }
                photo_3.Enabled = true;
                photo_3.Start();
            }
        }

        private void Photo_3_Tick_1(object sender, EventArgs e)
        {
            if (Is_Left4dead2_Accessible())
            {
                string date = DateTime.Now.ToString("dd-MM-yyyy");

                photo_3.Enabled = false;
                photo_3.Stop();

                if (HP.File_Exists(settings_folder + "/p3.jpg"))
                {
                    File.Delete(settings_folder + "/p3.jpg");
                }

                Kill_Overlay();
                CS.Capture(settings_folder + "/p3.jpg", ST._USER_NAME);

                Root_Folder_Check();
                Player_Folder_Check();

                if (HP.File_Exists(settings_folder + "/p3.jpg"))
                {
                    DB.Upload_File("/PUBLIC_SCREENSHOTS/" + date + "/" + ST._USER_NAME + "/" + Get_Photo_Name() + ".jpg", settings_folder + "/p3.jpg");
                }

                if(Is_Instant_Record())
                {
                    DB.Delete_Folder("/RECORD_USERS/" + ST._USER_NAME + "/IR");
                }
                
                Start_Main_Photo_Timer();
            }
            else
            {
                photo_3.Enabled = false;
                photo_3.Stop();
                Start_Main_Photo_Timer();
            }
        }
    }
}