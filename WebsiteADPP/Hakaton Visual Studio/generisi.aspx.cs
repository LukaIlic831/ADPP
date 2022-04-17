using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Hakaton_Visual_Studio
{
    public partial class generisi1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



		public int randomInt = 0;

		SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=adpp;Integrated Security=True");
		protected void Button1_Click(object sender, EventArgs e)
        {

			List<TextBox> txtBoxList = new List<TextBox>();

			Random rnd = new Random();
			randomInt = rnd.Next(1000, 10000);



			txtBoxList.Add(TextBox1);
			txtBoxList.Add(TextBox2);
	

			txtBoxList.Add(TextBox3);
			txtBoxList.Add(TextBox4);
			

			txtBoxList.Add(TextBox5);
			txtBoxList.Add(TextBox6);
			

			txtBoxList.Add(TextBox7);
			txtBoxList.Add(TextBox8);
			

			txtBoxList.Add(TextBox9);
			txtBoxList.Add(TextBox10);
			

			txtBoxList.Add(TextBox11);
			txtBoxList.Add(TextBox12);
			

			txtBoxList.Add(TextBox13);
			txtBoxList.Add(TextBox14);
			

			txtBoxList.Add(TextBox15);
			txtBoxList.Add(TextBox16);
			

			txtBoxList.Add(TextBox17);
			txtBoxList.Add(TextBox18);
			

			txtBoxList.Add(TextBox19);
			txtBoxList.Add(TextBox20);
			
			
			txtBoxList.Add(TextBox21);
			txtBoxList.Add(TextBox22);
			
			
			txtBoxList.Add(TextBox23);
			txtBoxList.Add(TextBox24);
			

			txtBoxList.Add(TextBox25);
			txtBoxList.Add(TextBox26);
			

			txtBoxList.Add(TextBox27);
			txtBoxList.Add(TextBox28);
			

			txtBoxList.Add(TextBox29);
			txtBoxList.Add(TextBox30);
			

			txtBoxList.Add(TextBox31);
			txtBoxList.Add(TextBox32);
			

			txtBoxList.Add(TextBox33);
			txtBoxList.Add(TextBox34);
			
			txtBoxList.Add(TextBox34);



			List<TextBox> txtBoxListAkcije = new List<TextBox>();

			

			txtBoxListAkcije.Add(TextBoxT1);
			txtBoxListAkcije.Add(TextBoxT2);
			txtBoxListAkcije.Add(TextBoxT3);
			txtBoxListAkcije.Add(TextBoxT4);
			txtBoxListAkcije.Add(TextBoxT5);
			txtBoxListAkcije.Add(TextBoxT6);
			txtBoxListAkcije.Add(TextBoxT7);
			txtBoxListAkcije.Add(TextBoxT8);
			txtBoxListAkcije.Add(TextBoxT9);
			txtBoxListAkcije.Add(TextBoxT10);
			txtBoxListAkcije.Add(TextBoxT11);
			txtBoxListAkcije.Add(TextBoxT12);
			txtBoxListAkcije.Add(TextBoxT13);
			txtBoxListAkcije.Add(TextBoxT14);
			txtBoxListAkcije.Add(TextBoxT15);
			txtBoxListAkcije.Add(TextBoxT16);
			txtBoxListAkcije.Add(TextBoxT17);


			int akcijeNum = 0;

			for (int i = 0; i < txtBoxList.Count - 1; i+=2)
			{
				
				if (txtBoxList[i + 1].Text != "")
				{
					con.Open();
					String upit = "insert into osobe values(@id, @akcija, @pocVreme, @krajVreme)";
					SqlCommand cmd = new SqlCommand(upit, con);


					cmd.Parameters.AddWithValue("@id", randomInt.ToString());
					
					cmd.Parameters.AddWithValue("@pocVreme", txtBoxList[i].Text);
					cmd.Parameters.AddWithValue("@krajVreme", txtBoxList[i + 1].Text);
					cmd.Parameters.AddWithValue("@akcija", int.Parse(txtBoxListAkcije[akcijeNum].Text) + 1);
					

					cmd.ExecuteNonQuery();
					con.Close();

					
				}
				akcijeNum++;
			}
			ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Vaš ID je: " + randomInt.ToString() + "');", true);
		}


    }
}