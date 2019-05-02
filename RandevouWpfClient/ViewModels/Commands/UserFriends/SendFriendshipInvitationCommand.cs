using RandevouWpfClient.Api;
using RandevouWpfClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels.Commands.UserFriends
{
    public class SendFriendshipInvitationCommand : BasicCommand
    {
        private readonly ApiQueryProvider _aqp;
        public SendFriendshipInvitationCommand()
        {
            _aqp = ApiQueryProvider.GetInstance();
        }
        public override void Execute(object parameter)
        {
            if (!(parameter is int userId))
                throw new ArgumentException("User id expected");

            var result = ResultHandler.ProgressAction(() =>
            {
                _aqp.SendFriendshipInvitation(userId);
            }, "Wysyłanie zaproszenia");

            if (result)
                ResultHandler.Message("Zaproszenie zostało wysłane");
        }
    }
}
