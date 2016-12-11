using System.Windows.Forms;

namespace Lab5
{
    public partial class ProgressPresenterView : UserControl
    {
        private ExamView view;

        public void AddStudent()
        {
            int value = ExamProgress.Value + 1;

            if (value == ExamProgress.Maximum)
            {
                ExamProgress.Value = value;

                view.StopExam();
            }
            else
            {
                ExamProgress.Value = value + 1;
                ExamProgress.Value = value;
            }
        }

        public void Init(ExamView view, int studentAmount)
        {
            this.view = view;
            ExamProgress.Maximum = studentAmount;
        }

        public ProgressPresenterView()
        {
            InitializeComponent();
        }
    }
}
