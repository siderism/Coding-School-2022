namespace Session_07
{
    partial class GradeForm
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
            this.newGradeButton = new DevExpress.XtraEditors.SimpleButton();
            this.deleteGradeButton = new DevExpress.XtraEditors.SimpleButton();
            this.updateGradeButton = new DevExpress.XtraEditors.SimpleButton();
            this.closeButton = new DevExpress.XtraEditors.SimpleButton();
            this.gradesListBox = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradesListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(0, 1);
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
            this.labelControl1.Location = new System.Drawing.Point(490, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Student ID";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(490, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Course ID";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(490, 107);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Crade Value";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(570, 40);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 5;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(570, 72);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(100, 20);
            this.textEdit2.TabIndex = 6;
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(570, 107);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(100, 20);
            this.textEdit3.TabIndex = 7;
            // 
            // newGradeButton
            // 
            this.newGradeButton.Location = new System.Drawing.Point(467, 416);
            this.newGradeButton.Name = "newGradeButton";
            this.newGradeButton.Size = new System.Drawing.Size(75, 23);
            this.newGradeButton.TabIndex = 8;
            this.newGradeButton.Text = "New";
            this.newGradeButton.Click += new System.EventHandler(this.newGradeButton_Click);
            // 
            // deleteGradeButton
            // 
            this.deleteGradeButton.Location = new System.Drawing.Point(549, 415);
            this.deleteGradeButton.Name = "deleteGradeButton";
            this.deleteGradeButton.Size = new System.Drawing.Size(75, 23);
            this.deleteGradeButton.TabIndex = 9;
            this.deleteGradeButton.Text = "Delete";
            this.deleteGradeButton.Click += new System.EventHandler(this.deleteGradeButton_Click);
            // 
            // updateGradeButton
            // 
            this.updateGradeButton.Location = new System.Drawing.Point(631, 414);
            this.updateGradeButton.Name = "updateGradeButton";
            this.updateGradeButton.Size = new System.Drawing.Size(75, 23);
            this.updateGradeButton.TabIndex = 10;
            this.updateGradeButton.Text = "Update";
            this.updateGradeButton.Click += new System.EventHandler(this.updateGradeButton_Click);
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
            // gradesListBox
            // 
            this.gradesListBox.Location = new System.Drawing.Point(13, 36);
            this.gradesListBox.Name = "gradesListBox";
            this.gradesListBox.Size = new System.Drawing.Size(448, 403);
            this.gradesListBox.TabIndex = 12;
            this.gradesListBox.SelectedIndexChanged += new System.EventHandler(this.gradesListBox_SelectedIndexChanged);
            // 
            // GradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gradesListBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.updateGradeButton);
            this.Controls.Add(this.deleteGradeButton);
            this.Controls.Add(this.newGradeButton);
            this.Controls.Add(this.textEdit3);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Name = "GradeForm";
            this.Text = "GradeForm";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradesListBox)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton newGradeButton;
        private DevExpress.XtraEditors.SimpleButton deleteGradeButton;
        private DevExpress.XtraEditors.SimpleButton updateGradeButton;
        private DevExpress.XtraEditors.SimpleButton closeButton;
        private DevExpress.XtraEditors.ListBoxControl gradesListBox;
    }
}