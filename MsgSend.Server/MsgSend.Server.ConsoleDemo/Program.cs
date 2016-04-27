using System;
using EFDemo = MsgSend.Data.EFDemo;
using EntityData = MsgSend.Data.Entity;
using Newtonsoft.Json;

namespace MsgSend.Server.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AddMsg();
        }

        static void AddMsg()
        {
            using (var db = new EFDemo.MsgSendContext())
            {
                var smsMsg = AddSmsMsg();
                var emailMsg = AddEmailMsg();

                var baseEntity = GenerateBaseMsg(smsMsg);
                db.BaseEntities.Add(baseEntity);

                baseEntity = GenerateBaseMsg(emailMsg);
                db.BaseEntities.Add(baseEntity);

                db.SaveChanges();
            }
        }

        static EntityData.BaseEntity GenerateBaseMsg<T>(T commonMsg)
        {
            EntityData.BaseEntity baseEntity = new EntityData.BaseEntity()
            {
                MsgType = commonMsg.GetType().ToString(),
                MsgInfo = JsonConvert.SerializeObject(commonMsg),
                MsgInserTime = DateTime.Now,
                MsgStatus = 0
            };

            return baseEntity;
        }

        static EntityData.ActualData.SmsMsg AddSmsMsg()
        {
            EntityData.ActualData.SmsMsg smsMsg = new Data.Entity.ActualData.SmsMsg()
            {
                MobileNo = "13558137033",
                MsgInfo = "这是一条短信"
            };

            return smsMsg;
        }

        static EntityData.ActualData.EmailMsg AddEmailMsg()
        {
            EntityData.ActualData.EmailMsg emailMsg = new EntityData.ActualData.EmailMsg()
            {
                EmailNo = "aaa@email.com",
                MsgInfo = "这是一封邮件"
            };

            return emailMsg;
        }
    }
}
