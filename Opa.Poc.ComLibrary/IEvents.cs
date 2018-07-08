using Opa.Poc.ComLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Opa.Poc.ComLibrary
{
    [Guid("8a6ea9b8-f247-42f7-8ddf-45c2c6893ba3")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IEvents
    {
        [DispId(1)]
        void ChangeNitValues(Nit nit);

    }
}
