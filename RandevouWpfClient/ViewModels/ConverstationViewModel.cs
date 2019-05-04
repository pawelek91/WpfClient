using RandevouApiCommunication.Messages;
using RandevouWpfClient.Api;
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
        private readonly int _speakerId;

        private string newMessage;

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
        }

        private void GetConverstation()
        {

            var messages = queryProvider.GetConversation(_speakerId, null, null);
            foreach (var message in messages)
                Conversation.Add(message);
        }
    }
}
