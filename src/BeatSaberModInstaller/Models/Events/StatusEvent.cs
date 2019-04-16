using System;

namespace BeatSaberModInstaller.Models.Events
{
    public class StatusEvent : EventArgs
    {
        public string Message { get; set; }

        public StatusEvent(string msg)
        {
            Message = msg;
        }
    }
}