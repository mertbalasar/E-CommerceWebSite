using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace class_OEM_1
{
    public partial class ÜrünSayfa : System.Web.UI.Page
    {
        YönetimDb db;
        int counter;
        List<string> categories;
        int selectedCategory;

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

        public void byteArrayToImage(byte[] byteArrayIn)
        {
            System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(byteArrayIn));
            x.Save(Server.MapPath("~\\images\\oemdevice" + counter.ToString() + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void Create_Item(int itemid, string brand, string properties, byte[] image, int price)
        {
            counter++;

            List<string> key = new List<string>();
            List<string> value = new List<string>();
            string[] prop = properties.Split(';');
            foreach (string f in prop)
            {
                key.Add(f.Split(':')[0]);
                value.Add(f.Split(':')[1]);
            }

            Panel item = new Panel();
            item.CssClass = "speicalpanel";

            Panel first = new Panel();
            first.Attributes.Add("style", "width:120px; height:120px; float:left;");

            Panel second = new Panel();
            second.Attributes.Add("style", "width:55%; height:120px; float:left;");

            Panel header = new Panel();
            header.Attributes.Add("style", "width:100%; height:20px;");

            Panel detail = new Panel();
            detail.Attributes.Add("style", "width:100%; height:100px;");

            Panel third = new Panel();
            third.Attributes.Add("style", "width:20%; height:120px; float:left;");

            Panel prc = new Panel();
            prc.Attributes.Add("style", "width:100%; height:33%;");

            Panel count = new Panel();
            count.Attributes.Add("style", "width:100%; height:33%;");

            Panel buy = new Panel();
            buy.Attributes.Add("style", "width:100%; height:33%;");

            byteArrayToImage(image);
            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
            img.ImageUrl = Server.MapPath("~\\images\\oemdevice" + counter.ToString() + ".jpg");
            img.Width = 120;
            img.Height = 120;

            Label label1 = new Label();
            label1.Text = brand + " " + value[0];
            label1.Attributes.Add("style", "font-family:Calibri; font-size:18px; font-weight:bold;");
            header.Controls.Add(label1);

            Label label2 = new Label();
            for (int i = 0; i < key.Count; i++)
                if (i != key.Count - 1) label2.Text += key[i] + " : " + value[i] + " , ";
                else label2.Text += key[i] + " : " + value[i];
            label2.Attributes.Add("style", "font-family:Calibri; font-size:16px;");
            detail.Controls.Add(label2);

            Label label3 = new Label();
            label3.Text = price.ToString() + " TL";
            label3.Attributes.Add("style", "font-family:Calibri; font-size:24px; font-weight:bold; float:right");
            prc.Controls.Add(label3);

            TextBox textbox1 = new TextBox();
            textbox1.Attributes.Add("style", "font-family:Calibri; font-size:16px; float:right");
            textbox1.Attributes.Add("maxlength", "1");
            textbox1.TextMode = TextBoxMode.Number;
            textbox1.Text = "1";
            textbox1.ID = "T" + itemid.ToString();
            textbox1.Width = 45;
            textbox1.AutoPostBack = true;
            textbox1.TextChanged += Textbox1_TextChanged;
            count.Controls.Add(textbox1);

            Button button1 = new Button();
            button1.Attributes.Add("style", "cursor:pointer; font-family:Calibri; font-size:18px; color:#FFFFFF; background-image:url('arkaplan.jpg'); float:right;");
            button1.Text = "Sepete Ekle";
            button1.ID = itemid.ToString();
            button1.Click += Button1_Click;
            buy.Controls.Add(button1);

            first.Controls.Add(img);
            second.Controls.Add(header);
            second.Controls.Add(detail);
            third.Controls.Add(prc);
            third.Controls.Add(count);
            third.Controls.Add(buy);

            item.Controls.Add(first);
            item.Controls.Add(second);
            item.Controls.Add(third);

            divicerik.Controls.Add(item);
        }

        private bool Price_Control(int number, string limits)
        {
            bool isOk = false;
            int minVal = -1;
            int maxVal = -1;
            if (!limits.Split('-')[0].Equals("")) minVal = Convert.ToInt32(limits.Split('-')[0]);
            if (!limits.Split('-')[1].Equals("")) maxVal = Convert.ToInt32(limits.Split('-')[1]);
            if (minVal != -1 && maxVal != -1) if (number > minVal && number < maxVal) isOk = true;
            if (minVal != -1 && maxVal == -1) if (number > minVal) isOk = true;
            if (minVal == -1 && maxVal != -1) if (number < maxVal) isOk = true;
            return isOk;
        }

        private void Textbox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbx = sender as TextBox;
            if (Convert.ToInt32(txtbx.Text) < 1) txtbx.Text = "1";
            if (Convert.ToInt32(txtbx.Text) > 9) txtbx.Text = "9";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            selectedCategory = categories.IndexOf(button.Text) + 1;
            Response.Redirect("ÜrünSayfa.aspx?category=" + selectedCategory.ToString());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int itemid = Convert.ToInt32(button.ID);
            TextBox textbox = (TextBox) FindControl("T" + button.ID);
            int amount = Convert.ToInt32(textbox.Text);
            bool hasItem = false;
            Sepet basket = new Sepet();
            foreach (Sepet item in db.Sepet) 
                if (item.ÜrünID == itemid)
                {
                    basket = item;
                    hasItem = true;
                    break;
                }
            if (!hasItem)
            {
                basket.ÜrünID = itemid;
                basket.Miktar = amount;
                db.Sepet.Add(basket);
                db.SaveChanges();
            } else
            {
                basket.Miktar += amount;
                db.SaveChanges();
            }
            Show_Message("Ürünler Sepetinize Başarıyla Eklendi");
        }

        private void İmgButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AnaSayfa.aspx");
        }

        private void Filtreuygula_Click(object sender, EventArgs e)
        {
            string brand = DropDownList1.SelectedValue;
            string priceRange = Minimum.Text + "-" + Maksimum.Text;
            string query = "?category=" + selectedCategory.ToString();
            if (!brand.Equals("Tümü")) query += "&brand=" + brand;
            if (!priceRange.Equals("-")) query += "&pricerange=" + priceRange;
            Response.Redirect("ÜrünSayfa.aspx" + query);
        }

        private void Sepetclk_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("SepetSayfa.aspx");
        }

        private void Bizeulasclk_ServerClick(object sender, EventArgs e)
        {
            Show_Message("İLETİŞİM: xxxx@gmail.com");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            counter = 0;

            db = new YönetimDb();
            selectedCategory = Convert.ToInt32(Request.QueryString["category"]);
            string brandFilter = Request.QueryString["brand"];
            string priceFilter = Request.QueryString["pricerange"];
            categories = new List<string>();

            DropDownList1.Enabled = true;
            Minimum.Enabled = true;
            Maksimum.Enabled = true;

            Load_Logo();
            Create_Categories();
            filtreuygula.Click += Filtreuygula_Click;
            bizeulasclk.ServerClick += Bizeulasclk_ServerClick;
            sepetclk.ServerClick += Sepetclk_ServerClick;

            foreach (var item in db.Ürünler) if (item.KategoriID == selectedCategory)
                {
                    DropDownList1.Items.Add(item.Marka);
                    if (brandFilter == null & priceFilter == null) Create_Item(item.ID, item.Marka, item.Özellikler, item.Fotoğraf, item.Fiyat);
                    else
                    {
                        if (brandFilter != null)
                        {
                            if (priceFilter != null) { if (brandFilter.Equals(item.Marka) && Price_Control(item.Fiyat, priceFilter))
                                    Create_Item(item.ID, item.Marka, item.Özellikler, item.Fotoğraf, item.Fiyat); }
                            else if (brandFilter.Equals(item.Marka)) Create_Item(item.ID, item.Marka, item.Özellikler, item.Fotoğraf, item.Fiyat);
                        } else
                        {
                            if (Price_Control(item.Fiyat, priceFilter))
                                Create_Item(item.ID, item.Marka, item.Özellikler, item.Fotoğraf, item.Fiyat);
                        }
                    }
                }
        }
    }
}