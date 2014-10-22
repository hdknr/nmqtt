using MonoMac.Foundation;
using MonoMac.AppKit;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Mac.Platform;
using Cirrious.MvvmCross.Mac.Views.Presenters;

namespace MqttApp.Mac
{
	public class Setup : MvxMacSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, 
			IMvxMacViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Nmqtt.App ();
		}
			

		public static void Configure(
			MvxApplicationDelegate app_delegate,  
			NSWindow window)
		{
			var presenter = new MvxMacViewPresenter(app_delegate, window);

			var setup = new Setup(app_delegate, presenter);
			setup.Initialize();

			//			var startup = Mvx.Resolve<IMvxAppStart>();
			//			startup.Start();

			Mvx.RegisterSingleton<Nmqtt.Shared.ISettings> (
				new Settings()
			);
		}

	}
}