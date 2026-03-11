namespace SQLite
{
    partial class AddData
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
            button1 = new Button();
            prenom = new TextBox();
            nom = new TextBox();
            description = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(300, 367);
            button1.Name = "button1";
            button1.Size = new Size(300, 30);
            button1.TabIndex = 0;
            button1.Text = "Ajouter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // prenom
            // 
            prenom.Location = new Point(300, 94);
            prenom.Name = "prenom";
            prenom.PlaceholderText = "Prenom";
            prenom.Size = new Size(300, 27);
            prenom.TabIndex = 1;
            // 
            // nom
            // 
            nom.Location = new Point(300, 61);
            nom.Name = "nom";
            nom.PlaceholderText = "Nom";
            nom.Size = new Size(300, 27);
            nom.TabIndex = 2;
            // 
            // description
            // 
            description.Location = new Point(300, 127);
            description.Multiline = true;
            description.Name = "description";
            description.PlaceholderText = "Description";
            description.Size = new Size(300, 234);
            description.TabIndex = 3;
            // 
            // AddData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 453);
            Controls.Add(description);
            Controls.Add(nom);
            Controls.Add(prenom);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddData";
            Load += AddData_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox prenom;
        private TextBox nom;
        private TextBox description;
    }
}