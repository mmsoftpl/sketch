namespace QPXdemoApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.depLabel = new System.Windows.Forms.Label();
            this.depTextBox = new System.Windows.Forms.TextBox();
            this.arrTextBox = new System.Windows.Forms.TextBox();
            this.arrLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.searchButton = new System.Windows.Forms.Button();
            this.apiKeyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.jsonTextBox = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.responseTabPage = new System.Windows.Forms.TabPage();
            this.jsonTabPage = new System.Windows.Forms.TabPage();
            this.responseTextBox = new System.Windows.Forms.TextBox();
            this.roundTripCheckBox = new System.Windows.Forms.CheckBox();
            this.panel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.responseTabPage.SuspendLayout();
            this.jsonTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.Location = new System.Drawing.Point(60, 9);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(958, 20);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.Text = "https://www.googleapis.com/qpxExpress/v1/trips/search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "POST url";
            // 
            // depLabel
            // 
            this.depLabel.AutoSize = true;
            this.depLabel.Location = new System.Drawing.Point(25, 42);
            this.depLabel.Name = "depLabel";
            this.depLabel.Size = new System.Drawing.Size(29, 13);
            this.depLabel.TabIndex = 2;
            this.depLabel.Text = "DEP";
            // 
            // depTextBox
            // 
            this.depTextBox.Location = new System.Drawing.Point(60, 42);
            this.depTextBox.Name = "depTextBox";
            this.depTextBox.Size = new System.Drawing.Size(100, 20);
            this.depTextBox.TabIndex = 3;
            this.depTextBox.Text = "POZ";
            // 
            // arrTextBox
            // 
            this.arrTextBox.Location = new System.Drawing.Point(210, 42);
            this.arrTextBox.Name = "arrTextBox";
            this.arrTextBox.Size = new System.Drawing.Size(100, 20);
            this.arrTextBox.TabIndex = 5;
            this.arrTextBox.Text = "KRK";
            // 
            // arrLabel
            // 
            this.arrLabel.AutoSize = true;
            this.arrLabel.Location = new System.Drawing.Point(175, 42);
            this.arrLabel.Name = "arrLabel";
            this.arrLabel.Size = new System.Drawing.Size(30, 13);
            this.arrLabel.TabIndex = 4;
            this.arrLabel.Text = "ARR";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(316, 42);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(29, 13);
            this.dateLabel.TabIndex = 6;
            this.dateLabel.Text = "DEP";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(360, 39);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 7;
            this.dateTimePicker.Value = new System.DateTime(2014, 9, 10, 0, 0, 0, 0);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(670, 34);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(348, 23);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Search! (max 20 results limit set)";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apiKeyTextBox.Location = new System.Drawing.Point(60, 71);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.Size = new System.Drawing.Size(958, 20);
            this.apiKeyTextBox.TabIndex = 13;
            this.apiKeyTextBox.Text = "AIzaSyBJKh5-qP0SFPfBVF5QpL05YkRC5-hwQ8Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "API Key";
            // 
            // jsonTextBox
            // 
            this.jsonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonTextBox.Location = new System.Drawing.Point(3, 3);
            this.jsonTextBox.Multiline = true;
            this.jsonTextBox.Name = "jsonTextBox";
            this.jsonTextBox.ReadOnly = true;
            this.jsonTextBox.Size = new System.Drawing.Size(1021, 438);
            this.jsonTextBox.TabIndex = 15;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.roundTripCheckBox);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.urlTextBox);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.depLabel);
            this.panel.Controls.Add(this.apiKeyTextBox);
            this.panel.Controls.Add(this.depTextBox);
            this.panel.Controls.Add(this.arrLabel);
            this.panel.Controls.Add(this.arrTextBox);
            this.panel.Controls.Add(this.dateLabel);
            this.panel.Controls.Add(this.dateTimePicker);
            this.panel.Controls.Add(this.searchButton);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1035, 105);
            this.panel.TabIndex = 16;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.responseTabPage);
            this.tabControl.Controls.Add(this.jsonTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 105);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1035, 470);
            this.tabControl.TabIndex = 17;
            // 
            // responseTabPage
            // 
            this.responseTabPage.Controls.Add(this.responseTextBox);
            this.responseTabPage.Location = new System.Drawing.Point(4, 22);
            this.responseTabPage.Name = "responseTabPage";
            this.responseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.responseTabPage.Size = new System.Drawing.Size(1027, 444);
            this.responseTabPage.TabIndex = 0;
            this.responseTabPage.Text = "Response";
            this.responseTabPage.UseVisualStyleBackColor = true;
            // 
            // jsonTabPage
            // 
            this.jsonTabPage.Controls.Add(this.jsonTextBox);
            this.jsonTabPage.Location = new System.Drawing.Point(4, 22);
            this.jsonTabPage.Name = "jsonTabPage";
            this.jsonTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.jsonTabPage.Size = new System.Drawing.Size(1027, 444);
            this.jsonTabPage.TabIndex = 1;
            this.jsonTabPage.Text = "JSON Response";
            this.jsonTabPage.UseVisualStyleBackColor = true;
            // 
            // responseTextBox
            // 
            this.responseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseTextBox.Location = new System.Drawing.Point(3, 3);
            this.responseTextBox.Multiline = true;
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.responseTextBox.Size = new System.Drawing.Size(1021, 438);
            this.responseTextBox.TabIndex = 0;
            // 
            // roundTripCheckBox
            // 
            this.roundTripCheckBox.AutoSize = true;
            this.roundTripCheckBox.Location = new System.Drawing.Point(576, 38);
            this.roundTripCheckBox.Name = "roundTripCheckBox";
            this.roundTripCheckBox.Size = new System.Drawing.Size(75, 17);
            this.roundTripCheckBox.TabIndex = 15;
            this.roundTripCheckBox.Text = "Round trip";
            this.roundTripCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 575);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.responseTabPage.ResumeLayout(false);
            this.responseTabPage.PerformLayout();
            this.jsonTabPage.ResumeLayout(false);
            this.jsonTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label depLabel;
        private System.Windows.Forms.TextBox depTextBox;
        private System.Windows.Forms.TextBox arrTextBox;
        private System.Windows.Forms.Label arrLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox apiKeyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jsonTextBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage responseTabPage;
        private System.Windows.Forms.TabPage jsonTabPage;
        private System.Windows.Forms.TextBox responseTextBox;
        private System.Windows.Forms.CheckBox roundTripCheckBox;
    }
}

