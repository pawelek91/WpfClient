using RandevouApiCommunication.Messages;
using RandevouWpfClient.ViewModels.Commands.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels
{
    public class MessagesViewModel : PrimaryViewModel
    {
        public ObservableCollection<LastMessagesDto> LastMessages { get; set; }

        private LastMessagesDto selectedLastMessage;

        public LastMessagesDto SelectedLastMessage
        {
            get { return selectedLastMessage; }
            set { selectedLastMessage = value; OnChanged(nameof(SelectedLastMessage)); }
        }

        public GotoConversationCommand GotoConversationCommand { get; set; }

        public MessagesViewModel()
        {
            LastMessages = new ObservableCollection<LastMessagesDto>(queryProvider.GetLastMessages());
            GotoConversationCommand = new GotoConversationCommand();
        }

    }
}
