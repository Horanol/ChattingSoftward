using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    public static class LogicController
    {
        #region 关于ConversationForm的逻辑方法
        private static Dictionary<string, ConversationForm> dictionary = new Dictionary<string,ConversationForm>();
        public static void AddConverstionForm(string friendsName, ConversationForm form)
        {
            if (!dictionary.ContainsKey(friendsName))
            {
                dictionary.Add(friendsName, form);
            }
        }
        public static void RemoveConverstionForm(string friendsName)
        {
            if (dictionary.ContainsKey(friendsName))
            {
                dictionary.Remove(friendsName);
            }
        }
        /// <summary>
        /// 帮忙转发消息给消息对话框
        /// </summary>
        /// <param name="friendsName"></param>
        /// <param name="msg"></param>
        public static void PassMessage(string friendsName, string msg)
        {
            //如果已经打开了对话窗口，就在窗口中显示消息
            if (dictionary.ContainsKey(friendsName))
            {
                dictionary[friendsName].ReceiveMessage(msg);
            }
            //如果还没打开对话窗口，显示闪烁的头像
            else
            {
 
            }
        }
        #endregion

        #region 关于LoginForm的逻辑方法
        public static void CanLogin()
        {
            LoginForm.OnAcceptLogin();
        }
        public static void CanNotLogin()
        {
            LoginForm.OnRefuseLogin();
        }
        #endregion

        #region 关于RegisterForm的逻辑方法
        public static void CanUseTheUserName()
        {
            RegisterForm.OnCheckUserName(true);
        }
        public static void CanNotUseTheUserName()     
        {
            RegisterForm.OnCheckUserName(false);
        }
        #endregion

        #region 关于AddFriendsForm的逻辑方法
        public static void ShowInfoInSearchPanel(PublicUserInfo info)
        {
            AddFriendsForm.OnShowInfoInSearchPanel(info);
        }
        
        #endregion

        public static void CreateRespondRequestForm()
        {
            
        }
    }
}
