# Xamarin-LFLiveKit

**Xamarin LFLiveKit is an open source RTMP streaming SDK for Xamarin.iOS.**  

## Features

- [x] 	Background recording
- [x] 	Support horizontal vertical recording
- [x] 	Support Beauty Face With GPUImage
- [x] 	Support H264+AAC Hardware Encoding
- [x] 	Drop frames on bad network 
- [x] 	Dynamic switching rate
- [x] 	Audio configuration
- [x] 	Video configuration
- [x] 	RTMP Transport
- [x] 	Switch camera position
- [x] 	Audio Mute
- [x] 	Support Send Buffer
- [x] 	Support WaterMark
- [x] 	Swift Support
- [x] 	Support Single Video or Audio 
- [x] 	Support External input video or audio(Screen recording or Peripheral)
- [ ] 	~~FLV package and send~~

## Requirements
    - iOS 7.0+
    - Xcode 7.3
  
## Installation
	
## Usage example 

#### C#
```c#
using LFLiveKit;

LFLiveSession session;

var stream = new LFLiveStreamInfo();

stream.Url = rtmpUrl;

session.StartLive(stream);
```

## Credit/Props
 **Xamarin-LFLiveKit is a Xamarin.iOS binding library based on LFLiveKit; https://github.com/LaiFengiOS/LFLiveKit
