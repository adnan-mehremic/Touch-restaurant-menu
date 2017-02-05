using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_meni
{
    public partial class igrica : Form
    {
        bool turn = true;
        int turn_count = 0;
        public igrica()
        {
            InitializeComponent();
        }

        private void home_Click(object sender, EventArgs e)
        {
            pocetna p = new pocetna();
            p.Show();
            this.Hide();
        }

        private void internet_Click(object sender, EventArgs e)
        {
            internet h = new internet();
            h.Show();
            this.Hide();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            chekForWinner();
        }
        private void chekForWinner()
        {
            bool pobjednik = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                pobjednik = true;
           else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                pobjednik = true;
           else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                pobjednik = true;

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                pobjednik = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                pobjednik = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                pobjednik = true;

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                pobjednik = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                pobjednik = true;
          

            if (pobjednik)
            {
                disableButtons();
                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                DialogResult result1 = MessageBox.Show(winner + " je pobjednik!" + Environment.NewLine + "Želite li novu igru?", "Rezultat", MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    turn = true;
                    turn_count = 0;
                    try
                    {
                        foreach (Control c in Controls)
                        {
                            Button b = (Button)c;
                            b.Enabled = true;
                            b.Text = "";
                        }
                    }
                    
                    catch
                    {
                    }
                }
                else if (result1 == DialogResult.No)
                {
                    igrica p = new igrica();
                    p.Show();
                    this.Hide();

                }
            }
            else {
                if (turn_count==9)
                {
                    DialogResult result1 = MessageBox.Show(" Nerješeno!" + Environment.NewLine + "Želite li novu igru?", "Rezultat", MessageBoxButtons.YesNo);


                if (result1 == DialogResult.Yes)
                {
                    turn = true;
                    turn_count = 0;
                    try
                    {
                        foreach (Control c in Controls)
                        {
                            Button b = (Button)c;
                            b.Enabled = true;
                            b.Text = "";
                        }
                    }

                    catch
                    {
                    }
                }
                else if (result1 == DialogResult.No)
                {
                    igrica p = new igrica();
                    p.Show();
                    this.Hide();

                }
                }

            }
        }
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch
            { }
        }

        //private void nova_igra_Click(object sender, EventArgs e)
        //{
        //    turn = true;
        //    turn_count = 0;
        //    try
        //    {
        //        foreach (Control c in Controls)
        //        {
        //            Button b = (Button)c;
        //            b.Enabled = true;
        //            b.Text="";
        //        }
        //    }
        //    catch
        //    { }

        //}
    }
}
