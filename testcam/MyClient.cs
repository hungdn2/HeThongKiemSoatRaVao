using System;
using System.Collections.Generic;
using System.Text;
using Ozeki.Camera;
using Ozeki.Media;
using Ozeki.MediaGateway;

namespace testcam
{
    class MyClient
    {
        class MyClient
        {
            private IClient _client;
            private IStreamService _streamService;
            private IMediaStream _mediaStream;
            private MediaGatewayVideoReceiver _videoReceiver;
            private MediaConnector _connector;
            private IIPCamera _camera;

            public MyClient(IClient client, IStreamService streamService)
            {
                this._client = client;
                this._streamService = streamService;
                _connector = new MediaConnector();
            }

            internal void ConnectCamera(string uri)
            {
                // Connect to the camera
                if (String.IsNullOrEmpty(uri)) return;

                _camera = IPCameraFactory.GetCamera(uri, "admin", "admin");
                _camera.Start();

                if (_camera == null)
                {
                    NotifyCameraStateChanged(IPCameraState.Error);
                    return;
                }
                // Notify the client about the camera state
                NotifyCameraStateChanged(IPCameraState.Connected);

                // Start the stream
                var playStreamName = Guid.NewGuid().ToString();
                _mediaStream = _streamService.CreateStream(playStreamName);
                _videoReceiver = new MediaGatewayVideoReceiver(_mediaStream);

                _connector.Connect(_camera.VideoChannel, _videoReceiver);

                // Notify the client about the stream name
                OnPlayRemoteStream(playStreamName);
            }

            internal void DisconnectCamera()
            {
                if (_camera == null) return;
                _camera.Disconnect();

                _connector.Disconnect(_camera.VideoChannel, _videoReceiver);

                _videoReceiver.Dispose();
                _mediaStream.Close();

                NotifyCameraStateChanged(IPCameraState.Disconnected);
            }

            private void NotifyCameraStateChanged(IPCameraState state)
            {
                try
                {
                    _client.InvokeMethod("OnCameraStateChanged", state);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            void OnPlayRemoteStream(string streamName)
            {
                try
                {
                    _client.InvokeMethod("OnPlayRemoteStream", streamName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
