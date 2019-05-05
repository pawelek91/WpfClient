using RandevouApiCommunication;
using RandevouApiCommunication.Authentication;
using RandevouApiCommunication.Friendships;
using RandevouApiCommunication.Messages;
using RandevouApiCommunication.Users;
using RandevouApiCommunication.UsersFinder;
using RandevouWpfClient.Models.Common;
using System;
using System.Collections.Generic;

namespace RandevouWpfClient.Api
{
    public partial class ApiQueryProvider
    {
        public IEnumerable<UsersDto> GetFriends()
        {
            var queryFriends = queryProvider.GetQueryProvider<IUserFriendshipQuery>();
            var queryUsers = queryProvider.GetQueryProvider<IUsersQuery>();

            var result = new List<UsersDto>();
            var usersIdentities = queryFriends.GetFriends(_userId, _apiKey);

            foreach (var userId in usersIdentities)
            {
                var dto = queryUsers.GetUser(userId, _apiKey);
                if (dto != null)
                    result.Add(dto);
            }
            return result;
        }

        public void RemoveFriend(int friendId)
        {
            var queryFriends = queryProvider.GetQueryProvider<IUserFriendshipQuery>();
            queryFriends.SetFriendshipStatusAction(new UpdateFriendshipStatusDto
            {
                Action = Consts.Delete,
                FromUserId = _userId,
                ToUserId = friendId,
            }, _apiKey);
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

    }
}
