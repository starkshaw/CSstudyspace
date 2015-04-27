using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace googleMapSample {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void view_button_Click(object sender, EventArgs e) {
			mapView.Navigate(new Uri(@"https://www.google.ie/maps/@" + double.Parse(long_box.Text) + "," + double.Parse(la_box.Text) + ",8z?hl=en-US"));
		}
	}
}
