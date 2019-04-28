using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels.Commands.Messages
{
    public class GotoConversationCommand : BasicCommand
    {
        public MessagesViewModel MessagesVM { get; set; }
        public GotoConversationCommand(MessagesViewModel vm)
        {
            MessagesVM = vm;
        }
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
