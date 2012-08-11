using System;
using System.Runtime.Serialization;
using Epoch.Extensions;

namespace DarkSky
{
    [DataContract]
    public class Notification
    {
        [DataMember(Name="id")]
        public string Id { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "threshold")]
        public string Threshold { get; set; }

        [DataMember(Name = "createdAt")]
        public int CreatedAtUnix { get; set; }

        public DateTime CreatedAt { get { return this.CreatedAtUnix.FromUnix(); } }

        [DataMember(Name = "lastNotificationAt")]
        public int LastNotificationAtUnix { get; set; }

        public DateTime LastNotificationAt { get { return this.LastNotificationAtUnix.FromUnix(); } }

        [DataMember(Name = "notificationCount")]
        public int NotificationCount { get; set; }

        [DataMember(Name = "callback")]
        public string CallBack { get; set; }

        [DataMember(Name = "enabled")]
        public bool Enabled { get; set; }
    }
}
