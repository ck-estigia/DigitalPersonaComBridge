using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opa.Poc.CallbackCapture.Test
{
    using Opa.Poc.Fingerprint.Bridge;

    class Program
    {
        static void Main(string[] args)
        {
            var bridge = new ManageFingerprint();
            var resultCapture = bridge.CaptureFingerprint();
            if (resultCapture.Result)
            {
                Console.WriteLine(@"Coloque su huella...");
            }
            Console.ReadKey();
        }
    }
}
