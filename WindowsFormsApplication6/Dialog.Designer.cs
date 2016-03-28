namespace WFA6
{
    partial class Dialog
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
this.Information = new System.Windows.Forms.TextBox();
this.label1 = new System.Windows.Forms.Label();
this.submit = new System.Windows.Forms.Button();
this.label2 = new System.Windows.Forms.Label();
this.source = new System.Windows.Forms.Label();
this.flow = new System.Windows.Forms.Label();
this.SuspendLayout();
// 
// Information
// 
this.Information.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
this.Information.Location = new System.Drawing.Point(70, 90);
this.Information.MaximumSize = new System.Drawing.Size(100, 20);
this.Information.MinimumSize = new System.Drawing.Size(100, 20);
this.Information.Name = "Information";
this.Information.Size = new System.Drawing.Size(100, 20);
this.Information.TabIndex = 0;
this.Information.Text = "Enter here";
this.Information.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.Information.TextChanged += new System.EventHandler(this.Information_TextChanged);
this.Information.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Information_KeyDown);
// 
// label1
// 
this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
this.label1.Location = new System.Drawing.Point(36, 37);
this.label1.MaximumSize = new System.Drawing.Size(170, 20);
this.label1.MinimumSize = new System.Drawing.Size(170, 20);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(170, 20);
this.label1.TabIndex = 1;
this.label1.Text = "Enter the weight of the edge:";
this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
// 
// submit
// 
this.submit.Location = new System.Drawing.Point(95, 118);
this.submit.Name = "submit";
this.submit.Size = new System.Drawing.Size(50, 30);
this.submit.TabIndex = 2;
this.submit.Text = "Submit";
this.submit.UseVisualStyleBackColor = true;
this.submit.Click += new System.EventHandler(this.Submit_Click);
// 
// label2
// 
this.label2.AutoSize = true;
this.label2.Location = new System.Drawing.Point(51, 41);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(140, 13);
this.label2.TabIndex = 3;
this.label2.Text = "Enter number of start vertex:";
this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
this.label2.Visible = false;
// 
// source
// 
this.source.Location = new System.Drawing.Point(48, 41);
this.source.Name = "source";
this.source.Size = new System.Drawing.Size(143, 19);
this.source.TabIndex = 4;
this.source.Text = "Source:";
this.source.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
this.source.Visible = false;
// 
// flow
// 
this.flow.Location = new System.Drawing.Point(70, 37);
this.flow.Name = "flow";
this.flow.Size = new System.Drawing.Size(100, 23);
this.flow.TabIndex = 5;
this.flow.Text = "Flow:";
this.flow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
this.flow.Visible = false;
// 
// Dialog
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.ClientSize = new System.Drawing.Size(234, 182);
this.Controls.Add(this.flow);
this.Controls.Add(this.source);
this.Controls.Add(this.label2);
this.Controls.Add(this.submit);
this.Controls.Add(this.label1);
this.Controls.Add(this.Information);
this.MaximumSize = new System.Drawing.Size(250, 220);
this.MinimumSize = new System.Drawing.Size(250, 220);
this.Name = "Dialog";
this.Text = "Dialog";
this.Load += new System.EventHandler(this.Dialog_Load);
this.ResumeLayout(false);
this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Information;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label source;
        private System.Windows.Forms.Label flow;
    
        public System.Windows.Forms.TextBox Info
        {
            get
            {
                return Information;
            }
            set
            {
                Information = value;
            }
        }
        public System.Windows.Forms.Label Label1
        {
            get
            {
                return label1;
            }
            set
            {
                label1 = value;
            }
        }
        public System.Windows.Forms.Label Label2
        {
            get
            {
                return label2;
            }
            set
            {
                label2 = value;
            }
        }
        public System.Windows.Forms.Button Submit
        {
            get
            {
                return submit;
            }
            set
            {
                submit = value;
            }
        }
        public System.Windows.Forms.Label Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }
        public System.Windows.Forms.Label Flow
        {
            get
            {
                return flow;
            }
            set
            {
                flow = value;
            }
        }
    }
}