namespace Trinomial
{
    partial class Form
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
            this.K_val = new System.Windows.Forms.TextBox();
            this.K_tag = new System.Windows.Forms.Label();
            this.S_tag = new System.Windows.Forms.Label();
            this.S_val = new System.Windows.Forms.TextBox();
            this.T_tag = new System.Windows.Forms.Label();
            this.T_val = new System.Windows.Forms.TextBox();
            this.sig_tag = new System.Windows.Forms.Label();
            this.Sig_val = new System.Windows.Forms.TextBox();
            this.r_tag = new System.Windows.Forms.Label();
            this.R_val = new System.Windows.Forms.TextBox();
            this.div_tag = new System.Windows.Forms.Label();
            this.Div_val = new System.Windows.Forms.TextBox();
            this.n_tag = new System.Windows.Forms.Label();
            this.N_val = new System.Windows.Forms.TextBox();
            this.amer_check = new System.Windows.Forms.RadioButton();
            this.Opt_type_box = new System.Windows.Forms.GroupBox();
            this.euro_check = new System.Windows.Forms.RadioButton();
            this.call_check = new System.Windows.Forms.RadioButton();
            this.put_check = new System.Windows.Forms.RadioButton();
            this.cal_button = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.output_list = new System.Windows.Forms.ListView();
            this.op_px = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.delta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gamma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.theta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Opt_type_box.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // K_val
            // 
            this.K_val.Location = new System.Drawing.Point(925, 31);
            this.K_val.Name = "K_val";
            this.K_val.Size = new System.Drawing.Size(100, 20);
            this.K_val.TabIndex = 0;
            // 
            // K_tag
            // 
            this.K_tag.AutoSize = true;
            this.K_tag.Location = new System.Drawing.Point(790, 33);
            this.K_tag.Name = "K_tag";
            this.K_tag.Size = new System.Drawing.Size(34, 13);
            this.K_tag.TabIndex = 1;
            this.K_tag.Text = "Strike";
            // 
            // S_tag
            // 
            this.S_tag.AutoSize = true;
            this.S_tag.Location = new System.Drawing.Point(790, 58);
            this.S_tag.Name = "S_tag";
            this.S_tag.Size = new System.Drawing.Size(57, 13);
            this.S_tag.TabIndex = 2;
            this.S_tag.Text = "Underlying";
            // 
            // S_val
            // 
            this.S_val.Location = new System.Drawing.Point(925, 55);
            this.S_val.Name = "S_val";
            this.S_val.Size = new System.Drawing.Size(100, 20);
            this.S_val.TabIndex = 3;
            // 
            // T_tag
            // 
            this.T_tag.AutoSize = true;
            this.T_tag.Location = new System.Drawing.Point(790, 82);
            this.T_tag.Name = "T_tag";
            this.T_tag.Size = new System.Drawing.Size(76, 13);
            this.T_tag.TabIndex = 4;
            this.T_tag.Text = "Term (in years)";
            // 
            // T_val
            // 
            this.T_val.Location = new System.Drawing.Point(925, 79);
            this.T_val.Name = "T_val";
            this.T_val.Size = new System.Drawing.Size(100, 20);
            this.T_val.TabIndex = 5;
            // 
            // sig_tag
            // 
            this.sig_tag.AutoSize = true;
            this.sig_tag.Location = new System.Drawing.Point(790, 106);
            this.sig_tag.Name = "sig_tag";
            this.sig_tag.Size = new System.Drawing.Size(92, 13);
            this.sig_tag.TabIndex = 6;
            this.sig_tag.Text = "Sigma (in decimal)";
            // 
            // Sig_val
            // 
            this.Sig_val.Location = new System.Drawing.Point(925, 103);
            this.Sig_val.Name = "Sig_val";
            this.Sig_val.Size = new System.Drawing.Size(100, 20);
            this.Sig_val.TabIndex = 7;
            // 
            // r_tag
            // 
            this.r_tag.AutoSize = true;
            this.r_tag.Location = new System.Drawing.Point(790, 130);
            this.r_tag.Name = "r_tag";
            this.r_tag.Size = new System.Drawing.Size(126, 13);
            this.r_tag.TabIndex = 8;
            this.r_tag.Text = "Risk-free rate (in decimal)";
            // 
            // R_val
            // 
            this.R_val.Location = new System.Drawing.Point(925, 127);
            this.R_val.Name = "R_val";
            this.R_val.Size = new System.Drawing.Size(100, 20);
            this.R_val.TabIndex = 9;
            // 
            // div_tag
            // 
            this.div_tag.AutoSize = true;
            this.div_tag.Location = new System.Drawing.Point(790, 154);
            this.div_tag.Name = "div_tag";
            this.div_tag.Size = new System.Drawing.Size(49, 13);
            this.div_tag.TabIndex = 10;
            this.div_tag.Text = "Dividend";
            this.div_tag.Click += new System.EventHandler(this.div_tag_Click);
            // 
            // Div_val
            // 
            this.Div_val.Location = new System.Drawing.Point(925, 151);
            this.Div_val.Name = "Div_val";
            this.Div_val.Size = new System.Drawing.Size(100, 20);
            this.Div_val.TabIndex = 11;
            // 
            // n_tag
            // 
            this.n_tag.AutoSize = true;
            this.n_tag.Location = new System.Drawing.Point(790, 178);
            this.n_tag.Name = "n_tag";
            this.n_tag.Size = new System.Drawing.Size(86, 13);
            this.n_tag.TabIndex = 12;
            this.n_tag.Text = "Number of Steps";
            // 
            // N_val
            // 
            this.N_val.Location = new System.Drawing.Point(925, 175);
            this.N_val.Name = "N_val";
            this.N_val.Size = new System.Drawing.Size(100, 20);
            this.N_val.TabIndex = 13;
            // 
            // amer_check
            // 
            this.amer_check.AutoSize = true;
            this.amer_check.Location = new System.Drawing.Point(6, 19);
            this.amer_check.Name = "amer_check";
            this.amer_check.Size = new System.Drawing.Size(69, 17);
            this.amer_check.TabIndex = 14;
            this.amer_check.TabStop = true;
            this.amer_check.Text = "American";
            this.amer_check.UseVisualStyleBackColor = true;
            // 
            // Opt_type_box
            // 
            this.Opt_type_box.Controls.Add(this.euro_check);
            this.Opt_type_box.Controls.Add(this.amer_check);
            this.Opt_type_box.Location = new System.Drawing.Point(793, 209);
            this.Opt_type_box.Name = "Opt_type_box";
            this.Opt_type_box.Size = new System.Drawing.Size(232, 50);
            this.Opt_type_box.TabIndex = 15;
            this.Opt_type_box.TabStop = false;
            this.Opt_type_box.Text = "Option Version";
            // 
            // euro_check
            // 
            this.euro_check.AutoSize = true;
            this.euro_check.Location = new System.Drawing.Point(132, 19);
            this.euro_check.Name = "euro_check";
            this.euro_check.Size = new System.Drawing.Size(71, 17);
            this.euro_check.TabIndex = 15;
            this.euro_check.TabStop = true;
            this.euro_check.Text = "European";
            this.euro_check.UseVisualStyleBackColor = true;
            // 
            // call_check
            // 
            this.call_check.AutoSize = true;
            this.call_check.Location = new System.Drawing.Point(6, 21);
            this.call_check.Name = "call_check";
            this.call_check.Size = new System.Drawing.Size(42, 17);
            this.call_check.TabIndex = 17;
            this.call_check.TabStop = true;
            this.call_check.Text = "Call";
            this.call_check.UseVisualStyleBackColor = true;
            this.call_check.CheckedChanged += new System.EventHandler(this.call_check_CheckedChanged);
            // 
            // put_check
            // 
            this.put_check.AutoSize = true;
            this.put_check.Location = new System.Drawing.Point(132, 21);
            this.put_check.Name = "put_check";
            this.put_check.Size = new System.Drawing.Size(41, 17);
            this.put_check.TabIndex = 16;
            this.put_check.TabStop = true;
            this.put_check.Text = "Put";
            this.put_check.UseVisualStyleBackColor = true;
            this.put_check.CheckedChanged += new System.EventHandler(this.put_check_CheckedChanged);
            // 
            // cal_button
            // 
            this.cal_button.Location = new System.Drawing.Point(793, 320);
            this.cal_button.Name = "cal_button";
            this.cal_button.Size = new System.Drawing.Size(112, 53);
            this.cal_button.TabIndex = 16;
            this.cal_button.Text = "Calculate";
            this.cal_button.UseVisualStyleBackColor = true;
            this.cal_button.Click += new System.EventHandler(this.cal_button_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(911, 320);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(114, 53);
            this.reset.TabIndex = 18;
            this.reset.Text = "Reset Output";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.put_check);
            this.groupBox1.Controls.Add(this.call_check);
            this.groupBox1.Location = new System.Drawing.Point(793, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 48);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option Type";
            // 
            // output_list
            // 
            this.output_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.op_px,
            this.delta,
            this.gamma,
            this.theta,
            this.vega,
            this.rho});
            this.output_list.HideSelection = false;
            this.output_list.Location = new System.Drawing.Point(26, 31);
            this.output_list.Name = "output_list";
            this.output_list.Size = new System.Drawing.Size(747, 342);
            this.output_list.TabIndex = 21;
            this.output_list.UseCompatibleStateImageBehavior = false;
            this.output_list.View = System.Windows.Forms.View.Details;
            this.output_list.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // op_px
            // 
            this.op_px.Text = "Option Price";
            this.op_px.Width = 93;
            // 
            // delta
            // 
            this.delta.Text = "Delta";
            this.delta.Width = 130;
            // 
            // gamma
            // 
            this.gamma.Text = "Gamma";
            this.gamma.Width = 138;
            // 
            // theta
            // 
            this.theta.Text = "Theta";
            this.theta.Width = 92;
            // 
            // vega
            // 
            this.vega.Text = "Vega";
            this.vega.Width = 108;
            // 
            // rho
            // 
            this.rho.Text = "Rho";
            this.rho.Width = 180;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 397);
            this.Controls.Add(this.output_list);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.cal_button);
            this.Controls.Add(this.Opt_type_box);
            this.Controls.Add(this.N_val);
            this.Controls.Add(this.n_tag);
            this.Controls.Add(this.Div_val);
            this.Controls.Add(this.div_tag);
            this.Controls.Add(this.R_val);
            this.Controls.Add(this.r_tag);
            this.Controls.Add(this.Sig_val);
            this.Controls.Add(this.sig_tag);
            this.Controls.Add(this.T_val);
            this.Controls.Add(this.T_tag);
            this.Controls.Add(this.S_val);
            this.Controls.Add(this.S_tag);
            this.Controls.Add(this.K_tag);
            this.Controls.Add(this.K_val);
            this.Name = "Form";
            this.Text = "Trinomial Calculator";
            this.Opt_type_box.ResumeLayout(false);
            this.Opt_type_box.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox K_val;
        private System.Windows.Forms.Label K_tag;
        private System.Windows.Forms.Label S_tag;
        private System.Windows.Forms.TextBox S_val;
        private System.Windows.Forms.Label T_tag;
        private System.Windows.Forms.TextBox T_val;
        private System.Windows.Forms.Label sig_tag;
        private System.Windows.Forms.TextBox Sig_val;
        private System.Windows.Forms.Label r_tag;
        private System.Windows.Forms.TextBox R_val;
        private System.Windows.Forms.Label div_tag;
        private System.Windows.Forms.TextBox Div_val;
        private System.Windows.Forms.Label n_tag;
        private System.Windows.Forms.TextBox N_val;
        private System.Windows.Forms.RadioButton amer_check;
        private System.Windows.Forms.GroupBox Opt_type_box;
        private System.Windows.Forms.RadioButton call_check;
        private System.Windows.Forms.RadioButton put_check;
        private System.Windows.Forms.RadioButton euro_check;
        private System.Windows.Forms.Button cal_button;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView output_list;
        private System.Windows.Forms.ColumnHeader op_px;
        private System.Windows.Forms.ColumnHeader delta;
        private System.Windows.Forms.ColumnHeader gamma;
        private System.Windows.Forms.ColumnHeader theta;
        private System.Windows.Forms.ColumnHeader vega;
        private System.Windows.Forms.ColumnHeader rho;
    }
}

