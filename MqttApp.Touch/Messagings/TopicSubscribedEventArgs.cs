using System;

namespace MqttApp.Touch.Messagings
{
	public class TopicSubscribedEventArgs : EventArgs
	{
		public string Topic { get; private set; }

		public TopicSubscribedEventArgs(string topic)
		{
			Topic = topic;
		}
	}
}

