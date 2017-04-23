using System;

namespace DelegateDbSavingTest
{
    public class DelegateWrapper
    {
        public int Id { get; set; }
        public Func<object, object, string> Delegate { get; set; }

        public string DoWork(object o1, object o2) => Delegate?.Invoke(o1, o2);
    }
}
