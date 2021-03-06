﻿using System;

namespace Binarysharp.MemoryManagement.Threading
{
    /// <summary>
    ///     Class containing a frozen thread. If an instance of this class is disposed, its associated thread is resumed.
    /// </summary>
    public class FrozenThread : IDisposable
    {
        #region Properties

        /// <summary>
        ///     The frozen thread.
        /// </summary>
        public RemoteThread Thread { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrozenThread" /> class.
        /// </summary>
        /// <param name="thread">The frozen thread.</param>
        internal FrozenThread(RemoteThread thread)
        {
            // Save the parameter
            Thread = thread;
        }

        #endregion Constructor

        #region Methods

        #region Dispose (implementation of IDisposable)

        /// <summary>
        ///     Releases all resources used by the <see cref="RemoteThread" /> object.
        /// </summary>
        public virtual void Dispose()
        {
            // Unfreeze the thread
            Thread.Resume();
        }

        #endregion Dispose (implementation of IDisposable)

        #region ToString (override)

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Id = {0}", Thread.Id);
        }

        #endregion ToString (override)

        #endregion Methods
    }
}