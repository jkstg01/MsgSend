using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgSend.Data.Entity.ActualData
{
    public class EmailMsg : BaseMsg
    {
        public EmailMsg() { }

        public string EmailNo { get; set; }
        public string MsgInfo { get; set; }

        public override void Handler()
        {
            System.Diagnostics.Debug.WriteLine("email:" + this.EmailNo + "\t发送出去了");
        }

    }
}
