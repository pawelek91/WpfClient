using RandevouApiCommunication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.Api
{
    public class ApiQueryProvider
    {
        public ApiQueryProvider()
        {
            
        }

        public UsersDto[] GetFriends(int id)
            => Mock.MockClass.UserFriends;

        public UsersDto[] GetInvitatios(int id)
            => Mock.MockClass.InvitationFromUsers;
    }
}
