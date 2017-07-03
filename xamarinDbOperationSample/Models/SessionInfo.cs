using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xamarinDbOperationSample.Models
{
    public class SessionInfo
    {
        public int SessionId { get; set; }
        public string SessionName { get; set;}
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public IEnumerable<SpeakerInfo> Speakers { get; set; }
    }
}