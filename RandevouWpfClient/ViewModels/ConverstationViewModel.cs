using RandevouApiCommunication.Messages;
using RandevouWpfClient.Api;
using RandevouWpfClient.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels
{
    public class ConverstationViewModel : PrimaryViewModel
    {
        public readonly int _speakerId;

        private string newMessage;

        public SendMessageCommand SendMessageCommand { get; set; }

        public string NewMessageContent
        {
            get { return newMessage; }
            set { newMessage = value; OnChanged(nameof(NewMessageContent), true); }
        }

        public ObservableCollection<MessageDto> Conversation { get; set; }
        public ConverstationViewModel(int speakerId)
        {
            _speakerId = speakerId;
            Conversation = new ObservableCollection<MessageDto>();
            SendMessageCommand = new SendMessageCommand(this);
            GetConverstation();
        }

        public void GetConverstation()
        {
            Conversation.Clear();
            var messages = queryProvider.GetConversation(_speakerId, null, null);
            foreach (var message in messages)
                Conversation.Add(message);
        }
    }
}
