using System;
using System.Windows.Forms;

namespace Lab5
{
    public partial class ExamView : Form, IExamView
    {
        public void AddStudent(Student st, int mark)
        {
            var action = (Action)(() => {
                StudentList.Items.Add(string.Format("{0}, оценка {1}", st.Name, mark));
                ProgressPresenter.AddStudent();
            });

            if (StudentList.InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }    
        }

        public void StopExam()
        {
            ExamStatus.Text = "Статус эзкамена: Завершен";
        }

        public ExamView(int studentAmount)
        {
            InitializeComponent();

            ProgressPresenter.Init(this, studentAmount);
        }

        private void ProgressPresenterViewLoad(object sender, EventArgs e)
        {

        }
    }
}
