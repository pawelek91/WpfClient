using RandevouApiCommunication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.Api
{
    public partial class ApiQueryProvider
    {

        public IEnumerable<LastMessagesDto> GetLastMessages()
        {
            var queryMessages = queryProvider.GetQueryProvider<IMessagesQuery>();
            var result = queryMessages.GetLastMessages(_userId, _apiKey);
            return result;
        }

        public IEnumerable<MessageDto> GetConversation(int speakerId, DateTime? from, DateTime? to)
        {
            var dto = new RequestMessagesDto
            {
                FirstUserId = _userId,
                SecondUserId = speakerId,
                FromDate = from,
                ToDate = to,
            };

            var queryMessages = queryProvider.GetQueryProvider<IMessagesQuery>();
            var result = queryMessages.GetConversation(dto, _apiKey);
            return result;
        }

        public void SendMessage(int receiverId, string content)
        {
            var queryMessages = queryProvider.GetQueryProvider<IMessagesQuery>();
            queryMessages.CreateMessage(new MessageDto
            {
                SenderId = _userId,
                ReceiverId = receiverId,
                Content = content,
            }, _apiKey);
        }
    }
}
