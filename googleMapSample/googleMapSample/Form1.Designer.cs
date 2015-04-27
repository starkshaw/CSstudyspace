namespace googleMapSample {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.long_box = new System.Windows.Forms.TextBox();
			this.la_box = new System.Windows.Forms.TextBox();
			this.mapView = new System.Windows.Forms.WebBrowser();
			this.view_button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Longtitude";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Latitude";
			// 
			// long_box
			// 
			this.long_box.Location = new System.Drawing.Point(129, 38);
			this.long_box.Name = "long_box";
			this.long_box.Size = new System.Drawing.Size(100, 25);
			this.long_box.TabIndex = 2;
			// 
			// la_box
			// 
			this.la_box.Location = new System.Drawing.Point(129, 116);
			this.la_box.Name = "la_box";
			this.la_box.Size = new System.Drawing.Size(100, 25);
			this.la_box.TabIndex = 3;
			// 
			// mapView
			// 
			this.mapView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mapView.Location = new System.Drawing.Point(12, 202);
			this.mapView.MinimumSize = new System.Drawing.Size(20, 20);
			this.mapView.Name = "mapView";
			this.mapView.Size = new System.Drawing.Size(642, 467);
			this.mapView.TabIndex = 4;
			// 
			// view_button
			// 
			this.view_button.Location = new System.Drawing.Point(390, 83);
			this.view_button.Name = "view_button";
			this.view_button.Size = new System.Drawing.Size(75, 23);
			this.view_button.TabIndex = 5;
			this.view_button.Text = "View";
			this.view_button.UseVisualStyleBackColor = true;
			this.view_button.Click += new System.EventHandler(this.view_button_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 681);
			this.Controls.Add(this.view_button);
			this.Controls.Add(this.mapView);
			this.Controls.Add(this.la_box);
			this.Controls.Add(this.long_box);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox long_box;
		private System.Windows.Forms.TextBox la_box;
		private System.Windows.Forms.WebBrowser mapView;
		private System.Windows.Forms.Button view_button;
	}
}

