namespace WinForms_MergeFiles
{
    partial class Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.progress = new System.Windows.Forms.ProgressBar();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTituloDiretorioDestino = new System.Windows.Forms.Label();
            this.txtDiretorioDestino = new System.Windows.Forms.TextBox();
            this.btnDiretorioDestino = new System.Windows.Forms.Button();
            this.txtArquivos = new System.Windows.Forms.TextBox();
            this.lblTituloArquivos = new System.Windows.Forms.Label();
            this.btnSelecionarArquivos = new System.Windows.Forms.Button();
            this.lblStatusArquivos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTituloLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblStatusLog = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progress.Location = new System.Drawing.Point(0, 457);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(372, 23);
            this.progress.TabIndex = 7;
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(295, 414);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(65, 35);
            this.btnMerge.TabIndex = 8;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(224, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(65, 35);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTituloDiretorioDestino
            // 
            this.lblTituloDiretorioDestino.AutoSize = true;
            this.lblTituloDiretorioDestino.Location = new System.Drawing.Point(12, 9);
            this.lblTituloDiretorioDestino.Name = "lblTituloDiretorioDestino";
            this.lblTituloDiretorioDestino.Size = new System.Drawing.Size(86, 13);
            this.lblTituloDiretorioDestino.TabIndex = 10;
            this.lblTituloDiretorioDestino.Text = "Diretório destino:";
            // 
            // txtDiretorioDestino
            // 
            this.txtDiretorioDestino.Location = new System.Drawing.Point(15, 25);
            this.txtDiretorioDestino.Name = "txtDiretorioDestino";
            this.txtDiretorioDestino.Size = new System.Drawing.Size(261, 20);
            this.txtDiretorioDestino.TabIndex = 11;
            // 
            // btnDiretorioDestino
            // 
            this.btnDiretorioDestino.Location = new System.Drawing.Point(282, 22);
            this.btnDiretorioDestino.Name = "btnDiretorioDestino";
            this.btnDiretorioDestino.Size = new System.Drawing.Size(80, 26);
            this.btnDiretorioDestino.TabIndex = 12;
            this.btnDiretorioDestino.Tag = "";
            this.btnDiretorioDestino.Text = "Selecionar";
            this.btnDiretorioDestino.UseVisualStyleBackColor = true;
            this.btnDiretorioDestino.Click += new System.EventHandler(this.btnDiretorioDestino_Click);
            // 
            // txtArquivos
            // 
            this.txtArquivos.Location = new System.Drawing.Point(15, 77);
            this.txtArquivos.Multiline = true;
            this.txtArquivos.Name = "txtArquivos";
            this.txtArquivos.Size = new System.Drawing.Size(345, 126);
            this.txtArquivos.TabIndex = 14;
            // 
            // lblTituloArquivos
            // 
            this.lblTituloArquivos.AutoSize = true;
            this.lblTituloArquivos.Location = new System.Drawing.Point(12, 61);
            this.lblTituloArquivos.Name = "lblTituloArquivos";
            this.lblTituloArquivos.Size = new System.Drawing.Size(107, 13);
            this.lblTituloArquivos.TabIndex = 15;
            this.lblTituloArquivos.Text = "Arquivos para merge:";
            // 
            // btnSelecionarArquivos
            // 
            this.btnSelecionarArquivos.Location = new System.Drawing.Point(234, 209);
            this.btnSelecionarArquivos.Name = "btnSelecionarArquivos";
            this.btnSelecionarArquivos.Size = new System.Drawing.Size(126, 26);
            this.btnSelecionarArquivos.TabIndex = 16;
            this.btnSelecionarArquivos.Tag = "";
            this.btnSelecionarArquivos.Text = "Selecionar Arquivos";
            this.btnSelecionarArquivos.UseVisualStyleBackColor = true;
            this.btnSelecionarArquivos.Click += new System.EventHandler(this.btnSelecionarArquivos_Click);
            // 
            // lblStatusArquivos
            // 
            this.lblStatusArquivos.AutoSize = true;
            this.lblStatusArquivos.Location = new System.Drawing.Point(21, 209);
            this.lblStatusArquivos.Name = "lblStatusArquivos";
            this.lblStatusArquivos.Size = new System.Drawing.Size(43, 13);
            this.lblStatusArquivos.TabIndex = 17;
            this.lblStatusArquivos.Text = "Total: 0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(15, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 10);
            this.panel1.TabIndex = 18;
            // 
            // lblTituloLog
            // 
            this.lblTituloLog.AutoSize = true;
            this.lblTituloLog.Location = new System.Drawing.Point(12, 266);
            this.lblTituloLog.Name = "lblTituloLog";
            this.lblTituloLog.Size = new System.Drawing.Size(29, 13);
            this.lblTituloLog.TabIndex = 20;
            this.lblTituloLog.Text = "LOG";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(15, 282);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(345, 126);
            this.txtLog.TabIndex = 19;
            // 
            // lblStatusLog
            // 
            this.lblStatusLog.AutoSize = true;
            this.lblStatusLog.Location = new System.Drawing.Point(20, 414);
            this.lblStatusLog.Name = "lblStatusLog";
            this.lblStatusLog.Size = new System.Drawing.Size(43, 13);
            this.lblStatusLog.TabIndex = 21;
            this.lblStatusLog.Text = "Total: 0";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(153, 414);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(65, 35);
            this.btnLimpar.TabIndex = 22;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 480);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.lblStatusLog);
            this.Controls.Add(this.lblTituloLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStatusArquivos);
            this.Controls.Add(this.btnSelecionarArquivos);
            this.Controls.Add(this.lblTituloArquivos);
            this.Controls.Add(this.txtArquivos);
            this.Controls.Add(this.btnDiretorioDestino);
            this.Controls.Add(this.txtDiretorioDestino);
            this.Controls.Add(this.lblTituloDiretorioDestino);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.progress);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTituloDiretorioDestino;
        private System.Windows.Forms.TextBox txtDiretorioDestino;
        private System.Windows.Forms.Button btnDiretorioDestino;
        private System.Windows.Forms.TextBox txtArquivos;
        private System.Windows.Forms.Label lblTituloArquivos;
        private System.Windows.Forms.Button btnSelecionarArquivos;
        private System.Windows.Forms.Label lblStatusArquivos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTituloLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblStatusLog;
        private System.Windows.Forms.Button btnLimpar;
    }
}

