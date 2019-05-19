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

        public UsersDto GetMyProfileUser()
            => GetUser(_userId);
        public UserDetailsDto GetMyProfileUserDetails()
             => GetUserDetails(_userId);

        public void UpdateMyProfileUser(UserDetailsDto dto)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            usersQuery.UpdateUserDetails(_userId, dto, _apiKey);
        }

        public void UpdateMyProfileUserBasic(UsersDto dto)
        {
            var usersQuery = queryProvider.GetQueryProvider<IUsersQuery>();
            usersQuery.UpdateUser(dto, _apiKey);
        }

        public IEnumerable<UsersDto> GetManyUsers(int[] ids)
        {
            var queryUsers = queryProvider.GetQueryProvider<IUsersQuery>();
            var result = queryUsers.GetManyUsers(_apiKey, ids);
            return result;
        }

        public IEnumerable<int> FindUsers(SearchQueryDto dto)
        {
            var queryFinder = queryProvider.GetQueryProvider<IUserFinderQuery>();
            var result = queryFinder.FindUsers(dto, _apiKey);
            return result;
        }





    }
}
