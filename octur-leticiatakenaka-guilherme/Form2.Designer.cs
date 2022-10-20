namespace octur_leticiatakenaka_guilherme
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTodos = new System.Windows.Forms.RadioButton();
            this.btnMarcados = new System.Windows.Forms.RadioButton();
            this.marcacao = new System.Windows.Forms.Label();
            this.porpais = new System.Windows.Forms.Label();
            this.origem = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewDestinos = new System.Windows.Forms.DataGridView();
            this.cbOrigens = new System.Windows.Forms.ComboBox();
            this.cbPaises = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDestinos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTodos
            // 
            this.btnTodos.AutoSize = true;
            this.btnTodos.Location = new System.Drawing.Point(61, 250);
            this.btnTodos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(68, 24);
            this.btnTodos.TabIndex = 2;
            this.btnTodos.TabStop = true;
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.CheckedChanged += new System.EventHandler(this.btnTodos_CheckedChanged);
            // 
            // btnMarcados
            // 
            this.btnMarcados.AutoSize = true;
            this.btnMarcados.Location = new System.Drawing.Point(61, 284);
            this.btnMarcados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMarcados.Name = "btnMarcados";
            this.btnMarcados.Size = new System.Drawing.Size(145, 24);
            this.btnMarcados.TabIndex = 3;
            this.btnMarcados.TabStop = true;
            this.btnMarcados.Text = "Apenas marcados";
            this.btnMarcados.UseVisualStyleBackColor = true;
            this.btnMarcados.CheckedChanged += new System.EventHandler(this.btnMarcados_CheckedChanged);
            // 
            // marcacao
            // 
            this.marcacao.AutoSize = true;
            this.marcacao.Location = new System.Drawing.Point(57, 225);
            this.marcacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.marcacao.Name = "marcacao";
            this.marcacao.Size = new System.Drawing.Size(74, 20);
            this.marcacao.TabIndex = 4;
            this.marcacao.Text = "Marcação";
            // 
            // porpais
            // 
            this.porpais.AutoSize = true;
            this.porpais.Location = new System.Drawing.Point(57, 389);
            this.porpais.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.porpais.Name = "porpais";
            this.porpais.Size = new System.Drawing.Size(61, 20);
            this.porpais.TabIndex = 5;
            this.porpais.Text = "Por Pais";
            // 
            // origem
            // 
            this.origem.AutoSize = true;
            this.origem.Location = new System.Drawing.Point(57, 77);
            this.origem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.origem.Name = "origem";
            this.origem.Size = new System.Drawing.Size(175, 20);
            this.origem.TabIndex = 6;
            this.origem.Text = "Por aeroporto de origem";
            this.origem.Click += new System.EventHandler(this.origem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(57, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Gerenciar Trajeto";
            // 
            // dataGridViewDestinos
            // 
            this.dataGridViewDestinos.AllowUserToAddRows = false;
            this.dataGridViewDestinos.AllowUserToDeleteRows = false;
            this.dataGridViewDestinos.AllowUserToResizeColumns = false;
            this.dataGridViewDestinos.AllowUserToResizeRows = false;
            this.dataGridViewDestinos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDestinos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDestinos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(121)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(121)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDestinos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewDestinos.ColumnHeadersHeight = 35;
            this.dataGridViewDestinos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(224)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(126)))), ((int)(((byte)(112)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(121)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDestinos.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewDestinos.EnableHeadersVisualStyles = false;
            this.dataGridViewDestinos.Location = new System.Drawing.Point(302, 114);
            this.dataGridViewDestinos.MultiSelect = false;
            this.dataGridViewDestinos.Name = "dataGridViewDestinos";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDestinos.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewDestinos.RowHeadersVisible = false;
            this.dataGridViewDestinos.RowHeadersWidth = 25;
            this.dataGridViewDestinos.RowTemplate.Height = 25;
            this.dataGridViewDestinos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDestinos.Size = new System.Drawing.Size(566, 347);
            this.dataGridViewDestinos.TabIndex = 12;
            // 
            // cbOrigens
            // 
            this.cbOrigens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOrigens.FormattingEnabled = true;
            this.cbOrigens.Location = new System.Drawing.Point(61, 100);
            this.cbOrigens.Name = "cbOrigens";
            this.cbOrigens.Size = new System.Drawing.Size(197, 28);
            this.cbOrigens.TabIndex = 23;
            this.cbOrigens.SelectedIndexChanged += new System.EventHandler(this.paises_SelectedIndexChanged);
            // 
            // cbPaises
            // 
            this.cbPaises.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaises.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPaises.FormattingEnabled = true;
            this.cbPaises.Location = new System.Drawing.Point(61, 412);
            this.cbPaises.Name = "cbPaises";
            this.cbPaises.Size = new System.Drawing.Size(197, 28);
            this.cbPaises.TabIndex = 22;
            this.cbPaises.SelectedIndexChanged += new System.EventHandler(this.origens_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(922, 492);
            this.Controls.Add(this.cbOrigens);
            this.Controls.Add(this.cbPaises);
            this.Controls.Add(this.dataGridViewDestinos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.origem);
            this.Controls.Add(this.porpais);
            this.Controls.Add(this.marcacao);
            this.Controls.Add(this.btnMarcados);
            this.Controls.Add(this.btnTodos);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(126)))), ((int)(((byte)(112)))));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDestinos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton btnTodos;
        private System.Windows.Forms.RadioButton btnMarcados;
        private System.Windows.Forms.Label marcacao;
        private System.Windows.Forms.Label porpais;
        private System.Windows.Forms.Label origem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewDestinos;
        private System.Windows.Forms.ComboBox cbOrigens;
        private System.Windows.Forms.ComboBox cbPaises;
    }
}