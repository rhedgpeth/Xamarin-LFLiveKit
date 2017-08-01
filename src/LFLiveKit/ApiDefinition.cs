using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using System.Runtime.InteropServices;

namespace LFLiveKit
{

	// @interface LFLiveAudioConfiguration : NSObject <NSCoding, NSCopying>
	[BaseType(typeof(NSObject))]
	interface LFLiveAudioConfiguration : INSCoding, INSCopying
	{
		// +(instancetype)defaultConfiguration;
		[Static]
		[Export("defaultConfiguration")]
		LFLiveAudioConfiguration DefaultConfiguration();

		// +(instancetype)defaultConfigurationForQuality:(LFLiveAudioQuality)audioQuality;
		[Static]
		[Export("defaultConfigurationForQuality:")]
		LFLiveAudioConfiguration DefaultConfigurationForQuality(LFLiveAudioQuality audioQuality);

		// @property (assign, nonatomic) NSUInteger numberOfChannels;
		[Export("numberOfChannels")]
		nuint NumberOfChannels { get; set; }

		// @property (assign, nonatomic) LFLiveAudioSampleRate audioSampleRate;
		[Export("audioSampleRate", ArgumentSemantic.Assign)]
		LFLiveAudioSampleRate AudioSampleRate { get; set; }

		// @property (assign, nonatomic) LFLiveAudioBitRate audioBitrate;
		[Export("audioBitrate", ArgumentSemantic.Assign)]
		LFLiveAudioBitRate AudioBitrate { get; set; }

		// @property (readonly, assign, nonatomic) char * asc;
		[Export("asc", ArgumentSemantic.Assign)]
		unsafe IntPtr Asc { get; }

		// @property (readonly, assign, nonatomic) NSUInteger bufferLength;
		[Export("bufferLength")]
		nuint BufferLength { get; }
	}

	// @interface LFLiveVideoConfiguration : NSObject <NSCoding, NSCopying>
	[BaseType(typeof(NSObject))]
	interface LFLiveVideoConfiguration : INSCoding, INSCopying
	{
		// +(instancetype)defaultConfiguration;
		[Static]
		[Export("defaultConfiguration")]
		LFLiveVideoConfiguration DefaultConfiguration();

		// +(instancetype)defaultConfigurationForQuality:(LFLiveVideoQuality)videoQuality;
		[Static]
		[Export("defaultConfigurationForQuality:")]
		LFLiveVideoConfiguration DefaultConfigurationForQuality(LFLiveVideoQuality videoQuality);

		// +(instancetype)defaultConfigurationForQuality:(LFLiveVideoQuality)videoQuality outputImageOrientation:(UIInterfaceOrientation)outputImageOrientation;
		[Static]
		[Export("defaultConfigurationForQuality:outputImageOrientation:")]
		LFLiveVideoConfiguration DefaultConfigurationForQuality(LFLiveVideoQuality videoQuality, UIInterfaceOrientation outputImageOrientation);

		// @property (assign, nonatomic) CGSize videoSize;
		[Export("videoSize", ArgumentSemantic.Assign)]
		CGSize VideoSize { get; set; }

		// @property (assign, nonatomic) BOOL videoSizeRespectingAspectRatio;
		[Export("videoSizeRespectingAspectRatio")]
		bool VideoSizeRespectingAspectRatio { get; set; }

		// @property (assign, nonatomic) UIInterfaceOrientation outputImageOrientation;
		[Export("outputImageOrientation", ArgumentSemantic.Assign)]
		UIInterfaceOrientation OutputImageOrientation { get; set; }

		// @property (assign, nonatomic) BOOL autorotate;
		[Export("autorotate")]
		bool Autorotate { get; set; }

		// @property (assign, nonatomic) NSUInteger videoFrameRate;
		[Export("videoFrameRate")]
		nuint VideoFrameRate { get; set; }

		// @property (assign, nonatomic) NSUInteger videoMaxFrameRate;
		[Export("videoMaxFrameRate")]
		nuint VideoMaxFrameRate { get; set; }

		// @property (assign, nonatomic) NSUInteger videoMinFrameRate;
		[Export("videoMinFrameRate")]
		nuint VideoMinFrameRate { get; set; }

