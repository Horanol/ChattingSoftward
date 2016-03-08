using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    public class SearchFriendsProtocol:Protocol
    {
        public string searchName;
        public string searchSex;
        public string searchAge;
        public SearchFriendsProtocol(string _searchName, string _searchSex, string _searchAge)
        {
            searchName = _searchName;
            searchSex = _searchSex;
            searchAge = _searchAge;
        }
        public override string ToString()
        {
            return string.Format("<protocol><message type=\"{0}\" searchName=\"{1}\" searchSex=\"{2}\" searchAge=\"{3}\" /></protocol>",
                "SearchFriends", searchName, searchSex, searchSex);
        }
    }
}
