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
    public partial class ApiQueryProvider
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
    }
}
