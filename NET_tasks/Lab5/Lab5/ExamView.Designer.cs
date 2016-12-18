namespace Lab5
{
    partial class ExamView
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
            this.StudentList = new System.Windows.Forms.ListBox();
            this.ExamStatus = new System.Windows.Forms.Label();
            this.ProgressPresenter = new Lab5.ProgressPresenterView();
            this.SuspendLayout();
            // 
            // StudentList
            // 
            this.StudentList.FormattingEnabled = true;
            this.StudentList.Location = new System.Drawing.Point(12, 12);
            this.StudentList.Name = "StudentList";
            this.StudentList.Size = new System.Drawing.Size(147, 251);
            this.StudentList.TabIndex = 0;
            // 
            // ExamStatus
            // 
            this.ExamStatus.AutoSize = true;
            this.ExamStatus.Location = new System.Drawing.Point(174, 12);
            this.ExamStatus.Name = "ExamStatus";
            this.ExamStatus.Size = new System.Drawing.Size(125, 13);
            this.ExamStatus.TabIndex = 1;
            this.ExamStatus.Text = "Статус экзамена: Идет";
            // 
            // ProgressPresenter
            // 
            this.ProgressPresenter.Location = new System.Drawing.Point(168, 28);
            this.ProgressPresenter.Name = "ProgressPresenter";
            this.ProgressPresenter.Size = new System.Drawing.Size(185, 41);
            this.ProgressPresenter.TabIndex = 3;
            // 
            // ExamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 273);
            this.Controls.Add(this.ProgressPresenter);
            this.Controls.Add(this.ExamStatus);
            this.Controls.Add(this.StudentList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExamView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox StudentList;
        private System.Windows.Forms.Label ExamStatus;
        private ProgressPresenterView ProgressPresenter;
    }
}

