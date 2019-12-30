#region Copyright(c) 2019 by HealthEquity Inc.
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

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SecureDiceRoll
{
  public abstract class PasswordList
  {
    public virtual string FilePath { get; set; } = string.Empty;
    public Dictionary<int, string> List => GetList(FilePath);
    private Dictionary<int, string> GetList(string filePath)
    {
      if (string.IsNullOrWhiteSpace(FilePath))
      {
        return new Dictionary<int, string>();
      }

      var res = File
        .ReadLines(filePath)
        .Select((v, i) => new { Key = v.Split('\t').First(), Value = v.Split('\t').Last() })
        .ToDictionary(g => g.Key.ParseInt(), g => g.Value);
      return res;
    }
  }
}