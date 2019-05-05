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
            set
            {
                selectedLastMessage = value;
                OnChanged(nameof(SelectedLastMessage));

                if (value != null)
                    GotoConversationCommand.Execute(value.SpeakerId);
            }
        }

        public GotoConversationCommand GotoConversationCommand { get; set; }

        public MessagesViewModel() : base()
        {
            GotoConversationCommand = new GotoConversationCommand();
            LastMessages = new ObservableCollection<LastMessagesDto>();
            GetDataAndRefreshUI();

        }

        protected override void GetDataAndRefreshUI()
        {
            var incomingMessages = queryProvider.GetLastMessages();

            if(!LastMessages.Any(x=> incomingMessages.Select(y=>y.SpeakerId).Contains(x.SpeakerId)))
            { 
                LastMessages.Clear();
                foreach (var m in incomingMessages)
                    LastMessages.Add(m);
            }
        }

        protected override TimeSpan RefreshTime => new TimeSpan(0, 0, 10);
    }
}
