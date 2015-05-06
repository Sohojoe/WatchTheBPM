// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WatchBPMWatchKitExtension
{
	[Register ("BPMController")]
	partial class BPMController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceLabel bpmOutputLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceButton tapButton { get; set; }

		[Action ("OnButtonPress:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void OnButtonPress (WatchKit.WKInterfaceButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (bpmOutputLabel != null) {
				bpmOutputLabel.Dispose ();
				bpmOutputLabel = null;
			}
			if (tapButton != null) {
				tapButton.Dispose ();
				tapButton = null;
			}
		}
	}
}