		// @property (assign, nonatomic) NSUInteger videoMaxKeyframeInterval;
		[Export("videoMaxKeyframeInterval")]
		nuint VideoMaxKeyframeInterval { get; set; }

		// @property (assign, nonatomic) NSUInteger videoBitRate;
		[Export("videoBitRate")]
		nuint VideoBitRate { get; set; }

		// @property (assign, nonatomic) NSUInteger videoMaxBitRate;
		[Export("videoMaxBitRate")]
		nuint VideoMaxBitRate { get; set; }

		// @property (assign, nonatomic) NSUInteger videoMinBitRate;
		[Export("videoMinBitRate")]
		nuint VideoMinBitRate { get; set; }

		// @property (assign, nonatomic) LFLiveVideoSessionPreset sessionPreset;
		[Export("sessionPreset", ArgumentSemantic.Assign)]
		LFLiveVideoSessionPreset SessionPreset { get; set; }

		// @property (readonly, assign, nonatomic) NSString * avSessionPreset;
		[Export("avSessionPreset")]
		string AvSessionPreset { get; }

		// @property (readonly, assign, nonatomic) BOOL landscape;
		[Export("landscape")]
		bool Landscape { get; }
	}

	// @interface LFLiveStreamInfo : NSObject
	[BaseType(typeof(NSObject))]
	interface LFLiveStreamInfo
	{
		// @property (copy, nonatomic) NSString * streamId;
		[Export("streamId")]
		string StreamId { get; set; }

		// @property (copy, nonatomic) NSString * host;
		[Export("host")]
		string Host { get; set; }

		// @property (assign, nonatomic) NSInteger port;
		[Export("port")]
		nint Port { get; set; }

		// @property (copy, nonatomic) NSString * url;
		[Export("url")]
		string Url { get; set; }

		// @property (nonatomic, strong) LFLiveAudioConfiguration * audioConfiguration;
		[Export("audioConfiguration", ArgumentSemantic.Strong)]
		LFLiveAudioConfiguration AudioConfiguration { get; set; }

		// @property (nonatomic, strong) LFLiveVideoConfiguration * videoConfiguration;
		[Export("videoConfiguration", ArgumentSemantic.Strong)]
		LFLiveVideoConfiguration VideoConfiguration { get; set; }
	}

	// @interface LFFrame : NSObject
	[BaseType(typeof(NSObject))]
	interface LFFrame
	{
		// @property (assign, nonatomic) uint64_t timestamp;
		[Export("timestamp")]
		ulong Timestamp { get; set; }

		// @property (nonatomic, strong) NSData * data;
		[Export("data", ArgumentSemantic.Strong)]
		NSData Data { get; set; }

		// @property (nonatomic, strong) NSData * header;
		[Export("header", ArgumentSemantic.Strong)]
		NSData Header { get; set; }
	}

	// @interface LFAudioFrame : LFFrame
	[BaseType(typeof(LFFrame))]
	interface LFAudioFrame
	{
		// @property (nonatomic, strong) NSData * audioInfo;
		[Export("audioInfo", ArgumentSemantic.Strong)]
		NSData AudioInfo { get; set; }
	}

	// @interface LFVideoFrame : LFFrame
	[BaseType(typeof(LFFrame))]
	interface LFVideoFrame
	{
		// @property (assign, nonatomic) BOOL isKeyFrame;
		[Export("isKeyFrame")]
		bool IsKeyFrame { get; set; }

		// @property (nonatomic, strong) NSData * sps;
		[Export("sps", ArgumentSemantic.Strong)]
		NSData Sps { get; set; }

		// @property (nonatomic, strong) NSData * pps;
		[Export("pps", ArgumentSemantic.Strong)]
		NSData Pps { get; set; }
	}

	// @interface LFLiveDebug : NSObject
	[BaseType(typeof(NSObject))]
	interface LFLiveDebug
	{
		// @property (copy, nonatomic) NSString * streamId;
		[Export("streamId")]
		string StreamId { get; set; }

		// @property (copy, nonatomic) NSString * uploadUrl;
		[Export("uploadUrl")]
		string UploadUrl { get; set; }

		// @property (assign, nonatomic) CGSize videoSize;
		[Export("videoSize", ArgumentSemantic.Assign)]
		CGSize VideoSize { get; set; }

