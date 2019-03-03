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
                    Name = "someUser",
                    Id =0,
             },
             new UsersDto
             {
                 BirthDate = new DateTime(1990,10,10),
                  DisplayName = "another user",
                   Gender = 'm',
                    Name = "someUser",
                 Id =1,
             },
             new UsersDto
             {
                 BirthDate = new DateTime(1980,10,10),
                  DisplayName = "dark user",
                   Gender = 'm',
                    Name = "someUser",
                 Id =2,
             },
             new UsersDto
             {
                 BirthDate = new DateTime(2010,10,10),
                  DisplayName = "grey user",
                   Gender = 'm',
                    Name = "someUser",
                 Id =3,
             },
             new UsersDto
             {
                 BirthDate = new DateTime(2000,10,10),
                  DisplayName = "heh user",
                   Gender = 'm',
                    Name = "someUser",
                 Id =4,
             },
        };

        public static UserDetailsDto[] AllUsersDetails = new UserDetailsDto[]
        {
            new UserDetailsDto
            {
                 UserId = 0,
                 City= "Warszawa",
                 Region="Mazowieckie",
                 Width = 180,
                 Heigth = 80,
            },
            new UserDetailsDto
            {
                 UserId = 1,
                 City= "Warszawa",
                 Region="Mazowieckie",
                 Width = 160,
                 Heigth = 60,
            },
            new UserDetailsDto
            {
                 UserId = 2,
                 City= "Gdańsk",
                 Region="Pomorskie",
                 Width = 170,
                 Heigth = 70,

            },
            new UserDetailsDto
            {
                 UserId = 3,
                 City= "Kraków",
                 Region="Małopolskie",
                 Width = 190,
                 Heigth = 90,
            },
            new UserDetailsDto
            {
                 UserId = 4,
                 City= "Wieliczka",
                 Region="Małopolskie",
                 Width = 165,
                 Heigth = 65,
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
