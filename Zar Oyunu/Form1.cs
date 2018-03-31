using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zar_Oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
         //neyse   
        }
        int p1top = 0;
        int p2top = 0;
        int p11 = 0;
        int p22 = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            p1top = 0;
            p2top = 0;
            if (radioButton1.Checked == true && radioButton2.Checked == true) { MessageBox.Show("Lütfen 1 tane çekim türü seçiniz", "Zar Oyunu", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (radioButton1.Checked == true)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                if (textBox1.Text != "") { toplu(Convert.ToInt32(textBox1.Text)); }
                else { toplu(10); }
                if (p1top < p2top)
                    MessageBox.Show("Kazanan 2.Oyuncu!!\nSonuç: 1.Oyuncu: " + p1top + "\n             2.Oyuncu: " + p2top, "Zar Oyunu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (p2top < p1top)
                    MessageBox.Show("Kazanan 1.Oyuncu!!\nSonuç: 1.Oyuncu: " + p1top + "\n             2.Oyuncu: " + p2top, "Zar Oyunu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (p2top == p1top)
                    MessageBox.Show("Kazanan Yoook!!\nSonuç: 1.Oyuncu: " + p1top + "\n             2.Oyuncu: " + p2top, "Zar Oyunu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (radioButton2.Checked == true)
            {
                teker();
                p11 = p1top + p11;
                p22 = p2top + p22;
                label5.Text = p11 + " - " + p22;

            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false) { radioButton1.Checked = true; toplu(10); }
        }

        void teker() {
            Random random = new Random();
            int p1point = random.Next(1, 6);
            int p2point = random.Next(1, 6);
            label1.Text = p1point + " - " + p2point;
            listBox1.Items.Add(p1point);
            listBox2.Items.Add(p2point);
            p1top = p1point;
            p2top = p2point;
            
        }

        void toplu(int tekrar) {
            
            Random random = new Random();
            for (int i = 0; i < tekrar; i++)
            {
                int p1point = random.Next(1, 6);
                int p2point = random.Next(1, 6);
                label1.Text = p1point + " - " + p2point;
                listBox1.Items.Add(p1point);
                listBox2.Items.Add(p2point);
                p1top = p1top + p1point;
                p2top = p2top + p2point;
            }
            label5.Text = p1top.ToString() + " - " + p2top.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { label4.Visible = true; label7.Visible = true; textBox1.Visible = true; }
            else if (radioButton1.Checked == false) { label4.Visible = false; label7.Visible = false; textBox1.Visible = false; }
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label1.Text = "0 - 0";
            label5.Text = "0 - 0";
            textBox1.Text = "";
            p1top = 0;
            p2top = 0;
            p11 = 0;
            p22 = 0;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            label7.Visible = false;
            label4.Visible = false;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label7.Visible = true;
                label4.Visible = true;
            }
            else { label7.Visible = false; label4.Visible = false; }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

            label7.Visible = false;
            label4.Visible = false;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label7.Visible = true;
                label4.Visible = true;
            }
            else { label7.Visible = false; label4.Visible = false; }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar);
            label7.Visible = false;
            label4.Visible = false;
            if (e.KeyChar == 8) {
                if (textBox1.Text == "") { }
                else
                {
                    object sayi;
                    string son;

                    sayi = textBox1.Text;

                    son = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

                    textBox1.Text = son;
                }
            }

        }
    }
}
