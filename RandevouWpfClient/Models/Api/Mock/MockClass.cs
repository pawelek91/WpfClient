using RandevouApiCommunication.Friendships;
using RandevouApiCommunication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.Api.Mock
{
    public class MockClass
    {
        public UsersDto[] userDto { get; set; }
        public UserDetailsDto[] UserDetailsDto { get; set; }
        public FriendshipSendRequestDto SendRequestDto { get; set; }
        public UpdateFriendshipStatusDto updateFriendshipStatusDto { get; set; }

        public static UsersDto[] AllUsers = new UsersDto[]
        {
             new UsersDto
             {
                 BirthDate = new DateTime(2000,10,10),
                  DisplayName = "some user",
                   Gender = 'm',
                    Name = "someUser"
             },
             new UsersDto
             {
                 BirthDate = new DateTime(1990,10,10),
                  DisplayName = "another user",
                   Gender = 'm',
                    Name = "someUser"
             },
             new UsersDto
             {
                 BirthDate = new DateTime(1980,10,10),
                  DisplayName = "dark user",
                   Gender = 'm',
                    Name = "someUser"
             },
             new UsersDto
             {
                 BirthDate = new DateTime(2010,10,10),
                  DisplayName = "grey user",
                   Gender = 'm',
                    Name = "someUser"
             },
             new UsersDto
             {
                 BirthDate = new DateTime(2000,10,10),
                  DisplayName = "heh user",
                   Gender = 'm',
                    Name = "someUser"
             },
        };

        public static UsersDto[] UserFriends = new UsersDto[]
        {
            AllUsers[0],
            AllUsers[1],
        };

        public static UsersDto[] InvitationFromUsers = new UsersDto[]
        {
            AllUsers[2],
            AllUsers[3],
        };
            
       
            
    }

    

    
}
