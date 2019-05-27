using System;

namespace unit13_2
{
    public class MessageArrivedEventArgs : EventArgs
    {
        private string message;
        public string Message
        {
            get { return message; }
        }
        public MessageArrivedEventArgs() => message = "No message sent.";
        public MessageArrivedEventArgs(string newMessage) =>
        message = newMessage;
    }
}