using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace class_OEM_1
{
    public partial class SepetSayfa : System.Web.UI.Page
    {
        YönetimDb db;
        List<string> categories;
        int totalPrice;

        // KENDİ METODLARIM

        private void Show_Message(string text)
        {
            Response.Write("<script>alert('" + text + "');</script>");
        }

        private void Load_Logo()
        {
            ImageButton imgButton = new ImageButton();
            imgButton.ImageUrl = "logo2.png";
            imgButton.Click += İmgButton_Click;
            logo.Controls.Add(imgButton);
        }

        private void Create_Categories()
        {
            foreach (var item in db.Kategoriler)
            {
                categories.Add(item.Ad);
                Button button = new Button();
                button.Text = item.Ad;
                button.CssClass = "kategori";
                button.Attributes.Add("onmouseover", "change(this,event);");
                button.Attributes.Add("onmouseout", "change(this,event);");
                button.Click += Button_Click;
                kategoriler.Controls.Add(button);
            }
        }

        private void Load_Basket(int basketid, string brand, int amount, int price)
        {
            totalPrice += amount * price;

            Panel name = new Panel();
            name.Attributes.Add("style", "width: 33%; height: 25px; background-color: #CD5C5C; float:left");

            Panel amnt = new Panel();
            amnt.Attributes.Add("style", "width: 33%; height: 25px; background-color: #CD5C5C; float:left");

            Panel processes = new Panel();
            processes.Attributes.Add("style", "width: 33%; height: 25px; background-color: #CD5C5C; float:left");

            Label label1 = new Label();
            label1.Text = brand;
            label1.Attributes.Add("style", "font-family:Calibri; font-size:16px;");
            name.Controls.Add(label1);

            Label label2 = new Label();
            label2.Text = "x" + amount.ToString();
            label2.Attributes.Add("style", "font-family:Calibri; font-size:16px;");
            amnt.Controls.Add(label2);

            Button button1 = new Button();
            button1.Text = "Sepetten Çıkar";
            button1.Attributes.Add("style", "cursor:pointer; font-family:Calibri; font-size:18px; color:#FFFFFF; background-image:url('arkaplan.jpg');");
            button1.ID = basketid.ToString();
            button1.Click += Button1_Click;
            processes.Controls.Add(button1);

            Sepettekiler.Controls.Add(name);
            Sepettekiler.Controls.Add(amnt);
            Sepettekiler.Controls.Add(processes);
        }

        private bool Informations_Control(TextBox homeAddress, TextBox cardNumber, TextBox nameOnCard, TextBox cardCVV, TextBox userMail)
        {
            bool valid = false;
            if (!homeAddress.Text.Equals("") && !cardNumber.Text.Equals("") && !nameOnCard.Text.Equals("") &&
                !cardCVV.Text.Equals("") && !userMail.Text.Equals("")) valid = true;
            return valid;
        }

        // EVENT METODLARI

        private void Button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int basketid = Convert.ToInt32(button.ID);
            Sepet basket = new Sepet();
            foreach (Sepet b in db.Sepet) if (b.ID == basketid)
                {
                    basket = b;
                    break;
                }
            db.Sepet.Remove(basket);
            db.SaveChanges();
            Show_Message("Ürün Sepetten Başarıyla Çıkarıldı");
            Response.Redirect(Request.RawUrl);
        }

        private void İmgButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AnaSayfa.aspx");
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int category = categories.IndexOf(button.Text) + 1;
            Response.Redirect("ÜrünSayfa.aspx?category=" + category.ToString());
        }

        private void Sepetclk_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("SepetSayfa.aspx");
        }

        private void Bizeulasclk_ServerClick(object sender, EventArgs e)
        {
            Show_Message("İLETİŞİM: xxxx@gmail.com");
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            if (totalPrice == 0) Show_Message("Önce Sepetinize Ürün Eklemelisiniz!");
            else
            {
                TextBox homeAddress = (TextBox) FindControl("TeslimAdresi");
                TextBox cardNumber = (TextBox) FindControl("KartNo");
                TextBox nameOnCard = (TextBox) FindControl("KartSahip");
                //DropDownList cardLUM = (DropDownList) FindControl("SKAy");
                //DropDownList cardLUY = (DropDownList) FindControl("SKYıl");
                TextBox cardCVV = (TextBox) FindControl("KartCVV");
                DropDownList installment = (DropDownList) FindControl("Taksit");
                TextBox userMail = (TextBox) FindControl("Mail");

                if (Informations_Control(homeAddress, cardNumber, nameOnCard, cardCVV, userMail))
                {
                    string mailDetail = "Kart Sahibi: " + nameOnCard.Text + "<br/>Taksit: " + installment.SelectedValue +
                    "<br/>Toplam Çekilen Ücret: " + totalPrice.ToString() + " TL<br/>Ürünler:<br/>";

                    foreach (Sepet b in db.Sepet) foreach (Ürünler i in db.Ürünler) if (b.ÜrünID == i.ID)
                            {
                                mailDetail += i.Marka + " - " + i.Fiyat.ToString() + " TL - " + b.Miktar.ToString() + " Adet<br/>";
                            }

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("mertblsr@gmail.com");
                    mail.To.Add(userMail.Text);
                    mail.Subject = "[class OEM {}] Ödemeniz Başarıyla Yapıldı";
                    mail.Body = mailDetail;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    NetworkCredential AccountInfo = new NetworkCredential("mertblsr@gmail.com", "1971mert4554");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = AccountInfo;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(mail);

                    List<Sepet> basket = new List<Sepet>();
                    foreach (Sepet b in db.Sepet) basket.Add(b);
                    foreach (Sepet b in basket) db.Sepet.Remove(b);
                    db.SaveChanges();

                    Show_Message("Satın Alma İşlemi Başarılı, Detaylar Mail Adresinize Gönderildi");
                    Response.Redirect("AnaSayfa.aspx");
                } else
                {
                    Show_Message("Gerekli Alanlar Doldurulmamış");
                }
            }
        }

        // SAYFA YÜKLENME

        protected void Page_Load(object sender, EventArgs e)
        {
            totalPrice = 0;

            Load_Logo();

            db = new YönetimDb();
            db.Database.CreateIfNotExists();
            categories = new List<string>();

            Create_Categories();

            bizeulasclk.ServerClick += Bizeulasclk_ServerClick;
            sepetclk.ServerClick += Sepetclk_ServerClick;

            foreach (Sepet b in db.Sepet)
            {
                string brand = "";
                int price = 0;
                foreach (Ürünler u in db.Ürünler) if (u.ID == b.ÜrünID)
                    {
                        brand = u.Marka;
                        price = u.Fiyat;
                        break;
                    }
                Load_Basket(b.ID, brand, b.Miktar, price);
            }

            Label tp = (Label) FindControl("TotalPrice");
            tp.Text = "Toplam Fiyat: " + totalPrice.ToString() + " TL";

            Button buy = (Button) FindControl("OdemeYap");
            buy.Click += Buy_Click;
        }
    }
}