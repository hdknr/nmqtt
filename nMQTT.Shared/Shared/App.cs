using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore;

namespace Nmqtt
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
        }

		public static Shared.ISettings Settings {
			get{
				return Mvx.Resolve<Shared.ISettings> ();
			}
		}
    }
}