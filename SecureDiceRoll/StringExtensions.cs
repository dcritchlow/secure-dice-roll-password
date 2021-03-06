﻿#region Copyright(c) 2019 by HealthEquity Inc.
// 
// All Rights Reserved.  Reproduction or transmission in whole or
// in part, in any form or by any means, electronic, mechanical or
// otherwise, is prohibited without the prior written consent of
// copyright owner.
// 
// Property of HealthEquity, Inc.
// 
// HealthEquity, Inc.
// 15 West Scenic Pointe Drive
// Draper, UT 84020
// www.healthequity.com
#endregion

namespace SecureDiceRoll
{
  public static class StringExtensions
  {
    public static int ParseInt(this string stringValue)
    {
      var success = int.TryParse(stringValue, out var returnValue);
      return success ? returnValue : int.MinValue;
    } 
  }
}