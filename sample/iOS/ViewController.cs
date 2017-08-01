using System;
using UIKit;
using LFLiveKit;
using AVFoundation;
using System.Threading.Tasks;
using CoreGraphics;

namespace Sample.iOS
{
    public partial class ViewController : UIViewController, ILFLiveSessionDelegate
    {
        // TODO: Put your RTMP URL here
        const string rtmpUrl = "rtmp://xxx.xxx.x.xxx.x/live";

		LFLiveSession session;

        UIView containerView;
        UILabel stateLabel;
        UIButton closeButton;
        UIButton beautyButton;
        UIButton cameraButton;
        UIButton startLiveButton;

        public ViewController(IntPtr handle) : base(handle)
        {
            session = new LFLiveSession(LFLiveAudioConfiguration.DefaultConfigurationForQuality(LFLiveAudioQuality.High),
                                        LFLiveVideoConfiguration.DefaultConfigurationForQuality((LFLiveVideoQuality.Low3)));

            containerView = new UIView(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height));
            containerView.BackgroundColor = UIColor.Clear;
            containerView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            stateLabel = new UILabel(new CGRect(20, 20, 120, 40));
            stateLabel.Text = "Not Recording";
            stateLabel.TextColor = UIColor.White;
            stateLabel.Font = UIFont.SystemFontOfSize(14);

            closeButton = new UIButton(new CGRect(UIScreen.MainScreen.Bounds.Width - 10 - 44, 20, 44, 44));
            closeButton.SetTitle("Close", UIControlState.Normal);

            cameraButton = new UIButton(new CGRect(UIScreen.MainScreen.Bounds.Width - 54 * 2, 20, 44, 44));
            cameraButton.SetTitle("Camera Preview", UIControlState.Normal);

            beautyButton = new UIButton(new CGRect(UIScreen.MainScreen.Bounds.Width - 54 * 3, 20, 44, 44));
            beautyButton.SetTitle("Camera Beauty Open", UIControlState.Selected);
            beautyButton.SetTitle("Camera Beauty Closed", UIControlState.Normal);

            startLiveButton = new UIButton(new CGRect(30, UIScreen.MainScreen.Bounds.Height - 50, UIScreen.MainScreen.Bounds.Width - 10 - 44, 44));
            startLiveButton.Layer.CornerRadius = 22;
            startLiveButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            startLiveButton.SetTitle("Start Live", UIControlState.Normal);
            startLiveButton.TitleLabel.Font = UIFont.SystemFontOfSize(14);
            startLiveButton.BackgroundColor = new UIColor(50, 32, 245, 1);
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var lfLiveSessionDelegate = new MyLFLiveSessionDelegate(LiveSessionChanged);

            session.Delegate = lfLiveSessionDelegate;
            session.PreView = this.View;

            await RequestAccessForVideo();

            View.BackgroundColor = UIColor.Clear;
            View.AddSubview(containerView);

            containerView.AddSubview(stateLabel);
            containerView.AddSubview(closeButton);
            containerView.AddSubview(beautyButton);
            containerView.AddSubview(cameraButton);
            containerView.AddSubview(startLiveButton);

            cameraButton.TouchUpInside += DidTappedCameraButton;
            beautyButton.TouchUpInside += DidTappedBeautyButton;
            startLiveButton.TouchUpInside += DidTappedStartLiveButton;
		}

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();

