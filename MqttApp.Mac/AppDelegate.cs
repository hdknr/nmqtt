using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

using Cirrious.MvvmCross.Mac.Views.Presenters;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Mac.Platform;

namespace MqttApp.Mac
{
	public partial class AppDelegate : MvxApplicationDelegate
		//NSApplicationDelegate
	{
		MainWindowController mainWindowController;

		public AppDelegate ()
		{
		}

		public override void FinishedLaunching (NSObject notification)
		{
			mainWindowController = new MainWindowController ();
			Setup.Configure (this, mainWindowController.Window);

			mainWindowController.Window.MakeKeyAndOrderFront (this);

			mainWindowController.RunSubscribe ();			/// start subscription
		}
	}
}

