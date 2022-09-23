﻿/*-----------------------------------------------------------------------
<copyright file="IRecaptchaModel.cs" company="Environmental Science Associates">
Copyright (c) Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
namespace LtInfo.Common.Interfaces
{
    public interface IRecaptchaModel
    {
       // ReSharper disable InconsistentNaming
        string recaptcha_challenge_field { get; set; }
        string recaptcha_response_field { get; set; }
       // ReSharper restore InconsistentNaming

        string ClientIP { get; set; }
        string ValidationUrl { get; set; }
        string PrivateKey { get; set; }
        bool IsValid { get; set; }        
    }
}