			cameraButton.TouchUpInside -= DidTappedCameraButton;
			beautyButton.TouchUpInside -= DidTappedBeautyButton;
			startLiveButton.TouchUpInside += DidTappedStartLiveButton;
        }

        void LiveSessionChanged(string stateChangeDescription, bool turnLiveOff)
        {
            stateLabel.Text = stateChangeDescription;

            if (turnLiveOff)
                ToggleLiveStream(false);
        }

        void DidTappedCameraButton(object sender, EventArgs e)
        {
            // TODO
        }

        void DidTappedBeautyButton(object sender, EventArgs e)
        {
			session.BeautyFace = !session.BeautyFace;
			beautyButton.Selected = !session.BeautyFace;
        }

        void DidTappedStartLiveButton(object sender, EventArgs e)
        {
            startLiveButton.Selected = !startLiveButton.Selected;

            if (startLiveButton.Selected)
            {
                var stream = new LFLiveStreamInfo();

				// ******************************************************************************************************************************************
				// Example of setting the Host, Port, and StreamId outside of the URL
				//stream.Host = "xxx.xxx.x.xxx";
				//stream.Port = 1935;
				//stream.StreamId = "stream1";
				// ******************************************************************************************************************************************

                // Set the RTMP (Real-Time Message Protocol) URL. This is where the encoded RTMP data will be pushed to.
				stream.Url = rtmpUrl;

				var audioConfiguration = new LFLiveAudioConfiguration
                {
                     AudioBitrate = LFLiveAudioBitRate.LFLiveAudioBitRate_96Kbps,
                     AudioSampleRate = LFLiveAudioSampleRate.LFLiveAudioSampleRate_44100Hz
                };

                var videoConfiguration = new LFLiveVideoConfiguration
                {
                    VideoFrameRate = 30,
                    VideoMaxFrameRate = 30,
                    VideoMinFrameRate = 30,
                    VideoBitRate = 4200,
                    VideoMaxBitRate = 4200,
                    VideoMinBitRate = 4200,
                    VideoMaxKeyframeInterval = 60,
                    SessionPreset = LFLiveVideoSessionPreset.LFCaptureSessionPreset720x1280,
                    VideoSize = new CGSize(720, 1280)
                };

                stream.AudioConfiguration = audioConfiguration;
                stream.VideoConfiguration = videoConfiguration;

                session.AdaptiveBitrate = false;
                session.ReconnectCount = 10;

                ToggleLiveStream(true, stream);

                var info = session.StreamInfo;
			}
            else
            {
                ToggleLiveStream(false);  
            }
        }

        void ToggleLiveStream(bool startLive, LFLiveStreamInfo stream = null)
        {
            if (startLive && stream != null)
            {
                startLiveButton.SetTitle("End Live", UIControlState.Normal); 
                session.StartLive(stream);
            }
            else
            {
				startLiveButton.SetTitle("Start Live", UIControlState.Normal);
				session.StopLive();
            }
        }

        async Task RequestAccessForVideo()
        {
            var status = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);

            switch (status)
            {
                case AVAuthorizationStatus.NotDetermined:
                    var granted = await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
                    if (granted)
                        session.Running = true;
                    break;
                case AVAuthorizationStatus.Authorized:
                    session.Running = true;
                    break;
                case AVAuthorizationStatus.Denied:
                case AVAuthorizationStatus.Restricted:
                default:
                    break;
            }
        }
    }

    public class MyLFLiveSessionDelegate : LFLiveSessionDelegate, ILFLiveSessionDelegate
    {
        Action<string, bool> liveSessionChanged;

        public MyLFLiveSessionDelegate(Action<string, bool> LiveSessionChanged)
        {
            liveSessionChanged = LiveSessionChanged;
        }

        public override void LiveStateDidChange(LFLiveSession session, LFLiveState state)
        {
            string stateChangeDescription = null;
            bool turnLiveOff = false;

            switch (state)
            {
                case LFLiveState.Refresh:
                case LFLiveState.Pending:
                    stateChangeDescription = "Connecting";
                    break;
                case LFLiveState.Start:
                    stateChangeDescription = "Connected";
                    break;
                case LFLiveState.Error:
                    stateChangeDescription = "Connection Error";
                    turnLiveOff = true;
                    break;
                case LFLiveState.Ready:
                case LFLiveState.Stop:
                    stateChangeDescription = "Not Connected";
                    turnLiveOff = true;
                    break;
            }

            if (!string.IsNullOrEmpty(stateChangeDescription))
                liveSessionChanged?.Invoke(stateChangeDescription, turnLiveOff);
        }

        public override void ErrorCode(LFLiveSession session, LFLiveSocketErrorCode errorCode)
        {
            //base.ErrorCode(session, errorCode);
            //Console.WriteLine("ERROR: " + errorCode.raw);
        }

        public override void DebugInfo(LFLiveSession session, LFLiveDebug debugInfo)
        {
            base.DebugInfo(session, debugInfo);
        }
    }
}