		// @property (assign, nonatomic) BOOL isRtmp;
		[Export("isRtmp")]
		bool IsRtmp { get; set; }

		// @property (assign, nonatomic) CGFloat elapsedMilli;
		[Export("elapsedMilli")]
		nfloat ElapsedMilli { get; set; }

		// @property (assign, nonatomic) CGFloat timeStamp;
		[Export("timeStamp")]
		nfloat TimeStamp { get; set; }

		// @property (assign, nonatomic) CGFloat dataFlow;
		[Export("dataFlow")]
		nfloat DataFlow { get; set; }

		// @property (assign, nonatomic) CGFloat bandwidth;
		[Export("bandwidth")]
		nfloat Bandwidth { get; set; }

		// @property (assign, nonatomic) CGFloat currentBandwidth;
		[Export("currentBandwidth")]
		nfloat CurrentBandwidth { get; set; }

		// @property (assign, nonatomic) NSInteger dropFrame;
		[Export("dropFrame")]
		nint DropFrame { get; set; }

		// @property (assign, nonatomic) NSInteger totalFrame;
		[Export("totalFrame")]
		nint TotalFrame { get; set; }

		// @property (assign, nonatomic) NSInteger capturedAudioCount;
		[Export("capturedAudioCount")]
		nint CapturedAudioCount { get; set; }

		// @property (assign, nonatomic) NSInteger capturedVideoCount;
		[Export("capturedVideoCount")]
		nint CapturedVideoCount { get; set; }

		// @property (assign, nonatomic) NSInteger currentCapturedAudioCount;
		[Export("currentCapturedAudioCount")]
		nint CurrentCapturedAudioCount { get; set; }

		// @property (assign, nonatomic) NSInteger currentCapturedVideoCount;
		[Export("currentCapturedVideoCount")]
		nint CurrentCapturedVideoCount { get; set; }

		// @property (assign, nonatomic) NSInteger unSendCount;
		[Export("unSendCount")]
		nint UnSendCount { get; set; }
	}

	// @protocol LFLiveSessionDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface LFLiveSessionDelegate
	{
		// @optional -(void)liveSession:(LFLiveSession * _Nullable)session liveStateDidChange:(LFLiveState)state;
		[Export("liveSession:liveStateDidChange:")]
		void LiveStateDidChange([NullAllowed] LFLiveSession session, LFLiveState state);

		// @optional -(void)liveSession:(LFLiveSession * _Nullable)session debugInfo:(LFLiveDebug * _Nullable)debugInfo;
		[Export("liveSession:debugInfo:")]
		void DebugInfo([NullAllowed] LFLiveSession session, [NullAllowed] LFLiveDebug debugInfo);

		// @optional -(void)liveSession:(LFLiveSession * _Nullable)session errorCode:(LFLiveSocketErrorCode)errorCode;
		[Export("liveSession:errorCode:")]
		void ErrorCode([NullAllowed] LFLiveSession session, LFLiveSocketErrorCode errorCode);
	}

	// @interface LFLiveSession : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface LFLiveSession
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		LFLiveSessionDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<LFLiveSessionDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL running;
		[Export("running")]
		bool Running { get; set; }

		// @property (nonatomic, strong) UIView * _Null_unspecified preView;
		[Export("preView", ArgumentSemantic.Strong)]
		UIView PreView { get; set; }

		// @property (assign, nonatomic) AVCaptureDevicePosition captureDevicePosition;
		//[Export("captureDevicePosition", ArgumentSemantic.Assign)]
		//AVCaptureDevicePosition CaptureDevicePosition { get; set; }

		// @property (assign, nonatomic) BOOL beautyFace;
		[Export("beautyFace")]
		bool BeautyFace { get; set; }

		// @property (assign, nonatomic) CGFloat beautyLevel;
		[Export("beautyLevel")]
		nfloat BeautyLevel { get; set; }

		// @property (assign, nonatomic) CGFloat brightLevel;
		[Export("brightLevel")]
		nfloat BrightLevel { get; set; }

		// @property (assign, nonatomic) CGFloat zoomScale;
		[Export("zoomScale")]
		nfloat ZoomScale { get; set; }

		// @property (assign, nonatomic) BOOL torch;
		[Export("torch")]
		bool Torch { get; set; }

		// @property (assign, nonatomic) BOOL mirror;
		[Export("mirror")]
		bool Mirror { get; set; }

