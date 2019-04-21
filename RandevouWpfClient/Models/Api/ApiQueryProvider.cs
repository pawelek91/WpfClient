using RandevouApiCommunication;
using RandevouApiCommunication.Authentication;
using RandevouApiCommunication.Friendships;
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
        private static string _apiKey;
        private static int _userId;

        public void SetUserData(string apiKey, int userId)
        {
            _apiKey = apiKey;
            _userId = userId;
        }
        ApiCommunicationProvider queryProvider;
        public ApiQueryProvider()
        {
            queryProvider = ApiCommunicationProvider.GetInstance();
        }

        public string Login(string username, string password)
        {
            var authQuery = queryProvider.GetQueryProvider<IAuthenticationQuery>();
            var key = authQuery.GetLoginAuthKey(username, password);
            return key;
        }

        public int GetIdentity(string apiKey)
        {
            var authQuery = queryProvider.GetQueryProvider<IAuthenticationQuery>();
            var id = authQuery.GetIdentity(apiKey);
            return id;
        }

        public void CreateUser(UserComplexDto dto)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            usersQuery.CreateUserWithLogin(dto);
        }


        public IEnumerable<UsersDto> GetFriends(int id)
        {
            var queryFriends = queryProvider.GetQueryProvider<IUserFriendshipQuery>();
            var queryUsers = queryProvider.GetQueryProvider<IUsersQuery>();

            var result = new List<UsersDto>();
            var usersIdentities = queryFriends.GetFriends(id, _apiKey);

            foreach(var userId in usersIdentities)
            {
                var dto = queryUsers.GetUser(userId, _apiKey);
                if (dto != null)
                    result.Add(dto);
            }
            return result;
        }

        public IEnumerable<UsersDto> GetInvitatios(int id)
        {
            var queryFriends = queryProvider.GetQueryProvider<IUserFriendshipQuery>();
            var queryUsers = queryProvider.GetQueryProvider<IUsersQuery>();

            var result = new List<UsersDto>();
            var usersIdentities = queryFriends.GetFriendshipRequests(id, _apiKey);
            foreach (var userId in usersIdentities)
            {
                var dto = queryUsers.GetUser(userId, _apiKey);
                if (dto != null)
                    result.Add(dto);
            }
            return result;
        }

       
    }
}
