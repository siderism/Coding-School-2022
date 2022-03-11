namespace Session_07
{
    partial class ProfessorForm
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
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.loadButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.newProfessorButton = new DevExpress.XtraEditors.SimpleButton();
            this.deleteProfessorButton = new DevExpress.XtraEditors.SimpleButton();
            this.updateProfessorButton = new DevExpress.XtraEditors.SimpleButton();
            this.closeButton = new DevExpress.XtraEditors.SimpleButton();
            this.professorsListBox = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.professorsListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(-1, 1);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(81, 1);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(515, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Name";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(515, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Age";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(515, 87);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Rank";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(548, 32);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 5;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(548, 58);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(40, 20);
            this.textEdit2.TabIndex = 6;
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(548, 84);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(100, 20);
            this.textEdit3.TabIndex = 7;
            // 
            // newProfessorButton
            // 
            this.newProfessorButton.Location = new System.Drawing.Point(467, 415);
            this.newProfessorButton.Name = "newProfessorButton";
            this.newProfessorButton.Size = new System.Drawing.Size(75, 23);
            this.newProfessorButton.TabIndex = 8;
            this.newProfessorButton.Text = "New";
            this.newProfessorButton.Click += new System.EventHandler(this.newProfessorButton_Click);
            // 
            // deleteProfessorButton
            // 
            this.deleteProfessorButton.Location = new System.Drawing.Point(549, 415);
            this.deleteProfessorButton.Name = "deleteProfessorButton";
            this.deleteProfessorButton.Size = new System.Drawing.Size(75, 23);
            this.deleteProfessorButton.TabIndex = 9;
            this.deleteProfessorButton.Text = "Delete";
            this.deleteProfessorButton.Click += new System.EventHandler(this.deleteProfessorButton_Click);
            // 
            // updateProfessorButton
            // 
            this.updateProfessorButton.Location = new System.Drawing.Point(631, 415);
            this.updateProfessorButton.Name = "updateProfessorButton";
            this.updateProfessorButton.Size = new System.Drawing.Size(75, 23);
            this.updateProfessorButton.TabIndex = 10;
            this.updateProfessorButton.Text = "Update";
            this.updateProfessorButton.Click += new System.EventHandler(this.updateProfessorButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(713, 415);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // professorsListBox
            // 
            this.professorsListBox.Location = new System.Drawing.Point(13, 31);
            this.professorsListBox.Name = "professorsListBox";
            this.professorsListBox.Size = new System.Drawing.Size(448, 407);
            this.professorsListBox.TabIndex = 12;
            this.professorsListBox.SelectedIndexChanged += new System.EventHandler(this.professorsListBox_SelectedIndexChanged);
            // 
            // ProfessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.professorsListBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.updateProfessorButton);
            this.Controls.Add(this.deleteProfessorButton);
            this.Controls.Add(this.newProfessorButton);
            this.Controls.Add(this.textEdit3);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Name = "ProfessorForm";
            this.Text = "ProfessorForm";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.professorsListBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.SimpleButton loadButton;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.SimpleButton newProfessorButton;
        private DevExpress.XtraEditors.SimpleButton deleteProfessorButton;
        private DevExpress.XtraEditors.SimpleButton updateProfessorButton;
        private DevExpress.XtraEditors.SimpleButton closeButton;
        private DevExpress.XtraEditors.ListBoxControl professorsListBox;
    }
}