using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DelegateDbSavingTest
{
    public class DelegateWrapper
    {
        private Func<object, object, string> _delegate;

        public int Id { get; set; }
        public byte[] DelegateData { get; private set; }
        public Func<object, object, string> Delegate
        {
            get
            {
                if (_delegate == null && DelegateData != null && DelegateData.Length > 0)
                    using (var stream = new MemoryStream(DelegateData))
                        _delegate = new BinaryFormatter().Deserialize(stream) as Func<object, object, string>;
                return _delegate;
            }
            set
            {
                _delegate = value;
                if (value == null) DelegateData = null;
                else
                    using (var stream = new MemoryStream())
                    {
                        new BinaryFormatter().Serialize(stream, value);
                        DelegateData = stream.ToArray();
                    }
            }
        }

        public string DoWork(object o1, object o2) => Delegate?.Invoke(o1, o2);
    }
}
