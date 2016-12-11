using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Humans;
using Lab4;

namespace Tests
{
    [TestClass]
    public class DateTests
    {
        private void CheckHumanChild(Type type, Student father, Girl mother)
        {
            God god = new God(false);

            var girl = god.Couple(father, mother) as Girl;

            if (girl != null)
            {
                Assert.AreEqual(girl.GetType(), type);
                Assert.AreEqual(girl.Name, mother.Name);
                Assert.AreEqual(girl.Patronymic, father.Name + "овна");
            }
            else
            {
                Assert.Fail("Wrong result");
            }
        }

        [TestMethod]
        public void DateExeptionTest()
        {
            try
            {
                God god = new God();

                var girl1 = new Girl();
                var girl2 = new PrettyGirl();

                var student1 = new Student(Gender.Male);
                var student2 = new Botan(Gender.Male);

                god.Couple(girl1, girl2);
                god.Couple(student1, student2);

                Assert.Fail("No DateException");
            }
            catch (Exception ex)
            {
                if (!(ex is DateException))
                {
                    Assert.Fail("Not DateException");
                }
            }
        }

        [TestMethod]
        public void TestStudentGirlDate()
        {
            var student = new Student(Gender.Male);
            var girl = new Girl();

            CheckHumanChild(typeof(Girl), student, girl);
        }

        [TestMethod]
        public void TestStudentPrettyGirlDate()
        {
            var student = new Student(Gender.Male);
            var girl = new PrettyGirl();

            CheckHumanChild(typeof(PrettyGirl), student, girl);
        }

        [TestMethod]
        public void TestStudentSmartGirlDate()
        {
            var student = new Student(Gender.Male);
            var girl = new SmartGirl();

            CheckHumanChild(typeof(Girl), student, girl);
        }

        [TestMethod]
        public void TestBotanGirlDate()
        {
            var student = new Botan(Gender.Male);
            var girl = new Girl();

            CheckHumanChild(typeof(SmartGirl), student, girl);
        }

        [TestMethod]
        public void TestBotanPrettyGirlDate()
        {
            var student = new Botan(Gender.Male);
            var girl = new PrettyGirl();

            CheckHumanChild(typeof(PrettyGirl), student, girl);
        }

        [TestMethod]
        public void TestBotanSmartGirlDate()
        {
            var student = new Botan(Gender.Male);
            var girl = new SmartGirl();

            God god = new God(false);

            var res = god.Couple(student, girl) as Book;

            if (res != null)
            {
                Assert.AreEqual(res.Name, girl.Name);
            }
            else
            {
                Assert.Fail("Wrong result");
            }
        }
    }
}
