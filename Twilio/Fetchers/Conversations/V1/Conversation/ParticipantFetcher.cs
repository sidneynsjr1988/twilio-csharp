using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Conversations.V1.Conversation;

namespace Twilio.Fetchers.Conversations.V1.Conversation {

    public class ParticipantFetcher : Fetcher<ParticipantResource> {
        private string conversationSid;
        private string sid;
    
        /**
         * Construct a new ParticipantFetcher
         * 
         * @param conversationSid The conversation_sid
         * @param sid The sid
         */
        public ParticipantFetcher(string conversationSid, string sid) {
            this.conversationSid = conversationSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched ParticipantResource
         */
        public override async Task<ParticipantResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.CONVERSATIONS,
                "/v1/Conversations/" + this.conversationSid + "/Participants/" + this.sid + ""
            );
            
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ParticipantResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return ParticipantResource.FromJson(response.GetContent());
        }
    }
}