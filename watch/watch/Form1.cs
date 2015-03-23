using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace watch {
	public partial class Form1 : Form {

		int count = 0;

		public Form1() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			timer1.Start();
			if (timer1.Enabled == false) {
				button1.Enabled = true;
				button2.Enabled = false;
				button3.Enabled = false;
				button4.Enabled = false;
			} else {
				button1.Enabled = false;
				button2.Enabled = true;
				button3.Enabled = true;
				button4.Enabled = true;
			}
		}

		private void Form_Load(object sender, EventArgs e) {
			label1.Text = "0";
			if (timer1.Enabled == false) {
				button1.Enabled = true;
				button2.Enabled = false;
				button3.Enabled = false;
				button4.Enabled = false;
			} else {
				button2.Enabled = true;
				button3.Enabled = true;
				button4.Enabled = true;
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			timer1.Stop();
			label1.Text = count.ToString();
			button1.Enabled = true;
			button3.Enabled = false;
			button2.Enabled = false;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			count++;
			label1.Text = count.ToString();
		}

		private void button3_Click(object sender, EventArgs e) {
			if (timer1.Enabled == true) {
				textBox1.AppendText(count.ToString() + "\n");
			}
		}

		private void button4_Click(object sender, EventArgs e) {
			timer1.Stop();
			count = 0;
			label1.Text=count.ToString();
			textBox1.Clear();
			if (timer1.Enabled == false) {
				button1.Enabled = true;
				button2.Enabled = false;
				button3.Enabled = false;
				button4.Enabled = false;
			} else {
				button2.Enabled = true;
				button3.Enabled = true;
				button4.Enabled = true;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {

		}
	}
}