		// @property (assign, nonatomic) BOOL muted;
		[Export("muted")]
		bool Muted { get; set; }

		// @property (assign, nonatomic) BOOL adaptiveBitrate;
		[Export("adaptiveBitrate")]
		bool AdaptiveBitrate { get; set; }

		// @property (readonly, nonatomic, strong) LFLiveStreamInfo * _Nullable streamInfo;
		[NullAllowed, Export("streamInfo", ArgumentSemantic.Strong)]
		LFLiveStreamInfo StreamInfo { get; }

		// @property (readonly, assign, nonatomic) LFLiveState state;
		[Export("state", ArgumentSemantic.Assign)]
		LFLiveState State { get; }

		// @property (readonly, assign, nonatomic) LFLiveCaptureTypeMask captureType;
		[Export("captureType", ArgumentSemantic.Assign)]
		LFLiveCaptureTypeMask CaptureType { get; }

		// @property (assign, nonatomic) BOOL showDebugInfo;
		[Export("showDebugInfo")]
		bool ShowDebugInfo { get; set; }

		// @property (assign, nonatomic) NSUInteger reconnectInterval;
		[Export("reconnectInterval")]
		nuint ReconnectInterval { get; set; }

		// @property (assign, nonatomic) NSUInteger reconnectCount;
		[Export("reconnectCount")]
		nuint ReconnectCount { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable warterMarkView;
		[NullAllowed, Export("warterMarkView", ArgumentSemantic.Strong)]
		UIView WarterMarkView { get; set; }

		// @property (readonly, nonatomic, strong) UIImage * _Nullable currentImage;
		[NullAllowed, Export("currentImage", ArgumentSemantic.Strong)]
		UIImage CurrentImage { get; }

		// @property (assign, nonatomic) BOOL saveLocalVideo;
		[Export("saveLocalVideo")]
		bool SaveLocalVideo { get; set; }

		// @property (nonatomic, strong) NSURL * _Nullable saveLocalVideoPath;
		[NullAllowed, Export("saveLocalVideoPath", ArgumentSemantic.Strong)]
		NSUrl SaveLocalVideoPath { get; set; }

		// -(instancetype _Nullable)initWithAudioConfiguration:(LFLiveAudioConfiguration * _Nullable)audioConfiguration videoConfiguration:(LFLiveVideoConfiguration * _Nullable)videoConfiguration;
        [Export("initWithAudioConfiguration:videoConfiguration:")]
		IntPtr Constructor([NullAllowed] LFLiveAudioConfiguration audioConfiguration, [NullAllowed] LFLiveVideoConfiguration videoConfiguration);

		// -(instancetype _Nullable)initWithAudioConfiguration:(LFLiveAudioConfiguration * _Nullable)audioConfiguration videoConfiguration:(LFLiveVideoConfiguration * _Nullable)videoConfiguration captureType:(LFLiveCaptureTypeMask)captureType __attribute__((objc_designated_initializer));
        [Export("initWithAudioConfiguration:videoConfiguration:captureType:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] LFLiveAudioConfiguration audioConfiguration, [NullAllowed] LFLiveVideoConfiguration videoConfiguration, LFLiveCaptureTypeMask captureType);

		// -(void)startLive:(LFLiveStreamInfo * _Nonnull)streamInfo;
		[Export("startLive:")]
		void StartLive(LFLiveStreamInfo streamInfo);

		// -(void)stopLive;
		[Export("stopLive")]
		void StopLive();

		// -(void)pushVideo:(CVPixelBufferRef _Nullable)pixelBuffer;
		//[Export("pushVideo:")]
		//unsafe void PushVideo([NullAllowed] CVPixelBufferRef* pixelBuffer);

		// -(void)pushAudio:(NSData * _Nullable)audioData;
		[Export("pushAudio:")]
		void PushAudio([NullAllowed] NSData audioData);
	}

	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double LFLiveKitVersionNumber;
		[Field("LFLiveKitVersionNumber", "__Internal")]
		double LFLiveKitVersionNumber { get; }

		// extern const unsigned char [] LFLiveKitVersionString;
		[Field("LFLiveKitVersionString", "__Internal")]
		IntPtr LFLiveKitVersionString { get; }
	}

}
