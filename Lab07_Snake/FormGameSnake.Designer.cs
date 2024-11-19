namespace Lab07_Snake
{
    partial class FormGameSnake
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGame
            // 
            this.pictureBoxGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxGame.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGame.Name = "pictureBoxGame";
            this.pictureBoxGame.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxGame.TabIndex = 0;
            this.pictureBoxGame.TabStop = false;
            this.pictureBoxGame.SizeChanged += new System.EventHandler(this.PictureBoxGame_SizeChanged);
            // 
            // FormGameSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxGame);
            this.Name = "FormGameSnake";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGameSnake_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGame;
    }
}

