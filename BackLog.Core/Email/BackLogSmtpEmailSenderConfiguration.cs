using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackLog.Email
{
   public class BackLogSmtpEmailSenderConfiguration: SmtpEmailSenderConfiguration
    {
        public BackLogSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        //public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}
