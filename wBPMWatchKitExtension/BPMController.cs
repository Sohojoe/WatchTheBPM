	using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using WatchKit;

namespace WatchBPMWatchKitExtension
{
	partial class BPMController : WatchKit.WKInterfaceController
	{
//		nint clickCount = 0;

		BPMModel bpmModel = new BPMModel();

		public BPMController (IntPtr handle) : base (handle)
		{

		}
		partial void OnButtonPress (WatchKit.WKInterfaceButton sender)
		{
			bpmModel.RecordTap();
			var bpm = Math.Round(bpmModel.MeanBPM);
			var msg = String.Format("{0}", bpm);
			bpmOutputLabel.SetText(msg);

//			WKInterfaceController.OpenParentApplication (new NSDictionary (), (replyInfo, error) => {
//				if(error != null) {
//					Console.WriteLine (error);
//					return;
//				}
//				Console.WriteLine ("parent app responded");
//				// do something with replyInfo[] dictionary
//				var msg = String.Format("{0}", replyInfo["bpm"]);
//				bpmOutputLabel.SetText(msg);
//			});
		}
	}
}
