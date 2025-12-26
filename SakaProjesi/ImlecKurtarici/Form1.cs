using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ImlecKurtarici
{
    public partial class Form1 : Form
    {
        // --- Windows API Tanımlamaları ---
        // Sistem parametrelerini değiştirmek/yenilemek için gereken fonksiyon
        [DllImport("user32.dll")]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        // Sabitler: İmleçleri resetlemek için gereken kodlar
        const uint SPI_SETCURSORS = 0x0057;
        const uint SPIF_UPDATEINIFILE = 0x01;
        const uint SPIF_SENDCHANGE = 0x02;

        public Form1()
        {
            // InitializeComponent SİLDİK.
            // Arayüzü (Butonu) elle oluşturuyoruz ki hata vermesin.

            this.Text = "ANTİVİRÜS - KURTARICI";
            this.Size = new System.Drawing.Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;

            // KOCAMAN BİR BUTON OLUŞTURALIM
            Button btnKurtar = new Button();
            btnKurtar.Text = "FARE İMLECİNİ\nGERİ GETİR"; // \n alt satıra geçer
            btnKurtar.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            btnKurtar.Dock = DockStyle.Fill; // Buton tüm formu kaplasın

            // Butona tıklanınca ne olacağını söylüyoruz
            btnKurtar.Click += BtnKurtar_Click;

            // Butonu forma ekle
            this.Controls.Add(btnKurtar);
        }

        private void BtnKurtar_Click(object sender, EventArgs e)
        {
            // 1. Sistemi Onar
            SistemiOnar();

            // 2. Kullanıcıya bilgi ver
            MessageBox.Show("Sistem onarıldı! İmleç geri yüklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. Programı kapat
            Application.Exit();
        }

        private void SistemiOnar()
        {
            // Windows'a "Tüm imleçleri varsayılan ayarlara geri döndür" emri veriyoruz.
            // Bu komut hafızadaki bozuk/şeffaf imleçleri siler ve orijinallerini yükler.
            SystemParametersInfo(SPI_SETCURSORS, 0, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
    }
}