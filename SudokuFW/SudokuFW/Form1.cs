using SudokuW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuFW
{
    public partial class Form1 : Form
    {
        private int[,] __FinishedGrid = new int[9, 9];
        public int flag_howMuchLeft = 0;

        protected int CheckGrids(int[,] x)
        {
            int flag= 0;
            flag_howMuchLeft = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (x[i, y] == 0)
                    {
                        flag_howMuchLeft++;
                        continue;
                        
                    }
                    else
                    {
                        if (x[i, y] == __FinishedGrid[i, y])
                        {
                            continue;
                        }
                        else
                        {
                            flag = 1;
                        }
                    }
                    
                }
            }
            if (flag != 0)
            {
                return 0;
            }
            else
            {
                if (flag_howMuchLeft == 0)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        protected void ResetTextboxes()
        {
            string temp = "";
            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {
                    temp = "txt" + i.ToString() + y.ToString();
                    this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int[,] j = new int[9, 9];
            string temp = "";
            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {
                    temp = "txt" + i.ToString() + y.ToString();
                    if (this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Text == "")
                    {
                        j[i, y] = 0;
                    }
                    else
                    {
                        j[i, y] = int.Parse(this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Text);
                    }
                }
            }

            finalSteps(j);
        }

        protected void finalSteps(int[,] x)
        {
            int _final = CheckGrids(x);
            if (_final == 0)
            {
                //It's wrong
                MessageBox.Show("Ise kouspos");
            }
            else if (_final == 1)
            {
                //Finished and correct
                MessageBox.Show("Good job play harder next time");
            }
            else if (_final == 2)
            {
                //Correct so far
                MessageBox.Show(String.Format("Kepp up the good work, {0} only left", flag_howMuchLeft.ToString()));
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            ResetTextboxes();
            int[,] j = new int[9, 9];
            string temp = "";
            do
            {
                CreateFinishedGrid var = new CreateFinishedGrid();
                dugteam var1 = new dugteam();
                __FinishedGrid = var._CreateGrid();
                j = var1.dugarray(__FinishedGrid, 1);
            } while (j[0, 0] == 1 && j[0, 1] == 1);

            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {

                    temp = "txt" + i.ToString() + y.ToString();
                    if (j[i, y].ToString() == "0")
                    {
                        this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Text = "";
                    }
                    else
                    {
                        this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Text = j[i, y].ToString();
                        this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Enabled = false;
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetTextboxes();
            int[,] j = new int[9, 9];
            string temp = "";
            do
            {
                CreateFinishedGrid var = new CreateFinishedGrid();
                dugteam var1 = new dugteam();
                __FinishedGrid = var._CreateGrid();
                j = var1.dugarray(__FinishedGrid, 2);
            } while (j[0, 0] == 1 && j[0, 1] == 1);

            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {

                    temp = "txt" + i.ToString() + y.ToString();
                    if (j[i, y].ToString() == "0")
                    {
                        this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Text = "";
                    }
                    else
                    {
                        this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Text = j[i, y].ToString();
                        this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Enabled = false;
                    }


                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[,] j = new int[9, 9];
            string temp = "";
            ResetTextboxes();
            do
            {
                CreateFinishedGrid var = new CreateFinishedGrid();
                dugteam var1 = new dugteam();
                __FinishedGrid = var._CreateGrid();
                j = var1.dugarray(__FinishedGrid, 3);
            } while (j[0, 0] == 1 && j[0, 1] == 1);

            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {

                    temp = "txt" + i.ToString() + y.ToString();
                    if (j[i, y].ToString() == "0")
                    {
                        this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Text = "";
                    }
                    else
                    {
                        this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Text = j[i, y].ToString();
                        this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name.Contains(temp)).Enabled = false;
                    }
                }
            }
        }
    }
}
