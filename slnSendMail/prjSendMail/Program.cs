using System.Net;
using System.Net.Mail;

namespace prjSendMail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string smtpServer = "smtp.gmail.com";
            int port = 587;
            string senderEmail = "JHobby.THM103@gmail.com";
            string senderPassword = "dfgr qjhw rbqz zold";
            string attachmentPath = "Images/bird.png";

            Console.WriteLine("請輸入收件人 Email（多個用逗號分隔）：");

            List<string> recipients = new();
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) break;

                string[] split = input.Split(',');
                foreach (var email in split)
                {
                    string cleaned = email.Trim();
                    if (!string.IsNullOrWhiteSpace(cleaned)) recipients.Add(cleaned);
                }
            }

            if (recipients.Count == 0)
            {
                Console.WriteLine("沒有輸入任何收件人，程式結束。");
                return;
            }

            if (!File.Exists(attachmentPath))
            {
                Console.WriteLine($"找不到圖片檔案：{attachmentPath}，請放在執行檔旁邊");
                return;
            }

            Console.WriteLine("開始刷信模式（主旨含編號與亂數，隨機內文＋圖片附件），按 Ctrl + C 結束\n");

            int count = 0;
            Random rand = new();

            while (true)
            {
                count++;
                string randomCode = GenerateRandomString(6, rand);
                string subject = $"信 #{count} - {randomCode}";
                string body = GenerateRandomBody(count, randomCode, rand);

                try
                {
                    using SmtpClient client = new(smtpServer, port)
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(senderEmail, senderPassword)
                    };

                    MailMessage message = new()
                    {
                        From = new MailAddress(senderEmail),
                        Subject = subject,
                        Body = body
                    };

                    recipients.ForEach(email => message.To.Add(email));
                    message.Attachments.Add(new Attachment(attachmentPath));

                    client.Send(message);
                    Console.WriteLine($"已寄出第 {count} 封信件：{subject}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"發送失敗：{ex.Message}");
                }

                // 可選加上間隔
                // Thread.Sleep(1000);
            }
        }

        static string GenerateRandomString(int length, Random rand)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] buffer = new char[length];
            for (int i = 0; i < length; i++)
                buffer[i] = chars[rand.Next(chars.Length)];
            return new string(buffer);
        }

        static string GenerateRandomBody(int count, string code, Random rand)
        {
            string[] paragraphs = new[]
            {
            "感謝您使用我們的服務，以下是今日提醒事項。",
            "這是一封系統自動產生的通知信，請勿回覆。",
            "若您無法閱讀本信，請使用其他郵件閱讀器。",
            "屌之呼吸，一之型。",
            "感謝閱讀此信，若有任何疑問請聯繫系統管理員。",
            "猜猜我是誰，請勿轉發。"
        };

            int paraCount = rand.Next(2, 5);
            List<string> selected = new();
            for (int i = 0; i < paraCount; i++)
            {
                selected.Add(paragraphs[rand.Next(paragraphs.Length)]);
            }

            return $"這是第 {count} 封刷信。\n亂數識別碼：{code}\n\n" + string.Join("\n\n", selected);
        }
    }
}