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
using System.Linq;

namespace SecureDiceRoll
{
  public abstract class PassPhrase
  {
    internal virtual Dictionary<int, string> WordList { get; } = new Dictionary<int, string>();
    internal virtual IEnumerable<int> WordsKeys { get; } = Enumerable.Empty<int>();
    internal virtual string PassPhraseHeader { get; } = string.Empty;
    public string PassPhraseString => BuildPassPhrase();
    
    public string BuildPassPhrase()
    {
      var passPhraseGenerator = new PassPhraseGenerator();
      return passPhraseGenerator.BuildPassPhrase(WordsKeys, WordList);
    }

    public override string ToString()
    {
      return !string.IsNullOrWhiteSpace(PassPhraseHeader) ? $"{PassPhraseHeader} {PassPhraseString}" : PassPhraseString;
    }
  }
}