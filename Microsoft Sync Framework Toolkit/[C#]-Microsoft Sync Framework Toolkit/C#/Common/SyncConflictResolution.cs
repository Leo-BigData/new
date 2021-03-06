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

#if SERVER
namespace Microsoft.Synchronization.Services
#elif CLIENT
namespace Microsoft.Synchronization.ClientServices
#endif
{
    /// <summary>
    /// Represents the resolution that the server employed to resolve a conflict.
    /// </summary>
    public enum SyncConflictResolution
    {
        /// <summary>
        /// Client version was ignored.
        /// </summary>
        ServerWins,

        /// <summary>
        /// Server version was ignored.
        /// </summary>
        ClientWins,

        /// <summary>
        /// Changes from both server and client version were merged
        /// </summary>
        Merge
    }
}
