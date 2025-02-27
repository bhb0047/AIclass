﻿using _0106GudiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace _0106GudiShop.DAC
{
    public class EmailSettings
    {
        public string MailToAddress = "bhb0047@naver.com";
        public string MailFromAddress = "bhb0047@gmail.com";
        public bool UseSsl = true;
        public string Username = "구디마켓";
        public string Password = "lusjwwirhrhhznmj";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
    public class EmailOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShipInfo orderInfo)
        {
            using (var smtpClient = new SmtpClient())
            {

                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.MailFromAddress,
                          emailSettings.Password);

                StringBuilder body = new StringBuilder()
                    .AppendLine("주문처리가 완료되었습니다.")
                    .AppendLine("---")
                    .AppendLine("Items:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Qty;
                    body.AppendFormat("         - {0} x {1} (subtotal: {2:c})", 
                                      line.Product.Name, line.Qty,
                                      subtotal);
                    body.AppendLine();
                }
                body.AppendLine();

                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                    .AppendLine()
                    .AppendLine("---")
                    .AppendLine("배송지정보:")
                    .AppendLine(orderInfo.Name)
                    .AppendLine(orderInfo.Addr1)
                    .AppendLine(orderInfo.Addr2 ?? "")
                    .AppendLine(orderInfo.Message ?? "")
                    .AppendLine("---");

                MailMessage mailMessage = new MailMessage(
                                       emailSettings.MailFromAddress,   // From
                                       emailSettings.MailToAddress,     // To
                                       "신규 주문 완료!",                // Subject
                                       body.ToString());                // Body

                smtpClient.Send(mailMessage);
            }
        }
    }
}