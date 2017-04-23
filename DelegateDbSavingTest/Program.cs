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
            DropDatabase();
            FillDatabase();

            using (var context = new DelegateSaver())
                context.DelegateWrappers.ToList().ForEach(x => Console.WriteLine(x.DoWork("first", "second")));
            
            Console.Write("program finished, push any key...");
            Console.ReadKey();

        }

        static void DropDatabase()
        {
            using (var context = new DelegateSaver())
            {
                context.DelegateWrappers.RemoveRange(context.DelegateWrappers);
                context.SaveChanges();
            }
        }

        static void FillDatabase()
        {
            using (var context = new DelegateSaver())
            {
                context.DelegateWrappers.AddRange(new[]
                {
                    new DelegateWrapper{Delegate = (x, y) => string.Join("", x.ToString().Take(3))},
                    new DelegateWrapper{Delegate = (x, y) => string.Join("", y.ToString().Take(3))}
                });
                context.SaveChanges();
            }
        }
    }
}
