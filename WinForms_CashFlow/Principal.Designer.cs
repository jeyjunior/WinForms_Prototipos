namespace WinForms_CashFlow
{
    partial class Principal
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
            cboTipoTransacao = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cboEntidadeFinanceira = new ComboBox();
            label3 = new Label();
            dtpTransacao = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            dtpVencimento = new DateTimePicker();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            nValorUnitario = new NumericUpDown();
            nQuantidadeCotas = new NumericUpDown();
            nImposto = new NumericUpDown();
            nOutros = new NumericUpDown();
            nTotal = new NumericUpDown();
            btnRegistrar = new Button();
            btnAtualizar = new Button();
            dtgTransacao = new DataGridView();
            colPK_Transacao = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colAtivo = new DataGridViewTextBoxColumn();
            colQtdCotas = new DataGridViewTextBoxColumn();
            colValorUnitario = new DataGridViewTextBoxColumn();
            colImposto = new DataGridViewTextBoxColumn();
            colOutros = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            label10 = new Label();
            cboAtivo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nValorUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nQuantidadeCotas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nImposto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nOutros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgTransacao).BeginInit();
            SuspendLayout();
            // 
            // cboTipoTransacao
            // 
            cboTipoTransacao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoTransacao.FormattingEnabled = true;
            cboTipoTransacao.Location = new Point(12, 27);
            cboTipoTransacao.Name = "cboTipoTransacao";
            cboTipoTransacao.Size = new Size(120, 23);
            cboTipoTransacao.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 2;
            label1.Text = "Tipo Transacao";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(152, 9);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 4;
            label2.Text = "Entidade Financeira";
            // 
            // cboEntidadeFinanceira
            // 
            cboEntidadeFinanceira.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEntidadeFinanceira.FormattingEnabled = true;
            cboEntidadeFinanceira.Location = new Point(146, 27);
            cboEntidadeFinanceira.Name = "cboEntidadeFinanceira";
            cboEntidadeFinanceira.Size = new Size(251, 23);
            cboEntidadeFinanceira.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(547, 65);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 6;
            label3.Text = "Total (R$)";
            // 
            // dtpTransacao
            // 
            dtpTransacao.AllowDrop = true;
            dtpTransacao.Checked = false;
            dtpTransacao.CustomFormat = "";
            dtpTransacao.DropDownAlign = LeftRightAlignment.Right;
            dtpTransacao.Format = DateTimePickerFormat.Short;
            dtpTransacao.Location = new Point(547, 27);
            dtpTransacao.Name = "dtpTransacao";
            dtpTransacao.ShowCheckBox = true;
            dtpTransacao.Size = new Size(120, 23);
            dtpTransacao.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(547, 9);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 8;
            label4.Text = "Transacao";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(676, 9);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 10;
            label5.Text = "Vencimento";
            // 
            // dtpVencimento
            // 
            dtpVencimento.AllowDrop = true;
            dtpVencimento.Checked = false;
            dtpVencimento.Format = DateTimePickerFormat.Short;
            dtpVencimento.Location = new Point(676, 27);
            dtpVencimento.Name = "dtpVencimento";
            dtpVencimento.ShowCheckBox = true;
            dtpVencimento.Size = new Size(120, 23);
            dtpVencimento.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 65);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 12;
            label6.Text = "Quantidade cotas";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(146, 65);
            label7.Name = "label7";
            label7.Size = new Size(102, 15);
            label7.TabIndex = 14;
            label7.Text = "Valor Unitário (R$)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(277, 65);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 16;
            label8.Text = "Imposto (R$)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(408, 65);
            label9.Name = "label9";
            label9.Size = new Size(67, 15);
            label9.TabIndex = 18;
            label9.Text = "Outros (R$)";
            // 
            // nValorUnitario
            // 
            nValorUnitario.DecimalPlaces = 2;
            nValorUnitario.InterceptArrowKeys = false;
            nValorUnitario.Location = new Point(146, 83);
            nValorUnitario.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nValorUnitario.Name = "nValorUnitario";
            nValorUnitario.Size = new Size(120, 23);
            nValorUnitario.TabIndex = 19;
            nValorUnitario.TextAlign = HorizontalAlignment.Right;
            nValorUnitario.ThousandsSeparator = true;
            nValorUnitario.ValueChanged += CalcularTotal_ValueChanged;
            // 
            // nQuantidadeCotas
            // 
            nQuantidadeCotas.DecimalPlaces = 2;
            nQuantidadeCotas.InterceptArrowKeys = false;
            nQuantidadeCotas.Location = new Point(12, 83);
            nQuantidadeCotas.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nQuantidadeCotas.Name = "nQuantidadeCotas";
            nQuantidadeCotas.Size = new Size(120, 23);
            nQuantidadeCotas.TabIndex = 20;
            nQuantidadeCotas.TextAlign = HorizontalAlignment.Right;
            nQuantidadeCotas.ThousandsSeparator = true;
            nQuantidadeCotas.ValueChanged += CalcularTotal_ValueChanged;
            // 
            // nImposto
            // 
            nImposto.DecimalPlaces = 2;
            nImposto.InterceptArrowKeys = false;
            nImposto.Location = new Point(277, 83);
            nImposto.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nImposto.Name = "nImposto";
            nImposto.Size = new Size(120, 23);
            nImposto.TabIndex = 21;
            nImposto.TextAlign = HorizontalAlignment.Right;
            nImposto.ThousandsSeparator = true;
            nImposto.ValueChanged += CalcularTotal_ValueChanged;
            // 
            // nOutros
            // 
            nOutros.DecimalPlaces = 2;
            nOutros.InterceptArrowKeys = false;
            nOutros.Location = new Point(410, 83);
            nOutros.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nOutros.Name = "nOutros";
            nOutros.Size = new Size(120, 23);
            nOutros.TabIndex = 22;
            nOutros.TextAlign = HorizontalAlignment.Right;
            nOutros.ThousandsSeparator = true;
            nOutros.ValueChanged += CalcularTotal_ValueChanged;
            // 
            // nTotal
            // 
            nTotal.DecimalPlaces = 2;
            nTotal.InterceptArrowKeys = false;
            nTotal.Location = new Point(547, 83);
            nTotal.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nTotal.Name = "nTotal";
            nTotal.Size = new Size(249, 23);
            nTotal.TabIndex = 23;
            nTotal.TextAlign = HorizontalAlignment.Right;
            nTotal.ThousandsSeparator = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegistrar.Location = new Point(714, 116);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(81, 33);
            btnRegistrar.TabIndex = 24;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(12, 124);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(116, 33);
            btnAtualizar.TabIndex = 25;
            btnAtualizar.Text = "Atualizar Grid";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // dtgTransacao
            // 
            dtgTransacao.AllowUserToAddRows = false;
            dtgTransacao.AllowUserToDeleteRows = false;
            dtgTransacao.AllowUserToOrderColumns = true;
            dtgTransacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgTransacao.Columns.AddRange(new DataGridViewColumn[] { colPK_Transacao, colTipo, colAtivo, colQtdCotas, colValorUnitario, colImposto, colOutros, colTotal });
            dtgTransacao.Location = new Point(12, 163);
            dtgTransacao.Name = "dtgTransacao";
            dtgTransacao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgTransacao.Size = new Size(784, 275);
            dtgTransacao.TabIndex = 26;
            // 
            // colPK_Transacao
            // 
            colPK_Transacao.DataPropertyName = "PK_Transacao";
            colPK_Transacao.HeaderText = "PK_Transacao";
            colPK_Transacao.MinimumWidth = 90;
            colPK_Transacao.Name = "colPK_Transacao";
            colPK_Transacao.Resizable = DataGridViewTriState.False;
            colPK_Transacao.Width = 90;
            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.MinimumWidth = 70;
            colTipo.Name = "colTipo";
            colTipo.Resizable = DataGridViewTriState.False;
            colTipo.Width = 70;
            // 
            // colAtivo
            // 
            colAtivo.DataPropertyName = "Ativo";
            colAtivo.HeaderText = "Ativo";
            colAtivo.MinimumWidth = 80;
            colAtivo.Name = "colAtivo";
            colAtivo.Resizable = DataGridViewTriState.False;
            colAtivo.Width = 80;
            // 
            // colQtdCotas
            // 
            colQtdCotas.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colQtdCotas.DataPropertyName = "QtdCotas";
            colQtdCotas.HeaderText = "QtdCotas";
            colQtdCotas.MinimumWidth = 100;
            colQtdCotas.Name = "colQtdCotas";
            colQtdCotas.Resizable = DataGridViewTriState.False;
            // 
            // colValorUnitario
            // 
            colValorUnitario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colValorUnitario.DataPropertyName = "ValorUnitario";
            colValorUnitario.HeaderText = "ValorUnitario";
            colValorUnitario.MinimumWidth = 100;
            colValorUnitario.Name = "colValorUnitario";
            // 
            // colImposto
            // 
            colImposto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colImposto.DataPropertyName = "Imposto";
            colImposto.HeaderText = "Imposto";
            colImposto.MinimumWidth = 100;
            colImposto.Name = "colImposto";
            // 
            // colOutros
            // 
            colOutros.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colOutros.DataPropertyName = "Outros";
            colOutros.HeaderText = "Outros";
            colOutros.MinimumWidth = 100;
            colOutros.Name = "colOutros";
            // 
            // colTotal
            // 
            colTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTotal.DataPropertyName = "Total";
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 100;
            colTotal.Name = "colTotal";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(416, 9);
            label10.Name = "label10";
            label10.Size = new Size(35, 15);
            label10.TabIndex = 28;
            label10.Text = "Ativo";
            // 
            // cboAtivo
            // 
            cboAtivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAtivo.FormattingEnabled = true;
            cboAtivo.Location = new Point(410, 27);
            cboAtivo.Name = "cboAtivo";
            cboAtivo.Size = new Size(120, 23);
            cboAtivo.TabIndex = 27;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 450);
            Controls.Add(label10);
            Controls.Add(cboAtivo);
            Controls.Add(dtgTransacao);
            Controls.Add(btnAtualizar);
            Controls.Add(btnRegistrar);
            Controls.Add(nTotal);
            Controls.Add(nOutros);
            Controls.Add(nImposto);
            Controls.Add(nQuantidadeCotas);
            Controls.Add(nValorUnitario);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dtpVencimento);
            Controls.Add(label4);
            Controls.Add(dtpTransacao);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cboEntidadeFinanceira);
            Controls.Add(label1);
            Controls.Add(cboTipoTransacao);
            Name = "Principal";
            Text = "Principal";
            Load += Principal_Load;
            ((System.ComponentModel.ISupportInitialize)nValorUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)nQuantidadeCotas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nImposto).EndInit();
            ((System.ComponentModel.ISupportInitialize)nOutros).EndInit();
            ((System.ComponentModel.ISupportInitialize)nTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgTransacao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cboTipoTransacao;
        private Label label1;
        private Label label2;
        private ComboBox cboEntidadeFinanceira;
        private Label label3;
        private DateTimePicker dtpTransacao;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpVencimento;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private NumericUpDown nValorUnitario;
        private NumericUpDown nQuantidadeCotas;
        private NumericUpDown nImposto;
        private NumericUpDown nOutros;
        private NumericUpDown nTotal;
        private Button btnRegistrar;
        private Button btnAtualizar;
        private DataGridView dtgTransacao;
        private DataGridViewTextBoxColumn colPK_Transacao;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colAtivo;
        private DataGridViewTextBoxColumn colQtdCotas;
        private DataGridViewTextBoxColumn colValorUnitario;
        private DataGridViewTextBoxColumn colImposto;
        private DataGridViewTextBoxColumn colOutros;
        private DataGridViewTextBoxColumn colTotal;
        private Label label10;
        private ComboBox cboAtivo;
    }
}
