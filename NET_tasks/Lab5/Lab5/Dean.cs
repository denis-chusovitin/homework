using System.Threading;

namespace Lab5
{
    public sealed class Dean
    {
        public ManualResetEvent ExamEvent { get; }
        private object ExamLocker = new object();
        private ExamController controller;

        public void ExamStart()
        {
            ExamEvent.Set();
        }

        public void PassExam(Student st)
        {
            lock (ExamLocker)
            {
                Thread.Sleep(Generator.GetRandomExamPassTime());
                controller.AddStudentToView(st, Generator.GetRandomMark());
            }
        } 
        public Dean(ExamController controller)
        {
            this.controller = controller;
            ExamEvent = new ManualResetEvent(false);
        }
    }
}
