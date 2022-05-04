using System;
using System.Globalization;
using System.Collections.Generic;

namespace Store.ViewModels.Common
{
    public class ServiceException: Exception
    {
        public ServiceException() : base() { }

        public ServiceException(string message) : base(message) { }

        public ServiceException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }

    public class NotFoundException: KeyNotFoundException
    {
    }
}

