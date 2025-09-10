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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTestar = new System.Windows.Forms.Button();
            this.dtgArquivos1 = new System.Windows.Forms.DataGridView();
            this.txtDiretorioDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgArquivos2 = new System.Windows.Forms.DataGridView();
            this.colSequencia2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSequencia1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivos2)).BeginInit();
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
            // dtgArquivos1
            // 
            this.dtgArquivos1.AllowUserToAddRows = false;
            this.dtgArquivos1.AllowUserToDeleteRows = false;
            this.dtgArquivos1.AllowUserToResizeColumns = false;
            this.dtgArquivos1.AllowUserToResizeRows = false;
            this.dtgArquivos1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgArquivos1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequencia1,
            this.colNome1,
            this.colTotal1});
            this.dtgArquivos1.EnableHeadersVisualStyles = false;
            this.dtgArquivos1.Location = new System.Drawing.Point(12, 75);
            this.dtgArquivos1.Name = "dtgArquivos1";
            this.dtgArquivos1.RowHeadersVisible = false;
            this.dtgArquivos1.Size = new System.Drawing.Size(776, 168);
            this.dtgArquivos1.TabIndex = 1;
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
            // dtgArquivos2
            // 
            this.dtgArquivos2.AllowUserToAddRows = false;
            this.dtgArquivos2.AllowUserToDeleteRows = false;
            this.dtgArquivos2.AllowUserToResizeColumns = false;
            this.dtgArquivos2.AllowUserToResizeRows = false;
            this.dtgArquivos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgArquivos2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequencia2,
            this.colNome2,
            this.colTotal2});
            this.dtgArquivos2.EnableHeadersVisualStyles = false;
            this.dtgArquivos2.Location = new System.Drawing.Point(12, 263);
            this.dtgArquivos2.Name = "dtgArquivos2";
            this.dtgArquivos2.RowHeadersVisible = false;
            this.dtgArquivos2.Size = new System.Drawing.Size(776, 158);
            this.dtgArquivos2.TabIndex = 4;
            // 
            // colSequencia2
            // 
            this.colSequencia2.DataPropertyName = "Sequencia";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSequencia2.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSequencia2.HeaderText = "Sequencia";
            this.colSequencia2.MinimumWidth = 80;
            this.colSequencia2.Name = "colSequencia2";
            this.colSequencia2.Width = 80;
            // 
            // colNome2
            // 
            this.colNome2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNome2.DataPropertyName = "Nome";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colNome2.DefaultCellStyle = dataGridViewCellStyle5;
            this.colNome2.HeaderText = "Nome";
            this.colNome2.Name = "colNome2";
            // 
            // colTotal2
            // 
            this.colTotal2.DataPropertyName = "Total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotal2.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTotal2.HeaderText = "Total";
            this.colTotal2.MinimumWidth = 100;
            this.colTotal2.Name = "colTotal2";
            // 
            // colSequencia1
            // 
            this.colSequencia1.DataPropertyName = "Sequencia";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSequencia1.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSequencia1.HeaderText = "Sequencia";
            this.colSequencia1.MinimumWidth = 80;
            this.colSequencia1.Name = "colSequencia1";
            this.colSequencia1.Width = 80;
            // 
            // colNome1
            // 
            this.colNome1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNome1.DataPropertyName = "Nome";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colNome1.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNome1.HeaderText = "Nome";
            this.colNome1.Name = "colNome1";
            // 
            // colTotal1
            // 
            this.colTotal1.DataPropertyName = "Total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotal1.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotal1.HeaderText = "Total";
            this.colTotal1.MinimumWidth = 100;
            this.colTotal1.Name = "colTotal1";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgArquivos2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDiretorioDestino);
            this.Controls.Add(this.dtgArquivos1);
            this.Controls.Add(this.btnTestar);
            this.Name = "Principal";
            this.Text = "Download File Auto";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivos2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestar;
        private System.Windows.Forms.DataGridView dtgArquivos1;
        private System.Windows.Forms.TextBox txtDiretorioDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgArquivos2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequencia1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequencia2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal2;
    }
}

