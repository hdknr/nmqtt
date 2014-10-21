using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MqttApp.Touch
{
	public partial class MqttApp_TouchViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public MqttApp_TouchViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			Messagings.Options.Username = null;
			Messagings.Options.Password = null;
			Messagings.Options.ClientIdentifier = "any";

			Messagings.MqttHandler.Instance.TopicSubscribed 
			+= (object sender, Messagings.TopicSubscribedEventArgs e) =>
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

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}

