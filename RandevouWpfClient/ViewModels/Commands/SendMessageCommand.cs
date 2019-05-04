using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels.Commands
{
    public class SendMessageCommand : BasicCommand
    {
        private readonly ConverstationViewModel _conversationVm;
        public SendMessageCommand(ConverstationViewModel conversationVm)
        {
            _conversationVm = conversationVm;
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_conversationVm.NewMessageContent);
        }
        public override void Execute(object parameter)
        {
            //QueryProvider
        }
    }
}
