using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Enums
{
    public enum OrderStatusEnums
    {
        Pending, //0- chờ duyệt
        Confirmed, //1- Đã xác nhận
        Shipping, //2-đang giao
        Success,//3- thành công
        Canceled//4- đã hủy
    }
}
