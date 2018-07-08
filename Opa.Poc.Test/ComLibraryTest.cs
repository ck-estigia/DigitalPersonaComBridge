using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Opa.Poc.Test
{
    using Opa.Poc.ComLibrary;
    using Opa.Poc.ComLibrary.DTO;

    [TestClass]
    public class ComLibraryTest 
    {
        [TestMethod]
        public void TestReflectionMethodsAttribute()
        {
            var comLibrary = new ManageImage();
            var nit = new Nit() { NitId = "71527386", NombreNit = "Cristian Gonzalez"};
            var objectGeneric = comLibrary.GetNit(nit);

            Assert.AreEqual(objectGeneric.NitId,"71527386");
        }
    }
}
