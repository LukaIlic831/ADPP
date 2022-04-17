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
	public partial class Form1 : Form
	{

		//Povezivanje sa bazom 
		SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=adpp;Integrated Security=True");
		String idd;

		//Keriranje klase Akcija
		class Akcija
		{
			public Bitmap slika;
			public String txt;
			public TimeSpan pocVreme, krajVreme;

			public Akcija(Bitmap s, String t, TimeSpan p, TimeSpan k)
			{
				slika = s;
				txt = t;
				pocVreme = p;
				krajVreme = k;
			}
		}

		//Kreiranje liste akcija
		List<Akcija> akcije = new List<Akcija>();
		List<Akcija> akSort = new List<Akcija>();


		public Form1()
		{
			InitializeComponent();
		}
		
		//Zvuk aplauza za dugme izvršeno
		private void playSimpleSound()
		{
			SoundPlayer simpleSound = new SoundPlayer(@"Aplauz.wav");
			simpleSound.Play();	
		}


		//Izlaz
		private void picBoxIzlaz_Click(object sender, EventArgs e)
		{
			Application.Exit();
			foreach (Form form in Application.OpenForms)
			{
				form.Close();
			}
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


		private void Form1_Load(object sender, EventArgs e)
		{
			//Properties.Settings.Default.idd = "non";
			idd = Properties.Settings.Default.idd;
			if (idd == "non")
            {
				Form2 f = new Form2();
				f.ShowDialog();
				//this.Hide();
				idd = Properties.Settings.Default.idd;
			}

			picBoxAplauzGif.Hide();

			//Otvaranje konekcije sa bazom i postavljanje upita
			con.Open();
			String upit = "select * from osobe where id=@id";
			SqlCommand cmd = new SqlCommand(upit, con);
			cmd.Parameters.AddWithValue("@id", idd);
			DataTable dt = new DataTable();
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				dt.Load(reader);
			}

			//Uzimanje akcija iz baze podataka preko broja akcije 
			foreach (var row in dt.AsEnumerable())
			{
				String akcija = row["akcija"].ToString();
				switch (akcija)
				{
					case "1":
						akcije.Add(new Akcija(Properties.Resources.citanje, "Vreme je za ucenje!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "2":
						akcije.Add(new Akcija(Properties.Resources.dorucak, "Vreme je za dorucak!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "3":
						akcije.Add(new Akcija(Properties.Resources.igranje, "Vreme je za igranje!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "4":
						akcije.Add(new Akcija(Properties.Resources.budjenje, "Vreme je za budjenje!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "5":
						akcije.Add(new Akcija(Properties.Resources.kupanje, "Vreme je za kupanje!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "6":
						akcije.Add(new Akcija(Properties.Resources.muzika, "Vreme je za slusanje muzike!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "7":
						akcije.Add(new Akcija(Properties.Resources.oblacenje, "Vreme je da se obuces!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "8":
						akcije.Add(new Akcija(Properties.Resources.pakovanje, "Vreme je za pakovanje!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "9":
						akcije.Add(new Akcija(Properties.Resources.polazak, "Vreme je za polazak!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "10":
						akcije.Add(new Akcija(Properties.Resources.rucak, "Vreme je za rucak!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "11":
						akcije.Add(new Akcija(Properties.Resources.slobodno, "Slobodno vreme!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "12":
						akcije.Add(new Akcija(Properties.Resources.spavanje, "Vreme je za spavanje!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "13":
						akcije.Add(new Akcija(Properties.Resources.toalet, "Vreme je za toalet!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "14":
						akcije.Add(new Akcija(Properties.Resources.uzina, "Vreme je za uzinu!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "15":
						akcije.Add(new Akcija(Properties.Resources.voznja, "Vreme je za vožnju!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
					case "16":
						akcije.Add(new Akcija(Properties.Resources.zubi, "Vreme je za pranje zuba!", TimeSpan.Parse(row["pocVreme"].ToString()), TimeSpan.Parse(row["krajVreme"].ToString())));
						break;
				}
			}
			con.Close();

			//Sortiranje akcije
			if (akcije.Any())
			{
				akSort = akcije.OrderBy(o => o.pocVreme).ToList();

				/*
				String ispis = "";
				foreach (var a in akSort)
                {
					ispis += a.pocVreme + ", ";
                }
				MessageBox.Show(ispis);
				*/

				Thread t = new Thread(() => Izmena());
				t.Start();
			}
            else
            {
				MessageBox.Show("Nije uneta ni jedna aktivnost na ovom ID-ju");
            }
		}

		int i = 0;

		//Funkcija za menjanje slika 
		void Izmena()
		{
			bool isLastComplete = false;
			while (true)
			{
				TimeSpan now;
				int vremeSpavanja;
				for ( i = 0; i < akSort.Count; i++)
				{
					isLastComplete = false;
					now = DateTime.Now.TimeOfDay;
					if (now >= akSort[i].pocVreme && now <= akSort[i].krajVreme)
					{
						picBox.Image = akSort[i].slika;
						if (label1.InvokeRequired)
						{
							label1.BeginInvoke((MethodInvoker)delegate () { label1.Text = akSort[i].txt; });
							vremeAkcije.BeginInvoke((MethodInvoker)delegate () { vremeAkcije.Text = akSort[i].pocVreme.ToString().Substring(0, 5) + " do " + akSort[i].krajVreme.ToString().Substring(0, 5); });
						}
						else
						{
							label1.Text = akSort[i].txt;
							vremeAkcije.Text = akSort[i].pocVreme.ToString() + " do " + akSort[i].krajVreme.ToString();
						}

						vremeSpavanja = Convert.ToInt32((akSort[i].krajVreme - now).TotalSeconds);
						isLastComplete = true;
						Thread.Sleep((vremeSpavanja + 1)*1000);
						Notifikacija();
					}
				}
				if (!isLastComplete)
				{
					now = DateTime.Now.TimeOfDay;
					int index = akSort.Count - 1;
					TimeSpan razlika = akSort[akSort.Count - 1].pocVreme - now;
					for (i = 0; i < akSort.Count; i++)
					{
						if (akSort[i].pocVreme > now && (akSort[i].pocVreme - now) < razlika)
						{
							razlika = akSort[i].pocVreme - now;
							index = i;
						}
					}

					picBox.Image = Properties.Resources.slobodno;
					if (label1.InvokeRequired)
					{
						label1.BeginInvoke((MethodInvoker)delegate () { label1.Text = "Trenutno nemaš nikakvih obaveza!"; });
						vremeAkcije.BeginInvoke((MethodInvoker)delegate () { vremeAkcije.Text = "do " + akSort[index].pocVreme.ToString(); });
					}
					else
					{
						label1.Text = "Trenutno nemaš nikakvih obaveza!";
						vremeAkcije.Text = "do " + akSort[index].pocVreme.ToString();
					}
					//MessageBox.Show(akSort[index].pocVreme.ToString());
					try
					{
						vremeSpavanja = Convert.ToInt32((akSort[index].pocVreme - now).TotalSeconds);
						Thread.Sleep((vremeSpavanja + 1) * 1000);
					}
                    catch
                    {
						MessageBox.Show("Niste uneli akcije na našem web sajtu");
						Application.Exit();
						return;
                    }
				}
			}

		}

		//Dugme izvršeno i zvuk aplauza
		private void btnIzvrseno_Click(object sender, EventArgs e)
		{
			Notifikacija();
		}

		void Notifikacija()
        {
			playSimpleSound();

			//Popup notifikacija za uspesno izvedenu akciju
			PopupNotifier popup = new PopupNotifier();
			Akcija tempNext;
			if (i < akSort.Count - 1)
			{
				tempNext = akSort[i + 1];
			}
			else
			{
				tempNext = akSort[0];
			}
			popup.TitleText = "Uspešno ste završili aktivnost";
			popup.ContentText = "Aktivnost: " + akSort[i].txt + "\nSledeća aktivnost: " + tempNext.txt + " u " + tempNext.pocVreme.ToString().Substring(0, 5);
			popup.Image = akSort[i].slika;
			popup.Popup();

			//Gif
			//picBoxAplauzGif.Show();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
        {
			this.WindowState = FormWindowState.Minimized;
		}

        private void pictureBox3_Click(object sender, EventArgs e)
        {
			//Podesi ID
			Form2 f = new Form2();
			f.ShowDialog();
			idd = Properties.Settings.Default.idd;
		}
    }
}
