namespace ClienteGUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.textBoxPuerto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxMensaje = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.conversacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(32, 30);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(159, 20);
            this.textBoxIp.TabIndex = 0;
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(50, 10);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(56, 13);
            this.lblIp.TabIndex = 1;
            this.lblIp.Text = "Ip servidor";
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Location = new System.Drawing.Point(283, 14);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(38, 13);
            this.lblPuerto.TabIndex = 2;
            this.lblPuerto.Text = "Puerto";
            // 
            // textBoxPuerto
            // 
            this.textBoxPuerto.Location = new System.Drawing.Point(273, 30);
            this.textBoxPuerto.Name = "textBoxPuerto";
            this.textBoxPuerto.Size = new System.Drawing.Size(100, 20);
            this.textBoxPuerto.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxMensaje
            // 
            this.textBoxMensaje.Location = new System.Drawing.Point(34, 76);
            this.textBoxMensaje.Name = "textBoxMensaje";
            this.textBoxMensaje.Size = new System.Drawing.Size(238, 20);
            this.textBoxMensaje.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(417, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // conversacion
            // 
            this.conversacion.Location = new System.Drawing.Point(37, 122);
            this.conversacion.Multiline = true;
            this.conversacion.Name = "conversacion";
            this.conversacion.Size = new System.Drawing.Size(366, 128);
            this.conversacion.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "mensaje";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.conversacion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxMensaje);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPuerto);
            this.Controls.Add(this.lblPuerto);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.textBoxIp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.TextBox textBoxPuerto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxMensaje;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox conversacion;
        private System.Windows.Forms.Label label1;
    }
}

