using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace AAC_FINAL
{
    class Settings
    {
        private string APP_VERSION = "1.0.0.0";
        private string APP_TITLE = "[AAC] Validator Client By Px v";
        private string STEAM_PATH;
        private string L4D2_PATH;
        private string USER_NAME;
        private string VERSION_URL = @"https://rebrand.ly/aacversion";
        private string CFG_FULL_PATH;
        private string CONFIG_FILE_NAME = "autoexec.cfg";
        private int EXPIRATION_TIME = 24; //horas

        public string _STEAM_PATH
        {
            get
            {
                return STEAM_PATH;
            }
            set
            {
                STEAM_PATH = value;
            }
        }

        public string _L4D2_PATH
        {
            get
            {
                return L4D2_PATH;
            }
            set
            {
                L4D2_PATH = value;
            }
        }

        public string _APP_VERSION
        {
            get
            {
                return APP_VERSION;
            }
        }

        public string _APP_TITLE
        {
            get
            {
                return APP_TITLE;
            }
        }

        public string _USER_NAME
        {
            get
            {
                return USER_NAME;
            }
            set
            {
                USER_NAME = value;
            }
        }
        public string _VERSION_URL
        {
            get
            {
                return VERSION_URL;
            }
        }

        public string _CFG_FULL_PATH
        {
            get
            {
                return CFG_FULL_PATH;
            }
            set
            {
                CFG_FULL_PATH = value;
            }
        }

        public string _CONFIG_FILE_NAME
        {
            get
            {
                return CONFIG_FILE_NAME;
            }
        }
        public int _EXPIRATION_TIME
        {
            get
            {
                return EXPIRATION_TIME;
            }
        }

    }
}
