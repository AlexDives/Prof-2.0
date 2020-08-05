using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prof
{
    public partial class FLogo : Form
    {
        public FLogo()
        {
            InitializeComponent();
        }

        int sec = 0;

        private void FLogo_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            this.BackColor = Color.AliceBlue;//цвет фона  
            this.TransparencyKey = this.BackColor;//он же будет заменен на прозрачный цвет
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec == 2)
            {
                timer1.Enabled = false;
                Close();
            }
            else sec++;
        }
    }
}
