using System.Threading;

namespace Lab5
{
    public sealed class Dean
    {
        public ManualResetEvent ExamEvent { get; }
        private object ExamLocker = new object();
        private ExamView View;

        public void ExamStart()
        {
            ExamEvent.Set();
        }

        public void PassExam(Student st)
        {
            lock (ExamLocker)
            {
                Thread.Sleep(Generator.GetRandomExamPassTime());
                View.AddStudent(st, Generator.GetRandomMark());
            }
        } 
        public Dean(ExamView view)
        {
            View = view;
            ExamEvent = new ManualResetEvent(false);
        }
    }
}
