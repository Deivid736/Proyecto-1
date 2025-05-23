namespace ProyectoFinal1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            txtTema = new TextBox();
            btnInvestigar = new Button();
            lblEstado = new Label();
            txtResultado = new RichTextBox();
            SuspendLayout();
            // 
            // txtTema
            // 
            txtTema.BackColor = SystemColors.ScrollBar;
            txtTema.Location = new Point(258, 55);
            txtTema.Name = "txtTema";
            txtTema.Size = new Size(249, 23);
            txtTema.TabIndex = 0;
            // 
            // btnInvestigar
            // 
            btnInvestigar.BackColor = SystemColors.ActiveBorder;
            btnInvestigar.Location = new Point(335, 99);
            btnInvestigar.Name = "btnInvestigar";
            btnInvestigar.Size = new Size(75, 23);
            btnInvestigar.TabIndex = 1;
            btnInvestigar.Text = "Buscar";
            btnInvestigar.UseVisualStyleBackColor = false;
            btnInvestigar.Click += btnInvestigar_Click;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(308, 125);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 15);
            lblEstado.TabIndex = 2;
            // 
            // txtResultado
            // 
            txtResultado.BackColor = SystemColors.ActiveCaption;
            txtResultado.Dock = DockStyle.Bottom;
            txtResultado.Location = new Point(0, 178);
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtResultado.Size = new Size(757, 220);
            txtResultado.TabIndex = 3;
            txtResultado.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(757, 398);
            Controls.Add(txtResultado);
            Controls.Add(lblEstado);
            Controls.Add(btnInvestigar);
            Controls.Add(txtTema);
            Name = "MainForm";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTema;
        private Button btnInvestigar;
        private Label lblEstado;
        private RichTextBox txtResultado;
    }
}
