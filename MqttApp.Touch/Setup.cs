using MonoTouch.UIKit;
using MonoTouch.Foundation;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;

namespace MqttApp.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Nmqtt.App ();
		}
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		public static void Configure(
			MvxApplicationDelegate app_delegate, UIWindow window)
		{
			var setup = new Setup(app_delegate, window);
			setup.Initialize();

//			var startup = Mvx.Resolve<IMvxAppStart>();
//			startup.Start();


			Mvx.RegisterSingleton<Nmqtt.Shared.ISettings> (
				new Settings()
			);
		}

	}
}