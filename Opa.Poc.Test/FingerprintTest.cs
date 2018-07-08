namespace Opa.Poc.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Opa.Poc.Fingerprint.Bridge;
    using Opa.Poc.Fingerprint.Resources;

    /// <summary>
    /// The fingerprint test.
    /// </summary>
    [TestClass]
    public class FingerprintTest
    {
        /// <summary>
        /// The test multiple fingerprint, to use this connect multiple readers.
        /// </summary>
        [TestMethod]
        public void TestMultipleFingerprint()
        {
            var bridge = new ManageFingerprint();
            var result = bridge.CaptureFingerprint();

            Assert.AreEqual(result.Message, es_CO.MultipleReaders);            
        }

        /// <summary>
        /// The test without readers.
        /// </summary>
        [TestMethod]
        public void TestWithoutReaders()
        {
            var bridge = new ManageFingerprint();
            var result = bridge.CaptureFingerprint();

            Assert.AreEqual(result.Message, es_CO.WithoutReader);
        }

        /// <summary>
        /// The test capture.
        /// </summary>
        [TestMethod]
        public void TestCapture()
        {
            var bridge = new ManageFingerprint();
            var result = bridge.CaptureFingerprint();

            Assert.IsTrue(result.Result);
        }
    }
}
