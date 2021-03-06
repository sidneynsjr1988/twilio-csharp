/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    /// <summary>
    /// FetchRecordingOptions
    /// </summary>
    public class FetchRecordingOptions : IOptions<RecordingResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchRecordingOptions
        /// </summary>
        ///
        /// <param name="pathCallSid"> The call_sid </param>
        /// <param name="pathSid"> The sid </param>
        public FetchRecordingOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// DeleteRecordingOptions
    /// </summary>
    public class DeleteRecordingOptions : IOptions<RecordingResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteRecordingOptions
        /// </summary>
        ///
        /// <param name="pathCallSid"> The call_sid </param>
        /// <param name="pathSid"> The sid </param>
        public DeleteRecordingOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// ReadRecordingOptions
    /// </summary>
    public class ReadRecordingOptions : ReadOptions<RecordingResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The date_created
        /// </summary>
        public DateTime? DateCreatedBefore { get; set; }
        /// <summary>
        /// The date_created
        /// </summary>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// The date_created
        /// </summary>
        public DateTime? DateCreatedAfter { get; set; }

        /// <summary>
        /// Construct a new ReadRecordingOptions
        /// </summary>
        ///
        /// <param name="pathCallSid"> The call_sid </param>
        public ReadRecordingOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (DateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated", DateCreated.Value.ToString("yyyy-MM-dd")));
            }
            else
            {
                if (DateCreatedBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated<", DateCreatedBefore.Value.ToString("yyyy-MM-dd")));
                }

                if (DateCreatedAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated>", DateCreatedAfter.Value.ToString("yyyy-MM-dd")));
                }
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

}