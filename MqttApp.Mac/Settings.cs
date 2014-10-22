using System;

namespace MqttApp.Mac
{
	public class Settings : Nmqtt.Shared.ISettings
	{
		public Settings ()
		{
		}

		public bool EnableMessageLogging {
			get{ return true; }
			set { }
		}
	}
}

