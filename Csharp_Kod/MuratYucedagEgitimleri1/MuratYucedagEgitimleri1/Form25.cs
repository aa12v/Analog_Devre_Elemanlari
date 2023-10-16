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



namespace MuratYucedagEgitimleri1
{
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
        }

        static string conString = "Data Source = DESKTOP-6GFGG91\\SQLEXPRESS;Initial Catalog=elektronikProje1;Integrated Security=True";
        SqlConnection connect = new SqlConnection(conString);


        public void kayitlariGetir()
        {

            string getir = "Select *From PersonelBilgi";

            SqlCommand komut = new SqlCommand(getir, connect);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            connect.Close();

        }



        private void Form25_Load(object sender, EventArgs e)
        {

        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string kayit = "insert into personelBilgi (meslekiKimlik, isim, soyisim, telefonNo, eMailAdres) values (@meslekiKimlik, @isim, @soyisim, @telefonNo, @eMailAdres)";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@meslekiKimlik", textBox1.Text);
                komut.Parameters.AddWithValue("@isim", textBox2.Text);
                komut.Parameters.AddWithValue("@soyisim", textBox3.Text);
                komut.Parameters.AddWithValue("@telefonNo", textBox4.Text);
                komut.Parameters.AddWithValue("@eMailAdres", textBox5.Text);

                komut.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("Kayıt Ekleme Başarılı");
            }

            catch (Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi! " + hata.Message);
            }


        }

        private void button_personelAra_Click(object sender, EventArgs e)
        {
            string ara = "Select * From personelBilgi where isim LIKE '%' + @isim + '%'";
            SqlCommand komut = new SqlCommand(ara, connect);

            komut.Parameters.AddWithValue("@isim", textBox_ara.Text);

            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            connect.Close();

        }

        private void button_kayitlariListele_Click(object sender, EventArgs e)
        {
            kayitlariGetir();
        }
    }
}
