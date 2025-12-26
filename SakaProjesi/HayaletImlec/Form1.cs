using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HayaletImlec
{
    public partial class Form1 : Form
    {
        // --- Windows API Tanımlamaları (user32.dll) ---

        // Fare imlecini değiştirmek için gereken fonksiyon
        [DllImport("user32.dll")]
        static extern bool SetSystemCursor(IntPtr hcur, uint id);

        // Sistemin standart imleç ID'si (Normal Ok İşareti)
        const uint OCR_NORMAL = 32512;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Program başladığında görünmez olmalı
            this.ShowInTaskbar = false; // Görev çubuğunda görünme
            this.Opacity = 0;           // Tamamen şeffaf ol
            this.FormBorderStyle = FormBorderStyle.None; // Kenarlıkları kaldır

            // 2. Fareyi kaybetme operasyonu
            ImleciYokEt();

            // 3. İşimiz bitti, program arka planda kalmasın, kapansın.
            // (İmleç RAM'de değiştiği için program kapansa bile etki sürer!)
            Application.Exit();
        }

        private void ImleciYokEt()
        {
            // Şeffaf, 1x1 piksellik boş bir resim (Bitmap) oluşturuyoruz.
            using (Bitmap bitmap = new Bitmap(1, 1))
            {
                // Bu boş resimden bir imleç (icon) tutamacı alıyoruz.
                IntPtr hIcon = bitmap.GetHicon();

                // Sistemdeki normal fare imlecini (OCR_NORMAL), bu şeffaf ikonla değiştiriyoruz.
                SetSystemCursor(hIcon, OCR_NORMAL);
            }
        }
    }
}