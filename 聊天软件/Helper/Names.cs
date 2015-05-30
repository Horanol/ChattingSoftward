using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public static class Names
    {
       public static class ProtocolTypes
        {
            public static readonly string CONVERSATION = "Conversation";
            public static readonly string FILE = "File";
            public static readonly string SIGN_IN = "SignIn";
            public static readonly string USER_DETAIL_INFO = "UserDetailInfo";
            public static readonly string USER_PUBLIC_INFO = "UserPublicInfo";
            public static readonly string ADD_FRIENDS_REQUEST = "AddFriendsRequest";
            public static readonly string ADD_FRIENDS_RESPOND = "AddFriendsRespond";
            public static readonly string SEARCH_FRIENDS = "SearchFriends";
            public static readonly string GET_FRIENDS_INFO = "GetFriendsInfo";
            public static readonly string SPECIAL_EFFECT = "SpecialEffect";
            public static readonly string SEND_FILE_REQUEST = "SendFileRequest";
            public static readonly string SEND_FILE_RESPOND = "SendFileRespond";

        }
        public static class ProtocolMembers
        {
            public static readonly string SOURCE_NAME = "sourceName";
            public static readonly string DESTINATION_NAME = "destinationName";
            public static readonly string CONTENT = "content";

            public static readonly string FILE_NAME = "fileName";
            public static readonly string PORT = "port";
            public static readonly string MODE = "mode";

            public static readonly string USER_NAME = "userName";
            public static readonly string PASSWORD = "password";
            public static readonly string SAYING = "saying";
            public static readonly string ICON_PATH = "iconPath";

            public static readonly string SPONSOR = "sponsor";
            public static readonly string RESPONDENT = "respondent";
            public static readonly string RESPOND = "respond";

            public static readonly string SEARCH_NAME = "searchName";
            public static readonly string SEARCH_AGE = "searchAge";
            public static readonly string SEARCH_SEX = "searchSex";

            public static readonly string FRIENDS_NAME = "friendsName";

            public static readonly string EFFECT = "effect";

            public static readonly string ACCEPT = "accept";
            public static readonly string REJECT = "reject";


        }
    }
}
