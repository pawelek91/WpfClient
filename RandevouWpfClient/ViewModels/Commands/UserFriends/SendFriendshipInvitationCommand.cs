using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels.Commands.UserFriends
{
    public class SendFriendshipInvitationCommand : BasicCommand
    {
        public override void Execute(object parameter)
        {
            if (!(parameter is int userId))
                throw new ArgumentException("User id expected");

            
        }
    }
}
