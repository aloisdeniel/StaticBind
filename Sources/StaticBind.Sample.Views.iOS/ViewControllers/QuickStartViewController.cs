namespace StaticBind.Sample.Views.iOS
{
	using System;
	using UIKit;
	using StaticBind.Sample.ViewModels;

	public partial class QuickStartViewController : UIViewController
	{
		public QuickStartViewController (IntPtr handle) : base (handle) {}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.Bind(new QuickStartViewModel());
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			this.Bindings.AreActive = true;
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);

			this.Bindings.AreActive = false;
		}
	}
}
