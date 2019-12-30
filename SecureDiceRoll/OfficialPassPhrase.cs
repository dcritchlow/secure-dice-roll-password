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

namespace SecureDiceRoll
{
  public class OfficialPassPhrase : PassPhrase
  {
    internal override Dictionary<int, string> WordList => new Official().List;
    internal override IEnumerable<int> WordsKeys { get; }
    internal override string PassPhraseHeader => "Official:";


    public OfficialPassPhrase(IEnumerable<int> wordsKeys)
    {
      WordsKeys = wordsKeys;
    }
  }
}