﻿/*-----------------------------------------------------------------------
<copyright file="TcpUtilityTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class TcpUtilityTest
    {
        [Test, Description("An example that it can make a TCP socket connection successfully and do a simple send - receive data exchange")]
        public void CanConnectAndExchangeData()
        {
            const string hostThatSupportsHttp = "www.example.com";
            var result = TcpUtility.SendThenReceiveDataThroughTcp(hostThatSupportsHttp, 80, string.Format(@"GET / HTTP/1.0
Host: {0}

", hostThatSupportsHttp));
            Assert.That(result, Does.Match("HTTP/1.0 [23][0-9][0-9] [A-z0-9 ]+"), "If the TCP socket thingy is working it should be able to make a sample connection such as for an HTTP GET request and get back a 200 or 300 level response");
        }
    }
}
