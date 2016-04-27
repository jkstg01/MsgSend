using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo = MsgSend.Data.EFDemo;
using EntityData = MsgSend.Data.Entity;
using Newtonsoft.Json;
using System.Reflection;
using System.Transactions;

namespace MsgSend.Sender.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityData.BaseEntity baseEntity = GetBaseEntity();

            EntityData.ActualData.BaseMsg baseMsg = GetCommonMsg(baseEntity);

            baseMsg.Handler();
        }

        static EntityData.ActualData.BaseMsg GetCommonMsg(EntityData.BaseEntity baseEntity)
        {
            if (null == baseEntity)
            {
                throw new ArgumentNullException();
            }

            var msg = Assembly.Load("MsgSend.Data.Entity").CreateInstance(baseEntity.MsgType);
            Type commonMsgType = msg.GetType();

            msg = JsonConvert.DeserializeObject(baseEntity.MsgInfo, commonMsgType);
            return msg as EntityData.ActualData.BaseMsg;
        }

        static EntityData.BaseEntity GetBaseEntity()
        {
            var baseEntity = new EntityData.BaseEntity();
            using (var transaction = new TransactionScope())
            {
                using (var db = new EFDemo.MsgSendContext())
                {
                    baseEntity = db.BaseEntities.OrderBy(m => m.MsgInserTime).FirstOrDefault(m => m.MsgStatus == 0);
                    if (null != baseEntity)
                    {
                        baseEntity.MsgStatus = 1;
                        db.SaveChanges();
                    }
                }

                transaction.Complete();
            }

            return baseEntity;
        }
    }
}
