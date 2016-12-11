using System.Threading;

namespace Lab5
{
    public sealed class ExamController
    {
        private Dean Dean;

        private void ExamStart()
        {
            Dean.ExamStart();
        }

        public ExamController(Dean dean, int studentAmount)
        {
            Dean = dean;

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
