using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgSend.Data.Entity
{
    public class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]
        public Guid Guid { get; set; }
        public string MsgType { get; set; }
        public string MsgInfo { get; set; }
        public DateTime MsgInserTime { get; set; }
        public DateTime? MsgSendTime { get; set; }
        public int MsgStatus { get; set; }
    }
}
