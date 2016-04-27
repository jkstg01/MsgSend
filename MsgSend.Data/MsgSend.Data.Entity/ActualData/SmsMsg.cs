using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgSend.Data.Entity.ActualData
{
    public class SmsMsg : BaseMsg
    {
        public SmsMsg() { }

        public string MobileNo { get; set; }
        public string MsgInfo { get; set; }

        public override void Handler()
        {
            System.Diagnostics.Debug.WriteLine("sms:" + this.MobileNo + "\t发送出去了");
        }

    }
}
