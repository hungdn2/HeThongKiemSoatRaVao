using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ozeki.Camera;
using Ozeki.Media;
using Ozeki.MediaGateway;

namespace testcam
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MediaGatewayConfig();
            config.AddConfigElement(new FlashConfig { ServiceName = "rtsp://admin:admin@10.0.4.201:554/cam/realmonitor?channel=1&subtype=00&authbasic=YWRtaW46YWRtaW4=" });

            MyMediaGateway _mediaGateway = new MyMediaGateway(config);
            _mediaGateway.Start();
            Console.Read();
        }
    }
}
