namespace Hoofdform
{
    partial class InlogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InlogForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.textNaam = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textWachtwoord = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.buttonInloggen = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(138, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 201);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(122, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Gebruikersnaam:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(12, 245);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(97, 19);
            this.materialLabel3.TabIndex = 3;
            this.materialLabel3.Text = "Wachtwoord:";
            // 
            // textNaam
            // 
            this.textNaam.Depth = 0;
            this.textNaam.Hint = "";
            this.textNaam.Location = new System.Drawing.Point(138, 199);
            this.textNaam.MaxLength = 32767;
            this.textNaam.MouseState = MaterialSkin.MouseState.HOVER;
            this.textNaam.Name = "textNaam";
            this.textNaam.PasswordChar = '\0';
            this.textNaam.SelectedText = "";
            this.textNaam.SelectionLength = 0;
            this.textNaam.SelectionStart = 0;
            this.textNaam.Size = new System.Drawing.Size(196, 23);
            this.textNaam.TabIndex = 4;
            this.textNaam.TabStop = false;
            this.textNaam.UseSystemPasswordChar = false;
            // 
            // textWachtwoord
            // 
            this.textWachtwoord.Depth = 0;
            this.textWachtwoord.Hint = "";
            this.textWachtwoord.Location = new System.Drawing.Point(138, 243);
            this.textWachtwoord.MaxLength = 32767;
            this.textWachtwoord.MouseState = MaterialSkin.MouseState.HOVER;
            this.textWachtwoord.Name = "textWachtwoord";
            this.textWachtwoord.PasswordChar = '•';
            this.textWachtwoord.SelectedText = "";
            this.textWachtwoord.SelectionLength = 0;
            this.textWachtwoord.SelectionStart = 0;
            this.textWachtwoord.Size = new System.Drawing.Size(196, 23);
            this.textWachtwoord.TabIndex = 5;
            this.textWachtwoord.TabStop = false;
            this.textWachtwoord.UseSystemPasswordChar = false;
            // 
            // buttonInloggen
            // 
            this.buttonInloggen.AutoSize = true;
            this.buttonInloggen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonInloggen.Depth = 0;
            this.buttonInloggen.Icon = null;
            this.buttonInloggen.Location = new System.Drawing.Point(138, 282);
            this.buttonInloggen.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonInloggen.Name = "buttonInloggen";
            this.buttonInloggen.Primary = true;
            this.buttonInloggen.Size = new System.Drawing.Size(88, 36);
            this.buttonInloggen.TabIndex = 6;
            this.buttonInloggen.Text = "Inloggen";
            this.buttonInloggen.UseVisualStyleBackColor = true;
            this.buttonInloggen.Click += new System.EventHandler(this.buttonInloggen_Click);
            // 
            // InlogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 340);
            this.Controls.Add(this.buttonInloggen);
            this.Controls.Add(this.textWachtwoord);
            this.Controls.Add(this.textNaam);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "InlogForm";
            this.Text = "Inloggen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField textNaam;
        private MaterialSkin.Controls.MaterialSingleLineTextField textWachtwoord;
        private MaterialSkin.Controls.MaterialRaisedButton buttonInloggen;
    }
}