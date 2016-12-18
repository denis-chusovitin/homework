using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    static class Program
    {
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var studentAmount = Generator.GetRandomStudentAmount();
            var view = new ExamView(studentAmount);

            var controller = new ExamController(view, studentAmount);

            Application.Run(view);
        }
    }
}
