using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using ZXing;
using ZXing.Aztec;
using ZXing.Common;
using System.Drawing.Printing;

namespace Sistem
{
    public partial class Form4 : Form
    {
        //HİLAL ÇINAR

        public Form4()
        {

            InitializeComponent();

        }


        static string conString = "Data Source=DESKTOP-6GFGG91\\SQLEXPRESS;Initial Catalog=kontrol;Integrated Security=True";
        SqlConnection connect = new SqlConnection(conString);


        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                //HİLAL ÇINAR

                connect.Open();
                
                string sorgu = "SELECT meslekiKimlik, isim, soyisim, telefonNo, eMailAdres, kullaniciAd FROM kullanici WHERE id = @id";
                SqlCommand komut = new SqlCommand(sorgu, connect);
                komut.Parameters.AddWithValue("@id", 3); 

                SqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    
                    label_meslekiKimlik.Text = reader["meslekiKimlik"].ToString();
                    label_isim.Text = reader["isim"].ToString();
                    label_soyisim.Text = reader["soyisim"].ToString();
                    label_telefonNo.Text = reader["telefonNo"].ToString();
                    label_eMailAdres.Text = reader["eMailAdres"].ToString();
                    label_kullaniciAd.Text = reader["kullaniciAd"].ToString();

                }

                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata: " + ex.Message);

            }
            finally
            {

                connect.Close();

            }
        }

        private void pERSONELBİLGİToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form10 form10 = new Form10();
            form10.Show();

        }

        private void kARTBİLGİToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form11 form11 = new Form11();
            form11.Show();

        }

        private void dIŞPERSONELDURUMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form12 form12 = new Form12();
            form12.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label_günAyYil.Text = ((DateTime.Now.Day) + "." + (DateTime.Now.Month) + "." + (DateTime.Now.Year)).ToString();
            label_saatDakikaSaniye.Text = ((DateTime.Now.Hour) + "." + (DateTime.Now.Minute) + "." + (DateTime.Now.Second)).ToString();

            //HİLAL ÇINAR

        }
    }
}
