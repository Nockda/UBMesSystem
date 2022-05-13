﻿using System;
using System.IO;
using Micube.Framework;
using Micube.Framework.Log;
using Micube.Framework.SmartControls;
using Newtonsoft.Json;

namespace SmartMES.Settings
{
    public class LoginSettingRepository : ISettingRepository
    {
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Micube\\SmartMES\\Setting");
        private string fileFullName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Micube\\SmartMES\\Setting\\") + System.Diagnostics.Process.GetCurrentProcess().ProcessName + "_LoginSetting.json";

        public SettingConfig Get(string userId)
        {
            if (File.Exists(fileFullName))
            {
                try
                {
                    var jsonString = File.ReadAllText(fileFullName);
                    SettingConfig.Current = JsonConvert.DeserializeObject<SettingConfig>(jsonString);
                }
                catch (Exception ex)
                {
                    //TODO : 다국어메세지 추가 필요
                    MSGBox.Show(MessageBoxType.Information, "SmartMES", "로그인 설정을 불러오는데 실패하였습니다. 로그인 설정을 초기화합니다.");

                    Logger.Error(ex.ToString());

                    SettingConfig.Current = new SettingConfig();
                }
            }
            else
                SettingConfig.Current = new SettingConfig();

            return SettingConfig.Current;
        }

        public void Save(string userId, SettingConfig setting)
        {
            string jsonString = JsonConvert.SerializeObject(setting);

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);


            File.WriteAllText(fileFullName, jsonString);
        }
    }
}
