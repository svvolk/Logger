namespace LoggerClient.View
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this._txtCurrentType = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItemСurrentType = new DevExpress.XtraLayout.LayoutControlItem();
            this._txtLoggingType = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItemType = new DevExpress.XtraLayout.LayoutControlItem();
            this._memoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItemLogs = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._txtCurrentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemСurrentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._txtLoggingType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._memoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this._memoEdit);
            this.layoutControl1.Controls.Add(this._txtLoggingType);
            this.layoutControl1.Controls.Add(this._txtCurrentType);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemСurrentType,
            this.layoutControlItemType,
            this.layoutControlItemLogs});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 450);
            this.Root.TextVisible = false;
            // 
            // _txtCurrentType
            // 
            this._txtCurrentType.Location = new System.Drawing.Point(154, 12);
            this._txtCurrentType.Name = "_txtCurrentType";
            this._txtCurrentType.Size = new System.Drawing.Size(634, 20);
            this._txtCurrentType.StyleController = this.layoutControl1;
            this._txtCurrentType.TabIndex = 4;
            // 
            // layoutControlItemСurrentType
            // 
            this.layoutControlItemСurrentType.Control = this._txtCurrentType;
            this.layoutControlItemСurrentType.Enabled = false;
            this.layoutControlItemСurrentType.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemСurrentType.Name = "layoutControlItemСurrentType";
            this.layoutControlItemСurrentType.Size = new System.Drawing.Size(780, 24);
            this.layoutControlItemСurrentType.Text = "Текущий тип :";
            this.layoutControlItemСurrentType.TextSize = new System.Drawing.Size(138, 13);
            // 
            // _txtLoggingType
            // 
            this._txtLoggingType.Location = new System.Drawing.Point(154, 36);
            this._txtLoggingType.Name = "_txtLoggingType";
            this._txtLoggingType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._txtLoggingType.Size = new System.Drawing.Size(634, 20);
            this._txtLoggingType.StyleController = this.layoutControl1;
            this._txtLoggingType.TabIndex = 5;
            // 
            // layoutControlItemType
            // 
            this.layoutControlItemType.Control = this._txtLoggingType;
            this.layoutControlItemType.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemType.Name = "layoutControlItemType";
            this.layoutControlItemType.Size = new System.Drawing.Size(780, 24);
            this.layoutControlItemType.Text = "Просмотреть логи по типу:";
            this.layoutControlItemType.TextSize = new System.Drawing.Size(138, 13);
            // 
            // _memoEdit
            // 
            this._memoEdit.Location = new System.Drawing.Point(12, 60);
            this._memoEdit.Name = "_memoEdit";
            this._memoEdit.Size = new System.Drawing.Size(776, 378);
            this._memoEdit.StyleController = this.layoutControl1;
            this._memoEdit.TabIndex = 6;
            // 
            // layoutControlItemLogs
            // 
            this.layoutControlItemLogs.Control = this._memoEdit;
            this.layoutControlItemLogs.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItemLogs.Name = "layoutControlItemLogs";
            this.layoutControlItemLogs.Size = new System.Drawing.Size(780, 382);
            this.layoutControlItemLogs.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemLogs.TextVisible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Логирование";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._txtCurrentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemСurrentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._txtLoggingType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._memoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.MemoEdit _memoEdit;
        private DevExpress.XtraEditors.LookUpEdit _txtLoggingType;
        private DevExpress.XtraEditors.TextEdit _txtCurrentType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemСurrentType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemLogs;
    }
}

