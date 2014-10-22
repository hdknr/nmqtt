
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace MqttApp.Mac
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
			
		// Shared initialization code
		void Initialize ()
		{
		}

		#endregion

		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}


		public void RunSubscribe()
		{
			Messagings.Options.Username = null;
			Messagings.Options.Password = null;
			Messagings.Options.ClientIdentifier = "any";

			Messagings.MqttHandler.Instance.TopicSubscribed 
			+= (object sender, MqttApp.Mac.Messagings.TopicSubscribedEventArgs e) =>
			{
				Console.WriteLine(e.Topic);
			}; 

			Messagings.MqttHandler.Instance.ClientMessageArrived 
			+= (object sender, Nmqtt.MqttMessageEventArgs e) => 
			{
				Console.Write("*****");
				Console.WriteLine( 
					System.Text.Encoding.ASCII.GetString((byte[])e.Message));
			};

			var state = Messagings
				.MqttHandler
				.Instance.Connect ("192.168.56.50", 1883);

			if (state == Nmqtt.ConnectionState.Connected) {
				Messagings.MqttHandler.Instance.Subscribe ("my/topic/string", 0);
			}				
		}

	}
}

