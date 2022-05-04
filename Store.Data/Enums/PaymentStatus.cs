using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Enums
{
    public enum PaymentStatus
    {
        UnpaidInvoice,//chua thanh toan
        PayAllMoney, //da thanh toan
        PaymentByInstalment,  //tra gop
        Canceled //huy

    }
}
