// Copyright 2010 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License"); 
// You may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
// CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, 
// MERCHANTABLITY OR NON-INFRINGEMENT. 

// See the Apache 2 License for the specific language governing 
// permissions and limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Microsoft.Synchronization.ClientServices.Configuration
{
    /// <summary>
    /// Represents a collection of SyncScope and its associated SyncTable info
    /// </summary>
    public class SyncScopeCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Creates a new Collection item element.
        /// </summary>
        /// <returns>SyncScopeConfigElement</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new SyncScopeConfigElement();
        }

        /// <summary>
        /// Returns the SyncScopeConfigElement.Name property for the specifed element
        /// </summary>
        /// <param name="element">ConfigurationElement</param>
        /// <returns>Name property</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SyncScopeConfigElement)element).Name;
        }

        /// <summary>
        /// Returns the ConfigurationElementCollectionType type for this collection.
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        /// <summary>
        /// Returns the element name used to represent the collection items
        /// </summary>
        protected override string ElementName
        {
            get
            {
                return "SyncScope";
            }
        }

        /// <summary>
        /// Allows programmatic addition to the Collection
        /// </summary>
        /// <param name="element">Element to add to collection</param>
        public void Add(SyncScopeConfigElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            base.BaseAdd(element, true);
        }

        /// <summary>
        /// Allows programmatic removal from the Collection
        /// </summary>
        /// <param name="elementKey">Element key to remove from collection</param>
        public void Remove(string elementKey)
        {
            if (elementKey == null)
            {
                throw new ArgumentNullException("elementKey");
            }

            base.BaseRemove(elementKey);
        }

        /// <summary>
        /// Allows programmatic retrieval of indexed item from the Collection
        /// </summary>
        /// <param name="index">Index of Element to retrieve</param>
        /// <returns>SyncScopeConfigElement</returns>
        public SyncScopeConfigElement GetElementAt(int index)
        {
            return (SyncScopeConfigElement)base.BaseGet(index);
        }
    }
}
