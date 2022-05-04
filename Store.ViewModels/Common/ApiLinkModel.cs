using System;
namespace Store.ViewModels.Common
{
    public class ApiLink
    {
        public Gateway Gateway { get; set; }
    }

    #region Gateway
    public class Gateway
    {
        public string RemovePerson { get; set; }

        public string RegisterPerson { get; set; }

        public Person Person { get; set; }

        public Kiosk Kiosk { get; set; }
    }

    public class Person
    {
        public Link Get { get; set; }

        public Link Register { get; set; }

        public Link Remove { get; set; }
    }

    public class Kiosk
    {
        public Link GetPagedResult { get; set; }
    }
    #endregion

    public class Link
    {
        public string Url { get; set; }

        public string Method { get; set; }
    }
}