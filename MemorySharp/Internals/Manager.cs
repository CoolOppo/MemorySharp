﻿using System.Collections.Generic;

namespace Binarysharp.MemoryManagement.Internals
{
    /// <summary>
    ///     Class managing objects implementing <see cref="INamedElement" /> interface.
    /// </summary>
    public abstract class Manager<T> where T : INamedElement
    {
        #region Fields

        /// <summary>
        ///     The collection of the elements (writable).
        /// </summary>
        protected Dictionary<string, T> InternalItems = new Dictionary<string, T>();

        #endregion Fields

        #region Properties

        /// <summary>
        ///     The collection of the elements.
        /// </summary>
        public IReadOnlyDictionary<string, T> Items
        {
            get { return InternalItems; }
        }

        #endregion Properties

        #region Methods

        #region DisableAll

        /// <summary>
        ///     Disables all items in the manager.
        /// </summary>
        public void DisableAll()
        {
            foreach (var item in InternalItems)
            {
                item.Value.Disable();
            }
        }

        #endregion DisableAll

        #region EnableAll

        /// <summary>
        ///     Enables all items in the manager.
        /// </summary>
        public void EnableAll()
        {
            foreach (var item in InternalItems)
            {
                item.Value.Enable();
            }
        }

        #endregion EnableAll

        #region Remove

        /// <summary>
        ///     Removes an element by its name in the manager.
        /// </summary>
        /// <param name="name">The name of the element to remove.</param>
        public void Remove(string name)
        {
            // Check if the element exists in the dictionary
            if (InternalItems.ContainsKey(name))
            {
                try
                {
                    // Dispose the element
                    InternalItems[name].Dispose();
                }
                finally
                {
                    // Remove the element from the dictionary
                    InternalItems.Remove(name);
                }
            }
        }

        /// <summary>
        ///     Remove a given element.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        public void Remove(T item)
        {
            Remove(item.Name);
        }

        #endregion Remove

        #region RemoveAll

        /// <summary>
        ///     Removes all the elements in the manager.
        /// </summary>
        public void RemoveAll()
        {
            // For each element
            foreach (var item in InternalItems)
            {
                // Dispose it
                item.Value.Dispose();
            }
            // Clear the dictionary
            InternalItems.Clear();
        }

        #endregion RemoveAll

        #endregion Methods
    }
}