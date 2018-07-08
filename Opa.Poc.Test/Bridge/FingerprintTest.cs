using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opa.Poc.Fingerprint.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opa.Poc.Fingerprint.Bridge.Tests
{
    [TestClass()]
    public class FingerprintTest
    {
        [TestMethod()]
        public void MatchFingerprintTest()
        {
            var indexFinger = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Fid><Bytes>Rk1SACAyMAAA5gAz/v8AAAD8AUQAxQDFAQAAAFYhgE0AXXVaQEsAN2lYgKYAzX9WQIwAwHtUgMUAk41SQCkAmYFSgMQAWpZRgC4AsoVRQFAAQ25PgG0AtitNgHEA7G1MQKMAoolMgIMAiY1LgHcBCHVKQG8AlYVJQG8AVqlIQHoAkH1IgGsAMwJHQHQAqChHgGUAvS1FQLEA1IJFgF0AP248gG0APK87QHYA/nE7QE0A7hI3gFgAOQA2gHgAgY01gGgAxSE1AHwBBHU0AFMA5Bc0AFMAN2szAFAAD2QtADcA7pAqAAA=</Bytes><Format>1769473</Format><Version>1.0.0</Version></Fid>";
            var midleFinger = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Fid><Bytes>Rk1SACAyMAAA1AAz/v8AAAD8AUQAxQDFAQAAAFYeQFwAPXBkQCAAoH1iQLEAG6JggJAAQV9egN0AcJhdgHwAsYxcgMcAzDpbgIIA6JBbgJ8At5FagKkA+plZQFsAvodZgNIApDtXgG4BEJBXgCoAKhJXgG4Aqy1TgFcAnIJTgCAA535QgEgAaX1PgJUAqI1NgN0A9T5NgDsARhdMQGUAVHxKQEgAfn9IQJ0AoJZIQE8AIm5GgJkAel5GgIoAe3g8AIwAiX8wAJAAg6IsALQBHz8sAAA=</Bytes><Format>1769473</Format><Version>1.0.0</Version></Fid>";
            var resultMatchFingerprint = (new ManageFingerprint()).MatchFingerprint(indexFinger, midleFinger);
            Assert.IsFalse(resultMatchFingerprint);
        }
    }
}