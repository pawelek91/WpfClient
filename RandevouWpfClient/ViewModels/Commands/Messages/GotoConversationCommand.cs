using RandevouWpfClient.Views.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels.Commands.Messages
{
    public class GotoConversationCommand : BasicCommand
    {
        public GotoConversationCommand()
        {
            
        }
        public override void Execute(object parameter)
        {
            if (!(parameter is int userId))
                return;

            var view = new ConversationView(userId);
            view.ShowDialog();
        }
    }
}
