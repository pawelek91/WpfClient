using RandevouApiCommunication;
using RandevouApiCommunication.Authentication;
using RandevouApiCommunication.Friendships;
using RandevouApiCommunication.Messages;
using RandevouApiCommunication.Users;
using RandevouApiCommunication.UsersFinder;
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

        private static ApiQueryProvider _apiQueryProvider;
        
        public static ApiQueryProvider GetInstance()
        {
            if (_apiQueryProvider == null)
                _apiQueryProvider = new ApiQueryProvider();

            return _apiQueryProvider;
        }
        private ApiQueryProvider()
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

        public UsersDto GetUser(int userId)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            var result = usersQuery.GetUser(userId, _apiKey);
            return result;
        }


        public IEnumerable<UsersDto> GetFriends()
        {
            var queryFriends = queryProvider.GetQueryProvider<IUserFriendshipQuery>();
            var queryUsers = queryProvider.GetQueryProvider<IUsersQuery>();

            var result = new List<UsersDto>();
            var usersIdentities = queryFriends.GetFriends(_userId, _apiKey);

            foreach(var userId in usersIdentities)
            {
                var dto = queryUsers.GetUser(userId, _apiKey);
                if (dto != null)
                    result.Add(dto);
            }
            return result;
        }

        public IEnumerable<UsersDto> GetInvitatios()
        {
            var queryFriends = queryProvider.GetQueryProvider<IUserFriendshipQuery>();
            var queryUsers = queryProvider.GetQueryProvider<IUsersQuery>();

            var result = new List<UsersDto>();
            var usersIdentities = queryFriends.GetFriendshipRequests(_userId, _apiKey);
            foreach (var userId in usersIdentities)
            {
                var dto = queryUsers.GetUser(userId, _apiKey);
                if (dto != null)
                    result.Add(dto);
            }
            return result;
        }

        public IEnumerable<LastMessagesDto> GetLastMessages()
        {
            var queryMessages = queryProvider.GetQueryProvider<IMessagesQuery>();
            var result = queryMessages.GetLastMessages(_userId, _apiKey);
            return result;
        }

        public IEnumerable<int> FindUsers(UsersFinderDto dto)
        {
            var queryFinder = queryProvider.GetQueryProvider<IUserFinderQuery>();
            var result = queryFinder.FindUsers(dto, _apiKey);
            return result;
        }

       
    }
}
