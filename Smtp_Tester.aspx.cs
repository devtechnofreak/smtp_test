using System;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
public partial class Smtp_Tester : System.Web.UI.Page
{
protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            var fromAddress = "patel_divyang08@live.com";
            const string fromPassword = "#divyang123";
            string subject = YourSubject.Text.ToString();
           string body = "From:" + YourName.Text + "\n";
            body += "Email: " + YourEmail.Text + "\n";
            body += "Subject: " + YourSubject.Text + "\n";
            body += "Question: \n" + Comments.Text + "\n";

            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 465;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);

            }

            smtp.Send(fromAddress, YourEmail.Text, subject, body);
            YourSubject.Text = "";
            YourEmail.Text = "";
            YourName.Text = "";
            Comments.Text = "";
            lblmsg.Text = "Email Send";
        }
        catch (Exception x)
        {
            lblmsg.Text = "Email not send" + x.ToString();
        }
    }
}
