/*
 * Copyright 2011 ODIN Working Group. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Microsoft.Phone.Info;
using System;
using System.Security.Cryptography;

namespace org.odinmobile.windowsphone
{
    public class ODIN
    {

        /// <summary>
        /// Calculates an ODIN-1 hash for WP7
        /// </summary>
        /// 
        /// <returns>A HEX representation of the SHA1 hash of the DeviceUniqueId</returns>
        /// <remarks>ODIN Working Group</remarks>
        public static string GetODIN1()
        {
            
                //Getting the WP7 DeviceUniqueId (requires the ID_CAP_IDENTITY_DEVICE permission  )
                byte[] retVal = null;
                object tmpId;
                if (DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out tmpId))
                    retVal = (byte[])tmpId;
                SHA1Managed sha1 = new SHA1Managed();
                retVal = sha1.ComputeHash(retVal);
                return BitConverter.ToString(retVal).Replace("-", "").ToLower();

        }
    }
}
