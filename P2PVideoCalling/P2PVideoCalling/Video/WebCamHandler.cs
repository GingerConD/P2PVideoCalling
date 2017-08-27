using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
using System;
using System.Collections.Generic;

namespace P2PVideoCalling.Video
{
    class WebCamHandler : IVideoHandler
    {
        public void GetVideo()
        {
            var listVideoDevices = new List<EncoderDevice>();
            var listAudioDevices = new List<EncoderDevice>();

            foreach (var edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            {
                listVideoDevices.Add(edv);
            }

            foreach (var edv in EncoderDevices.FindDevices(EncoderDeviceType.Audio))
            {
                listAudioDevices.Add(edv);
            }

            var job = new LiveJob();
            var deviceSource = job.AddDeviceSource(listVideoDevices[0], listAudioDevices[0]);
            job.ActivateSource(deviceSource);
            job.ApplyPreset(LivePresets.VC1HighSpeedBroadband4x3);
            PullBroadcastPublishFormat format = new PullBroadcastPublishFormat();
            format.BroadcastPort = 5001;
            format.MaximumNumberOfConnections = 1;
            job.PublishFormats.Add(format);
            job.StartEncoding();
        }
    }
}
