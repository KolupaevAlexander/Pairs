using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pairs
{
    public partial class Extended : Form
    {
        public Extended(int size)
        {
            InitializeComponent();
            List<int> icons = CreateList(size);
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.BackColor = System.Drawing.Color.CornflowerBlue;
            panel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            panel.ColumnCount = size;
            for (int i = 0; i < panel.ColumnCount; i++)
                panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            panel.RowCount = size;
            for (int i = 0; i < panel.ColumnCount; i++)
                panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Location = new System.Drawing.Point(0, 0);
            panel.Size = new System.Drawing.Size(534, 450);
            panel.TabIndex = 0;
            int counter = 0;
            List<Label> list = new List<Label>();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Label newLab = new Label();
                    newLab.Dock = System.Windows.Forms.DockStyle.Fill;
                    newLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    newLab.TabIndex = counter;
                    newLab.Name = i.ToString()+j.ToString();
                    newLab.ForeColor = System.Drawing.Color.CornflowerBlue;

                    int randomNumber = random.Next(icons.Count);
                    newLab.Text = icons[randomNumber].ToString();
                    icons.RemoveAt(randomNumber);

                    //newLab.Font = new System.Drawing.Font("Wingdings", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
                    newLab.Click += new System.EventHandler(this.label1_Click);
                    panel.Controls.Add(newLab, i, j);
                    list.Add(newLab);
                    counter++;
                }

            Controls.Add(panel);
        }

        private void Extended_Load(object sender, EventArgs e)
        {

        }

        static List<int> CreateList(int size)
        {
            List<int> icons = new List<int>();
            for (int i = 0; i < size * size / 2; i++)
            {
                icons.Add(i);
                icons.Add(i);
            }
            return icons;
        }
        Random random = new Random();



        Label firstClicked = null;
        Label secondClicked = null;
        private void label1_Click(object sender, EventArgs e)
        {

          /* if (timer1.Enabled == true)
                return;*/

            Label clickedLabel = sender as Label;
            if (clickedLabel.ForeColor!=Color.Black)
                clickedLabel.ForeColor = Color.Black;
            else clickedLabel.ForeColor = Color.CornflowerBlue;
            /*
                        if (clickedLabel != null)
                        {
                            if (clickedLabel.ForeColor == Color.Black)
                                return;

                            if (firstClicked == null)
                            {
                                firstClicked = clickedLabel;
                                firstClicked.ForeColor = Color.Black;

                                return;
                            }
                        }

                        secondClicked = clickedLabel;
                        secondClicked.ForeColor = Color.Black;

                        //CheckForWinner();

                        if (firstClicked.Text == secondClicked.Text)
                        {
                            firstClicked = null;
                            secondClicked = null;
                            return;
                        }


                        timer1.Start();*/
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
        /*private void CheckForWinner()
        {
            foreach (Control control in panel.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }*/

    }
}
