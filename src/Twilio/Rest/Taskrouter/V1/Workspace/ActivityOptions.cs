/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    /// <summary>
    /// FetchActivityOptions
    /// </summary>
    public class FetchActivityOptions : IOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchActivityOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathSid"> The sid </param>
        public FetchActivityOptions(string pathWorkspaceSid, string pathSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
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
    /// UpdateActivityOptions
    /// </summary>
    public class UpdateActivityOptions : IOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Construct a new UpdateActivityOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathSid"> The sid </param>
        public UpdateActivityOptions(string pathWorkspaceSid, string pathSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            return p;
        }
    }

    /// <summary>
    /// DeleteActivityOptions
    /// </summary>
    public class DeleteActivityOptions : IOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteActivityOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathSid"> The sid </param>
        public DeleteActivityOptions(string pathWorkspaceSid, string pathSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
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
    /// ReadActivityOptions
    /// </summary>
    public class ReadActivityOptions : ReadOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The available
        /// </summary>
        public string Available { get; set; }

        /// <summary>
        /// Construct a new ReadActivityOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        public ReadActivityOptions(string pathWorkspaceSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (Available != null)
            {
                p.Add(new KeyValuePair<string, string>("Available", Available));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// CreateActivityOptions
    /// </summary>
    public class CreateActivityOptions : IOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// The available
        /// </summary>
        public bool? Available { get; set; }

        /// <summary>
        /// Construct a new CreateActivityOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        public CreateActivityOptions(string pathWorkspaceSid, string friendlyName)
        {
            PathWorkspaceSid = pathWorkspaceSid;
            FriendlyName = friendlyName;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (Available != null)
            {
                p.Add(new KeyValuePair<string, string>("Available", Available.Value.ToString()));
            }

            return p;
        }
    }

}