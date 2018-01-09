using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtelOtomasyon
{
    public partial class frmOtel : Form
    {
        public frmOtel()
        {
            InitializeComponent();
        }

        Otel Otel = new Otel();

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Fiyat f = new Fiyat(double.Parse(txtSezon1.Text), double.Parse(txtSezon2.Text), double.Parse(txtSezon3.Text), double.Parse(txtSezon4.Text), double.Parse(txtTatil.Text));
            OdaOzellik o = new OdaOzellik() { Alan = Convert.ToInt16(numAlan.Value), Balkon = rbBalkonVar.Checked, Kat = Convert.ToInt16(numKat.Value), YatakSayisi = Convert.ToInt16(numYatak.Value), Konum = txtEk.Text };

            Oda yeniOda = new Oda(f, o);

            Otel.OdaEkle(yeniOda);

            OdaListesiYenile();
        }

        private void OdaListesiYenile()
        {
            dataGridOdalar.Rows.Clear();
            int i = 0;
            foreach( Oda o in Otel.Odalar)
            {
                dataGridOdalar.Rows.Add(o.No,o.Ozellikler.Kat,o.Ozellikler.Alan,o.Ozellikler.YatakSayisi);
                if (o.Durum)
                    dataGridOdalar.Rows[i].DefaultCellStyle.BackColor = Color.Lime;
                else
                    dataGridOdalar.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;

                i++;

            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmOtel_Load(object sender, EventArgs e)
        {
            takvimTatiller.MinDate = DateTime.Today;
            Takvim.MinDate = DateTime.Today;
        }

        private void btnMusteriKaydet_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri(txtAd.Text,txtSoyad.Text,dtDogum.Value,txtTel.Text,txtMail.Text,txtAdres.Text,rbEkrek.Checked);

            Otel.MusteriEkle(m);
            MusteriListesiYenile();
        }
        private void MusteriListesiYenile()
        {
            dataGridMusteriler.Rows.Clear();
            foreach(Musteri m in Otel.Musteriler)
            {
                string sonZiyaret;
                if(m.ZiyaretSayisi != 0)
                    sonZiyaret =m.RezervasyonTarihleri[m.RezervasyonTarihleri.Count-1].ToShortDateString();
                else
                    sonZiyaret = "Yok";

                dataGridMusteriler.Rows.Add(m.Ad,m.Soyad,m.IletisimBilgileri.TelefonNo,m.ZiyaretSayisi,sonZiyaret);

            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Takvim_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Takvim_MouseUp(object sender, MouseEventArgs e)
        {
            cbOdalar.Items.Clear();
            cbMusteriler.Items.Clear();
            foreach( Oda o in Otel.BosOdalar(Takvim.SelectionStart,Takvim.SelectionEnd))
            {           
                   cbOdalar.Items.Add(o.No);
            }

            foreach(Musteri m in Otel.Musteriler)
            {
                cbMusteriler.Items.Add(m.Ad+" "+m.Soyad);
            }

        }
        public void RezervasyonListesiYenile()
        {
            dataGridRezervasyonlar.Rows.Clear();

            Button btn = new Button();
            btn.Click += btnGridButton;

            foreach( Rezervasyon r in Otel.Rezervasyonlar)
            {
                dataGridRezervasyonlar.Rows.Add(r.No,r.Musteri.Ad+" "+r.Musteri.Soyad,r.Oda.No,r.GelisTarihi,r.GidisTarihi,r.Ucret);
            }
        }
        public void btnGridButton(object sender, EventArgs e)
        {
            Rezervasyon r = Otel.RezervasyonAra(int.Parse( dataGridRezervasyonlar.SelectedRows[0].Cells[0].Value.ToString()));

        }

        private void btnRezervasyonKaydet_Click(object sender, EventArgs e)
        {
           
            Oda o = Otel.OdaAra(int.Parse(cbOdalar.SelectedItem.ToString()));
            Rezervasyon r = new Rezervasyon();
            if (cbRezervasyonTipi.SelectedIndex == 0)
                r = new RezervasyonOnOdemeli(Otel.Musteriler[cbMusteriler.SelectedIndex], o, Takvim.SelectionStart, Takvim.SelectionEnd);
            if (cbRezervasyonTipi.SelectedIndex == 1)
                r = new Rezervasyon60(Otel.Musteriler[cbMusteriler.SelectedIndex], o, Takvim.SelectionStart, Takvim.SelectionEnd);
            if (cbRezervasyonTipi.SelectedIndex == 2)
                r = new RezervasyonStandart(Otel.Musteriler[cbMusteriler.SelectedIndex], o, Takvim.SelectionStart, Takvim.SelectionEnd);


            Otel.RezervasyonYap(r);

            RezervasyonListesiYenile();

        }

        private void dtSezon1_ValueChanged(object sender, EventArgs e)
        {
            Otel.Sezon1Baslama = dtSezon1.Value;
            
        }

        private void dtSezon2_ValueChanged(object sender, EventArgs e)
        {
            Otel.Sezon2Baslama = dtSezon2.Value;
        }

        private void dtSezon3_ValueChanged(object sender, EventArgs e)
        {
            Otel.Sezon3Baslama = dtSezon3.Value;
        }

        private void dtSezon4_ValueChanged(object sender, EventArgs e)
        {
            Otel.Sezon4Baslama = dtSezon4.Value;
        }

        private void takvimTatiller_DateChanged(object sender, DateRangeEventArgs e)
        {
            bool eklenmis = false;
            foreach (DateTime d in Otel.Tatiller)
                if (d == takvimTatiller.SelectionEnd)
                    eklenmis = true;
            if (!eklenmis)
            {
                Otel.Tatiller.Add(takvimTatiller.SelectionEnd);
               
            }
            TatilGetir();
        }

        private void lbTatiller_SelectedIndexChanged(object sender, EventArgs e)
        {

            takvimTatiller.SelectionStart = DateTime.Parse(lbTatiller.SelectedItem.ToString());
        }
        private void TatilGetir()
        {
            lbTatiller.Items.Clear();
            foreach (DateTime d in Otel.Tatiller)
                lbTatiller.Items.Add(d.ToShortDateString());
        }

        private void btnTatilSil_Click(object sender, EventArgs e)
        {
            List<DateTime> t = new List<DateTime>();
            foreach (DateTime d in Otel.Tatiller)
                if (d.ToShortDateString() !=lbTatiller.SelectedItem.ToString())
                    t.Add(d);

            Otel.Tatiller = t;
            TatilGetir();
            
        }

        private void btnRapor1_Click(object sender, EventArgs e)
        {
            int toplamDoluluk = 0;
            for(DateTime d=DateTime.Now; d<DateTime.Now.AddMonths(1);d=d.AddDays(1))
            {
                int dolu=0;
                foreach (Rezervasyon r in Otel.Rezervasyonlar)
                    if (d >= r.GelisTarihi && d <= r.GidisTarihi)
                        dolu++;
                lbRapor1.Items.Add(d.ToShortDateString()+"---> "+dolu);
                toplamDoluluk += dolu;
            }
            lblRapor1.Text = "Ortalama : "+toplamDoluluk/30;
        }

       

        private void btnRapor4_Click(object sender, EventArgs e)
        {
            lbRapor4.Items.Clear();
            foreach(Rezervasyon r in Otel.Rezervasyonlar)
            {
                if (r.GelisTarihi.ToShortDateString() == DateTime.Now.ToShortDateString())
                    lbRapor4.Items.Add(r.Musteri.Ad +"-->"+r.Oda.No+" - "+r.GidisTarihi.ToShortDateString());
            }
        }

       

        private void cbRezervasyonTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRezervasyonTipi.SelectedIndex == 0)
                Takvim.MinDate = DateTime.Today.AddMonths(3);
            if (cbRezervasyonTipi.SelectedIndex == 1)
                Takvim.MinDate = DateTime.Today.AddMonths(2);
            if (cbRezervasyonTipi.SelectedIndex == 2)
                Takvim.MinDate = DateTime.Today;
            if (cbRezervasyonTipi.SelectedIndex == 3)
                Takvim.MinDate = DateTime.Today;

            
            
        }

        private void tabRezervasyon_Click(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //TODO: REzervasyon Güncellemesi 
        }

        private void cbOdalar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbRapor1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
