using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Library
{
    public class MessageReply
    {
        public class Message
        {
            /// <summary>
            /// 留言編號
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 留言帳號
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// 留言名稱
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// 留言內容
            /// </summary>
            [Display(Name = "留言內容")]
            [Required(ErrorMessage = "請輸入留言內容")]
            [StringLength(100, ErrorMessage = "留言內容不可超過100字元")]
            public string Context { get; set; }

            /// <summary>
            /// 留言時間
            /// </summary>
            public System.DateTime CreatDate { get; set; }

            /// <summary>
            /// 刪除留言
            /// </summary>
            [Display(Name = "刪除留言")]
            public bool Delete { get; set; }
        }

        public class Reply
        {
            /// <summary>
            /// 回覆編號
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 會員帳號
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// 留言編號  --對應 Message 的 ID
            /// </summary>
            public int MessageId { get; set; }
            public string UserName { get; set; }

            /// <summary>
            /// 回覆內容
            /// </summary>
            [Display(Name = "留言內容")]
            [Required(ErrorMessage = "請輸入留言內容")]
            [StringLength(100, ErrorMessage = "留言內容不可超過100字元")]
            public string Context { get; set; }

            /// <summary>
            /// 回覆時間
            /// </summary>
            public DateTime? CreatDate { get; set; }

            /// <summary>
            /// 刪除回覆
            /// </summary>
            [Display(Name = "刪除回覆")]
            public bool Delete { get; set; }

            public List<Message> Messages { get; set; }
        }

        //public Message Messages { get; set; }
        //public Reply Replys { get; set; }
    }
}
