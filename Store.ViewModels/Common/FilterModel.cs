using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;

namespace Store.ViewModels.Common
{

    public class CommonFilter
    {
        [FromQuery(Name = "fromDate")]
        public DateTime FromDate { get; set; } = DateTime.Now;

        [FromQuery(Name = "toDate")]
        public DateTime ToDate { get; set; } = DateTime.Now;

        [FromQuery(Name = "pageIndex")]
        public int PageIndex { get; set; } = 0;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = Int32.MaxValue;
    }

    public class PagingFilter
    {
        [FromQuery(Name = "pageIndex")]
        public int PageIndex { get; set; } = 0;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = Int32.MaxValue;
    }

    public class DateTimeFilter
    {
        [FromQuery(Name = "fromDate")]
        public DateTime FromDate { get; set; } = DateTime.Now;

        [FromQuery(Name = "toDate")]
        public DateTime ToDate { get; set; } = DateTime.Now;
    }
}

