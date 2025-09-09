namespace WinForms_DownloadFileAuto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTestar = new System.Windows.Forms.Button();
            this.dtgArquivos = new System.Windows.Forms.DataGridView();
            this.txtDiretorioDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colSequencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTestar
            // 
            this.btnTestar.Location = new System.Drawing.Point(647, 12);
            this.btnTestar.Name = "btnTestar";
            this.btnTestar.Size = new System.Drawing.Size(141, 42);
            this.btnTestar.TabIndex = 0;
            this.btnTestar.Text = "Testar";
            this.btnTestar.UseVisualStyleBackColor = true;
            this.btnTestar.Click += new System.EventHandler(this.btnTestar_Click);
            // 
            // dtgArquivos
            // 
            this.dtgArquivos.AllowUserToAddRows = false;
            this.dtgArquivos.AllowUserToDeleteRows = false;
            this.dtgArquivos.AllowUserToResizeColumns = false;
            this.dtgArquivos.AllowUserToResizeRows = false;
            this.dtgArquivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgArquivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequencia,
            this.colNome,
            this.colTotal});
            this.dtgArquivos.EnableHeadersVisualStyles = false;
            this.dtgArquivos.Location = new System.Drawing.Point(12, 75);
            this.dtgArquivos.Name = "dtgArquivos";
            this.dtgArquivos.RowHeadersVisible = false;
            this.dtgArquivos.Size = new System.Drawing.Size(776, 349);
            this.dtgArquivos.TabIndex = 1;
            // 
            // txtDiretorioDestino
            // 
            this.txtDiretorioDestino.Location = new System.Drawing.Point(12, 34);
            this.txtDiretorioDestino.Name = "txtDiretorioDestino";
            this.txtDiretorioDestino.Size = new System.Drawing.Size(605, 20);
            this.txtDiretorioDestino.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Diretório de destino";
            // 
            // colSequencia
            // 
            this.colSequencia.DataPropertyName = "Sequencia";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSequencia.DefaultCellStyle = dataGridViewCellStyle10;
            this.colSequencia.HeaderText = "Sequencia";
            this.colSequencia.MinimumWidth = 80;
            this.colSequencia.Name = "colSequencia";
            this.colSequencia.Width = 80;
            // 
            // colNome
            // 
            this.colNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNome.DataPropertyName = "Nome";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colNome.DefaultCellStyle = dataGridViewCellStyle11;
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle12;
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 100;
            this.colTotal.Name = "colTotal";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDiretorioDestino);
            this.Controls.Add(this.dtgArquivos);
            this.Controls.Add(this.btnTestar);
            this.Name = "Principal";
            this.Text = "Download File Auto";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestar;
        private System.Windows.Forms.DataGridView dtgArquivos;
        private System.Windows.Forms.TextBox txtDiretorioDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}

