using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class Calculator : Form
    {
        private List<string> equationHistory = new List<string>();
        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "7";
        }


        private void button8_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation"  )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "9";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "6";
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "3";
        }

        private void multiply(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "*";
        }

        private void add(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "+";
        }

        private void equal(object sender, EventArgs e)
        {
           
            string equationToSolve = equation.Text;

            
            string result = EquationSolver.Solve(equationToSolve);

            
            equation.Text = result;
            equationHistory.Add($"{equationToSolve} = {result}\n");

            // Update the list view
            listView1.Items.Clear();
            foreach (string item in equationHistory)
            {
                listView1.Items.Add(item);
            }

        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "0";
        }

        private void point(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + ".";
        }

        private void clear(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = "";
        }

        private void delete(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
             }
            else { equation.Text = equation.Text.Substring(0, equation.Text.Length - 1); }
            
        }

        private void minus(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "-";
        }

        private void divide(object sender, EventArgs e)
        {
            if (equation.Text == "Invalid equation" )
            {
                equation.Text = "";
            }
            equation.Text = equation.Text + "/";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Get the selected item's text
                string selectedHistory = listView1.SelectedItems[0].Text;

                // Set the equation text to the selected history
                equation.Text = selectedHistory.Split('=')[0].Trim();
            }
        }

        private void label1_click(object sender, EventArgs e) { }
    }
}
