using RandevouApiCommunication;
using RandevouApiCommunication.Authentication;
using RandevouApiCommunication.Friendships;
using RandevouApiCommunication.Messages;
using RandevouApiCommunication.Users;
using RandevouApiCommunication.UsersFinder;
using RandevouWpfClient.Models.Common;
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

        public void SetUserData(string apiKey, int userId)
        {
            _apiKey = apiKey;
            _userId = userId;
        }
        ApiCommunicationProvider queryProvider;

        private static ApiQueryProvider _apiQueryProvider;
        
     

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

        public UserDetailsDto GetUserDetails(int userId)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            var result = usersQuery.GetUserDetails(userId, _apiKey);
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

        public void SendFriendshipInvitation(int toUserId)
        {
            var queryFriends = queryProvider.GetQueryProvider<IUserFriendshipQuery>();
            queryFriends.PostFriendshipInvitation(new FriendshipSendRequestDto
            {
                FromUserId = _userId,
                ToUserId = toUserId,
            }, _apiKey);
        }

        public void AcceptFriendshipInvitation(int userSenderId)
        {
            var dto = new UpdateFriendshipStatusDto
            {
                FromUserId = _userId, //from = _userId bo akceptacja/odrzucenie idzie od zalogowanego!
                ToUserId = userSenderId,
                Action = Consts.Accept,
            };
            queryProvider.GetQueryProvider<IUserFriendshipQuery>()
                .SetFriendshipStatusAction(dto, _apiKey);
        }

        public void RejectFriendshipInvitation(int userSenderId)
        {
            var dto = new UpdateFriendshipStatusDto
            {
                FromUserId = _userId,
                ToUserId = userSenderId, //from = _userId bo akceptacja/odrzucenie idzie od zalogowanego!
                Action = Consts.Delete,
            };
            queryProvider.GetQueryProvider<IUserFriendshipQuery>()
                .SetFriendshipStatusAction(dto, _apiKey);
        }

        public IEnumerable<LastMessagesDto> GetLastMessages()
        {
            var queryMessages = queryProvider.GetQueryProvider<IMessagesQuery>();
            var result = queryMessages.GetLastMessages(_userId, _apiKey);
            return result;
        }

        public IEnumerable<int> FindUsers(SearchQueryDto dto)
        {
            var queryFinder = queryProvider.GetQueryProvider<IUserFinderQuery>();
            var result = queryFinder.FindUsers(dto, _apiKey);
            return result;
        }

        public IEnumerable<UsersDto> GetManyUsers(int[] ids)
        {
            var queryUsers = queryProvider.GetQueryProvider<IUsersQuery>();
            var result = queryUsers.GetManyUsers(_apiKey, ids);
            return result;
        }

       
    }
}
