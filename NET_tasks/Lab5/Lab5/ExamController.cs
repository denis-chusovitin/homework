using System.Threading;

namespace Lab5
{
    public sealed class ExamController
    {
        private Dean Dean;
        private ExamView view;

        private void ExamStart()
        {
            Dean.ExamStart();
        }

        public void AddStudentToView(Student student, int mark)
        {
            view.AddStudent(student, mark);
        }

        public ExamController(ExamView view, int studentAmount)
        {
            Dean = new Dean(this);
            this.view = view;

            for (int i = 0; i < studentAmount; i++)
            {
                Student st = new Student(NameHelper.GetRandomName(), Dean);

                Thread studentThread = new Thread(st.PassExam);
                studentThread.Start();
            }

            ExamStart();
        }
    }
}
