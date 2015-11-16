namespace Generador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.windows = new System.Windows.Forms.TextBox();
            this.hadoop = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblproceso = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(149, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dirección IP de Hadoop";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(96, 136);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(232, 13);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Dirección de la Carpeta donde guardar el JSON";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dirección de la Carpeta donde guardar el JSON en Hadoop";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(118, 30);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(184, 20);
            this.ip.TabIndex = 4;
            // 
            // windows
            // 
            this.windows.Location = new System.Drawing.Point(118, 99);
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(184, 20);
            this.windows.TabIndex = 5;
            // 
            // hadoop
            // 
            this.hadoop.Location = new System.Drawing.Point(118, 175);
            this.hadoop.Name = "hadoop";
            this.hadoop.Size = new System.Drawing.Size(184, 20);
            this.hadoop.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "Empezar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblproceso
            // 
            this.lblproceso.AutoSize = true;
            this.lblproceso.Location = new System.Drawing.Point(12, 314);
            this.lblproceso.Name = "lblproceso";
            this.lblproceso.Size = new System.Drawing.Size(49, 13);
            this.lblproceso.TabIndex = 9;
            this.lblproceso.Text = "Progreso";
            this.lblproceso.Click += new System.EventHandler(this.lblproceso_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(118, 304);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(241, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(470, 351);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblproceso);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hadoop);
            this.Controls.Add(this.windows);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Generador de JSON";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox windows;
        private System.Windows.Forms.TextBox hadoop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblproceso;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

