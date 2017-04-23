namespace DelegateDbSavingTest
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DelegateSaver : DbContext
    {
        // Контекст настроен для использования строки подключения "DelegateSaver" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "DelegateDbSavingTest.DelegateSaver" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "DelegateSaver" 
        // в файле конфигурации приложения.
        public DelegateSaver()
            : base("name=DelegateSaver")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<DelegateWrapper> DelegateWrappers { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}