using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    public class AddFriendsRespondHandler : IHandlerProtocol
    {
        /// <summary>
        /// 判断Respond的内容，如果是接受的话
        /// 在客户端UserInfo里修改好友关系，从本地读取好友信息，在主窗体中添加好友的Panel
        /// </summary>
        /// <param name="_pro"></param>
        public void HandlerProtocol(Protocol _pro)
        {

            AddFriendsRespondProtocol pro = (AddFriendsRespondProtocol)_pro;
            if (pro.respond == "Accepted")
            {
                System.Windows.Forms.MessageBox.Show(pro.respondent + "    已经接受了你的好友请求");
                UserInfo.AddFriend(pro.sponsor, pro.respondent);
                ClientMainForm.OnUpdateFriendsList();

            }

        }
    }
}
