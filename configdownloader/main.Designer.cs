namespace configdownloader
{
    partial class main
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
            this.components = new System.ComponentModel.Container();
            this.inputAppID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.get = new System.Windows.Forms.Button();
            this.datagridConfigs = new System.Windows.Forms.DataGridView();
            this.RatesUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatesDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.appDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.currentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.datagridConfigs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configItemBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputAppID
            // 
            this.inputAppID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputAppID.Location = new System.Drawing.Point(55, 6);
            this.inputAppID.Name = "inputAppID";
            this.inputAppID.Size = new System.Drawing.Size(407, 20);
            this.inputAppID.TabIndex = 0;
            this.inputAppID.TextChanged += new System.EventHandler(this.inputAppID_TextChanged);
            this.inputAppID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inputAppID_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "AppID";
            // 
            // get
            // 
            this.get.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.get.Location = new System.Drawing.Point(468, 6);
            this.get.Name = "get";
            this.get.Size = new System.Drawing.Size(75, 20);
            this.get.TabIndex = 2;
            this.get.Text = "Get";
            this.get.UseVisualStyleBackColor = true;
            this.get.Click += new System.EventHandler(this.get_Click);
            // 
            // datagridConfigs
            // 
            this.datagridConfigs.AllowUserToAddRows = false;
            this.datagridConfigs.AllowUserToDeleteRows = false;
            this.datagridConfigs.AllowUserToResizeRows = false;
            this.datagridConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridConfigs.AutoGenerateColumns = false;
            this.datagridConfigs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.datagridConfigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridConfigs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.RatesUp,
            this.RatesDown});
            this.datagridConfigs.DataSource = this.configItemBindingSource;
            this.datagridConfigs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datagridConfigs.Location = new System.Drawing.Point(12, 32);
            this.datagridConfigs.MultiSelect = false;
            this.datagridConfigs.Name = "datagridConfigs";
            this.datagridConfigs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.datagridConfigs.RowHeadersVisible = false;
            this.datagridConfigs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridConfigs.Size = new System.Drawing.Size(531, 302);
            this.datagridConfigs.TabIndex = 3;
            this.datagridConfigs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // RatesUp
            // 
            this.RatesUp.DataPropertyName = "RatesUp";
            this.RatesUp.HeaderText = "RatesUp";
            this.RatesUp.Name = "RatesUp";
            // 
            // RatesDown
            // 
            this.RatesDown.DataPropertyName = "RatesDown";
            this.RatesDown.HeaderText = "RatesDown";
            this.RatesDown.Name = "RatesDown";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Config|*.vdf";
            // 
            // appDataGridViewTextBoxColumn
            // 
            this.appDataGridViewTextBoxColumn.DataPropertyName = "App";
            this.appDataGridViewTextBoxColumn.HeaderText = "App";
            this.appDataGridViewTextBoxColumn.Name = "appDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // configItemBindingSource
            // 
            this.configItemBindingSource.DataSource = typeof(configdownloader.ConfigItem);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 342);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(551, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // currentStatus
            // 
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Size = new System.Drawing.Size(128, 17);
            this.currentStatus.Text = "Connecting to Steam...";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 364);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.datagridConfigs);
            this.Controls.Add(this.get);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputAppID);
            this.Name = "main";
            this.Text = "Steam Controller Config Downloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_FormClosed);
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridConfigs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configItemBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputAppID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button get;
        private System.Windows.Forms.DataGridView datagridConfigs;
        private System.Windows.Forms.DataGridViewTextBoxColumn appDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource configItemBindingSource;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatesUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatesDown;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel currentStatus;
    }
}

