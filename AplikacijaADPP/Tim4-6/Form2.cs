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
using System.Threading;
using Tulpep.NotificationWindow;
using System.Media;

namespace Tim4_6
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		//Izlaz
		private void picBoxIzlaz_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != "")
				this.Close();
			else
				MessageBox.Show("Unesite vaš ID");
		}

		//Form dragging
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case 0x84:
					base.WndProc(ref m);
					if ((int)m.Result == 0x1)
						m.Result = (IntPtr)0x2;
					return;
			}

			base.WndProc(ref m);
		}


		private void Form2_Load(object sender, EventArgs e)
		{
			
		}


        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Enter)
			{
				Properties.Settings.Default.idd = textBox1.Text;
				Properties.Settings.Default.Save();
				//Form1 f = new Form1();
				//f.Show();
				this.Close();
			}
		}
    }
}
