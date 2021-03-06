// <copyright file="PreviewOverlayPayload.cs" company="Microsoft Corporation">
// ===============================================================================
//
//
// Project: Microsoft Silverlight Rough Cut Editor
// FILES: PreviewOverlayPayload.cs                     
//
// ===============================================================================
// Copyright 2010 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// ===============================================================================
// </copyright>

namespace RCE.Infrastructure.Events
{
    using RCE.Infrastructure.Models;

    public class PreviewOverlayPayload
    {
        public PreviewOverlayPayload(OverlayAsset overlayAsset)
        {
            this.OverlayAsset = overlayAsset;
        }

        public OverlayAsset OverlayAsset { get; set; }
    }
}
