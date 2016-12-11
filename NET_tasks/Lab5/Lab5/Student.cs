using System.Threading;

namespace Lab5
{
    public class Student
    {
        public string Name;
        private Dean Dean;

        public void PassExam()
        {
            Dean.ExamEvent.WaitOne();
            Thread.Sleep(Generator.GetRandomSleepTime());

            Dean.PassExam(this);
        }

        public Student(string name, Dean dean)
        {
            Name = name;
            Dean = dean;
        }
    }
}
