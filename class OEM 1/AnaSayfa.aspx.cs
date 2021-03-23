using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Drawing;
using System.IO;

namespace class_OEM_1
{
    public partial class AnaSayfa : System.Web.UI.Page
    {
        // DEĞİŞKENLER

        YönetimDb db;
        List<string> categories;

        // KENDİ OLUŞTURDUKLARIM 

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

        // EVENT METODLARI

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

        // SAYFA YUKLENME OLAYI

        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Logo();

            db = new YönetimDb();
            db.Database.CreateIfNotExists();
            categories = new List<string>();

            Create_Categories();

            DropDownList1.Enabled = false;

            bizeulasclk.ServerClick += Bizeulasclk_ServerClick;
            sepetclk.ServerClick += Sepetclk_ServerClick;
        }
    }
}