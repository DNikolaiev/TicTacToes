using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToes
{
    public partial class Form1 : Form
    {
        private bool turn=true; //true - X turn, false - O turn
        int turn_count = 0;


        public Form1()
        {
            
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn_count = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    turn = true;
                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                }
            }
            catch { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Rules are obvious");

        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn_count++;
            turn = !turn;
            b.Enabled = false;

            if(turn_count==9)
            {
                MessageBox.Show("Draw!","Game Over!");
            }

            check_for_winner();
            
        }

        public void check_for_winner()
        {
            
            bool winner = false;
            //horizontal wins
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;
            //vertical wins
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;
            //diagonal wins
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                winner = true;
         
            string player = "";
            if (winner)
            {
                disableButtons();
                if (!turn)
                    {
                      player = "X Wins!";
                     }

                if (turn)
                      {
                        player = "O wins!";
                      }
                MessageBox.Show(player);
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
            catch { }
        }

     

        private void button_enter(object sender, EventArgs e)
        {
            try
            {

               
                    Button b = (Button)sender;
                if (b.Enabled)
                    if (turn)
                    {
                        b.Text = "X";
                    }
                    else b.Text = "O";

                
            }
            catch { }
        }

        private void button_leave(object sender, EventArgs e)
        {
            try
            {
              
                    Button b = (Button)sender;
                if (b.Enabled)
                    b.Text = "";

                }
            
            catch { }

        }
    }
}

