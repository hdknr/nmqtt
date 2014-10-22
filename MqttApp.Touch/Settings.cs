using System;

namespace MqttApp.Touch
{
	public class Settings : Nmqtt.Shared.ISettings
	{
		public Settings ()
		{
		}

		public bool EnableMessageLogging {
			get{ return false; }
			set { }
		}
	}
}

