using Binarysharp.MemoryManagement.Memory;
using System;

namespace Binarysharp.MemoryManagement.Modules
{
    /// <summary>
    ///     Class representing a function in the remote process.
    /// </summary>
    public class RemoteFunction : RemotePointer
    {
        #region Properties

        /// <summary>
        ///     The name of the function.
        /// </summary>
        public string Name { get; private set; }

        #endregion Properties

        #region Constructor

        public RemoteFunction(MemorySharp memorySharp, IntPtr address, string functionName) : base(memorySharp, address)
        {
            // Save the parameter
            Name = functionName;
        }

        #endregion Constructor

        #region Methods

        #region ToString (override)

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return string.Format("BaseAddress = 0x{0:X} Name = {1}", BaseAddress.ToInt64(), Name);
        }

        #endregion ToString (override)

        #endregion Methods
    }
}