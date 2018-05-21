namespace Cliente
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
            this.buttonEnviarMensagem = new System.Windows.Forms.Button();
            this.textBoxMensagem = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxConsoleLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonEnviarMensagem
            // 
            this.buttonEnviarMensagem.Enabled = false;
            this.buttonEnviarMensagem.Location = new System.Drawing.Point(581, 4);
            this.buttonEnviarMensagem.Name = "buttonEnviarMensagem";
            this.buttonEnviarMensagem.Size = new System.Drawing.Size(207, 34);
            this.buttonEnviarMensagem.TabIndex = 0;
            this.buttonEnviarMensagem.Text = "Enviar Mensagem";
            this.buttonEnviarMensagem.UseVisualStyleBackColor = true;
            this.buttonEnviarMensagem.Click += new System.EventHandler(this.buttonEnviarMensagem_Click);
            // 
            // textBoxMensagem
            // 
            this.textBoxMensagem.Enabled = false;
            this.textBoxMensagem.Location = new System.Drawing.Point(352, 12);
            this.textBoxMensagem.Name = "textBoxMensagem";
            this.textBoxMensagem.Size = new System.Drawing.Size(196, 20);
            this.textBoxMensagem.TabIndex = 1;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(148, 35);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Conectar ao Servidor";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxConsoleLog
            // 
            this.textBoxConsoleLog.Location = new System.Drawing.Point(352, 59);
            this.textBoxConsoleLog.Multiline = true;
            this.textBoxConsoleLog.Name = "textBoxConsoleLog";
            this.textBoxConsoleLog.ReadOnly = true;
            this.textBoxConsoleLog.Size = new System.Drawing.Size(436, 379);
            this.textBoxConsoleLog.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxConsoleLog);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxMensagem);
            this.Controls.Add(this.buttonEnviarMensagem);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEnviarMensagem;
        private System.Windows.Forms.TextBox textBoxMensagem;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxConsoleLog;
    }
}

