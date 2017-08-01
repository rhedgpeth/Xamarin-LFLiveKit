using System;
using ObjCRuntime;

namespace LFLiveKit
{
    [Native]
	public enum LFLiveAudioBitRate : long
	{
	    LFLiveAudioBitRate_32Kbps = 32000,
	    LFLiveAudioBitRate_64Kbps = 64000,
	    LFLiveAudioBitRate_96Kbps = 96000,
	    LFLiveAudioBitRate_128Kbps = 128000,
	    Default = LFLiveAudioBitRate_96Kbps
	}

	[Native]
	public enum LFLiveAudioSampleRate : long
	{
	    LFLiveAudioSampleRate_16000Hz = 16000,
	    LFLiveAudioSampleRate_44100Hz = 44100,
	    LFLiveAudioSampleRate_48000Hz = 48000,
	    Default = LFLiveAudioSampleRate_44100Hz
	}

	[Native]
	public enum LFLiveAudioQuality : long
	{
	    Low = 0,
	    Medium = 1,
	    High = 2,
	    VeryHigh = 3,
	    Default = High
	}

	[Native]
	public enum LFLiveVideoSessionPreset : long
	{
	    LFCaptureSessionPreset360x640 = 0,
	    LFCaptureSessionPreset540x960 = 1,
	    LFCaptureSessionPreset720x1280 = 2
	}

	[Native]
	public enum LFLiveVideoQuality : ulong
	{
	    Low1 = 0,
	    Low2 = 1,
	    Low3 = 2,
	    Medium1 = 3,
	    Medium2 = 4,
	    Medium3 = 5,
	    High1 = 6,
	    High2 = 7,
	    High3 = 8,
	    Default = Low2
	}

	[Native]
	public enum LFLiveState : long
	{
	    Ready = 0,
	    Pending = 1,
	    Start = 2,
	    Stop = 3,
	    Error = 4,
	    Refresh = 5
	}

	[Native]
	public enum LFLiveSocketErrorCode : ulong
	{
	    PreView = 201,
	    GetStreamInfo = 202,
	    ConnectSocket = 203,
	    Verification = 204,
	    ReConnectTimeOut = 205
	}

	[Native]
	public enum LFLiveCaptureType : int
	{
	    CaptureAudio,
	    CaptureVideo,
	    InputAudio,
	    InputVideo
	}

	[Native]
	public enum LFLiveCaptureTypeMask : ulong
	{
	    CaptureMaskAudio = (1 << LFLiveCaptureType.CaptureAudio),
	    CaptureMaskVideo = (1 << LFLiveCaptureType.CaptureVideo),
	    InputMaskAudio = (1 << LFLiveCaptureType.InputAudio),
	    InputMaskVideo = (1 << LFLiveCaptureType.InputVideo),
	    CaptureMaskAll = (CaptureMaskAudio | CaptureMaskVideo),
	    InputMaskAll = (InputMaskAudio | InputMaskVideo),
	    CaptureMaskAudioInputVideo = (CaptureMaskAudio | InputMaskVideo),
	    CaptureMaskVideoInputAudio = (CaptureMaskVideo | InputMaskAudio),
	    CaptureDefaultMask = CaptureMaskAll
	}
}
