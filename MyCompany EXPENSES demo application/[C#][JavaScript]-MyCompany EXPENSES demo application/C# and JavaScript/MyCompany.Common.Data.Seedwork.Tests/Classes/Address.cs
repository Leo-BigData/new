//===================================================================================
// Microsoft Developer & Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftnlayerapp.codeplex.com/license
//===================================================================================

namespace MyCompany.Common.Data.Seedwork.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyCompany.Common.Data.Seedwork;



    public class Address
        :ValueObject<Address>
    {
        public string StreetLine1 { get; private set; }
        public string StreetLine2 { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string streetLine1, string streetLine2, string city, string zipCode)
        {
            this.StreetLine1 = streetLine1;
            this.StreetLine2 = streetLine2;
            this.City = city;
            this.ZipCode = zipCode;
        }
    }
}
