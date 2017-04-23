using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDbSavingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DelegateSaver())
            {
                if (context.DelegateWrappers.Count() < 2) FillDatabase();

                context.DelegateWrappers.ToList().ForEach(x => x.DoWork("first", "second"));
            }

            Console.Write("program finished, push any key...");
            Console.ReadKey();

        }

        static void FillDatabase()
        {
            using (var context = new DelegateSaver())
            {
                context.DelegateWrappers.AddRange(new[]
                {
                    new DelegateWrapper{Delegate = (x, y) => x.ToString().Take(3).ToString()},
                    new DelegateWrapper{Delegate = (x, y) => y.ToString().Take(3).ToString()}
                });
                context.SaveChanges();
            }
        }
    }
}
