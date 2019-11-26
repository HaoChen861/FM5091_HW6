using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trinomial
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            

        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void div_tag_Click(object sender, EventArgs e)
        {

        }

        private void cal_button_Click(object sender, EventArgs e)
        {
            bool k_s = double.TryParse(K_val.Text,out double k);
            bool s_s = double.TryParse(S_val.Text, out double s);
            bool r_s = double.TryParse(R_val.Text, out double r);
            bool t_s = double.TryParse(T_val.Text, out double t);
            bool sig_s = double.TryParse(Sig_val.Text, out double sig);
            bool n_s = int.TryParse(N_val.Text, out int n);
            bool div_s = double.TryParse(Div_val.Text,out double div);



            if (!k_s || !s_s || !r_s || !t_s || !sig_s || !n_s || !div_s ||k<0||s<0||t<0||sig<0||n<0||div<0)
            {
                MessageBox.Show("You have entered an invalid value.");
            }
            else if (amer_check.Checked == euro_check.Checked)
            {
                MessageBox.Show("You have not chose an option version");
            }
            else if (call_check.Checked == put_check.Checked)
            {
                MessageBox.Show("You have not chose an option type");
            }
            else
            {
                if (amer_check.Checked && call_check.Checked)
                {
                    Trinomial.amer_call a = new Trinomial.amer_call(k,s,r,t,sig,div,n);
                    Trinomial.amer_call b = new Trinomial.amer_call(k, s, r, t, sig + 0.001, div, n);
                    Trinomial.amer_call b1 = new Trinomial.amer_call(k, s, r, t, sig - 0.001, div, n);
                    Trinomial.amer_call c = new Trinomial.amer_call(k, s, r + 0.001, t , sig, div, n);
                    Trinomial.amer_call c1 = new Trinomial.amer_call(k, s, r - 0.001, t , sig, div, n);
                    double vega = (b.get_price() - b1.get_price()) / 0.002;
                    double rho = (c.get_price() - c1.get_price()) / 0.002;

                    string[] row = {a.get_price().ToString(),a.get_delta().ToString(),a.get_gamma().ToString(),a.get_theta().ToString(),vega.ToString(),rho.ToString()};
                    var list = new ListViewItem(row);
                    output_list.Items.Add(list);
                }
                else if (amer_check.Checked && put_check.Checked)
                {
                    Trinomial.amer_put a = new Trinomial.amer_put(k, s, r, t, sig, div, n);
                    Trinomial.amer_put b = new Trinomial.amer_put(k, s, r, t, sig+0.001, div, n);
                    Trinomial.amer_put b1 = new Trinomial.amer_put(k, s, r, t, sig-0.001, div, n);
                    Trinomial.amer_put c = new Trinomial.amer_put(k, s, r+0.001, t, sig, div, n);
                    Trinomial.amer_put c1 = new Trinomial.amer_put(k, s, r-0.001, t, sig, div, n);
                    double vega = (b.get_price() - b1.get_price()) / 0.002;
                    double rho = (c.get_price() - c1.get_price()) / 0.002;

                    string[] row = { a.get_price().ToString(), a.get_delta().ToString(), a.get_gamma().ToString(), a.get_theta().ToString(), vega.ToString(), rho.ToString() };
                    var list = new ListViewItem(row);
                    output_list.Items.Add(list);
                }
                else if (euro_check.Checked && call_check.Checked)
                {
                    Trinomial.euro_call a = new Trinomial.euro_call(k, s, r, t, sig, div, n);
                    Trinomial.euro_call b = new Trinomial.euro_call(k, s, r, t, sig + 0.0001, div, n);
                    Trinomial.euro_call b1 = new Trinomial.euro_call(k, s, r, t, sig - 0.0001, div, n);
                    Trinomial.euro_call c = new Trinomial.euro_call(k, s, r, t+0.0001, sig, div, n);
                    Trinomial.euro_call c1 = new Trinomial.euro_call(k, s, r, t-0.0001, sig, div, n);
                    double vega = (b.get_price() - b1.get_price()) / 0.0002;
                    double rho = (c.get_price() - c1.get_price()) / 0.0002;
                    string[] row = { a.get_price().ToString(), a.get_delta().ToString(), a.get_gamma().ToString(), a.get_theta().ToString(), vega.ToString(), rho.ToString() };
                    var list = new ListViewItem(row);
                    output_list.Items.Add(list);

                }
                else
                {
                    Trinomial.euro_put a = new Trinomial.euro_put(k, s, r, t, sig, div, n);
                    Trinomial.euro_put b = new Trinomial.euro_put(k, s, r, t, sig+0.001, div, n);
                    Trinomial.euro_put b1 = new Trinomial.euro_put(k, s, r, t, sig-0.001, div, n);
                    Trinomial.euro_put c = new Trinomial.euro_put(k, s, r+0.001, t, sig, div, n);
                    Trinomial.euro_put c1 = new Trinomial.euro_put(k, s, r-0.001, t, sig, div, n);
                    double vega = (b.get_price() - b1.get_price()) / 0.0002;
                    double rho = (c.get_price() - c1.get_price()) / 0.0002;
                    string[] row = { a.get_price().ToString(), a.get_delta().ToString(), a.get_gamma().ToString(), a.get_theta().ToString(), vega.ToString(), rho.ToString() };
                    var list = new ListViewItem(row);
                    output_list.Items.Add(list);

                }


            }




        }

        private void put_check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void call_check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            output_list.Items.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
