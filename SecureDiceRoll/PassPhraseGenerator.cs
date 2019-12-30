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
  public class PassPhraseGenerator
  {
    private readonly Dictionary<int,string> _officialWordList = new Official().List;
    private readonly Dictionary<int,string> _bealeWordList = new Beale().List;
    private readonly Dictionary<int,string> _combinedWordList = new Combined().List;
    private readonly Dictionary<int,string> _improvedWordList = new Improved().List;
    public IEnumerable<string> GenerateAllPassPhrases(IList<int> words)
    {
      yield return BuildOfficialPassPhrase(words);
      yield return BuildBealePassPhrase(words);
      yield return BuildCombinedPassPhrase(words);
      yield return BuildImprovedPassPhrase(words);
    }

    private string BuildOfficialPassPhrase(IEnumerable<int> words) => $"Official: {BuildPassPhrase(words, _officialWordList)}";
    private string BuildBealePassPhrase(IEnumerable<int> words) => $"Beale: {BuildPassPhrase(words, _bealeWordList)}";
    private string BuildCombinedPassPhrase(IEnumerable<int> words) => $"Combined: {BuildPassPhrase(words, _combinedWordList)}";
    private string BuildImprovedPassPhrase(IEnumerable<int> words) => $"Improved: {BuildPassPhrase(words, _improvedWordList)}";

    public string BuildPassPhrase(IEnumerable<int> words, Dictionary<int, string> wordList)
    {
      string passPhrase;
      var localWordList = words.ToList();
      do
      {
        passPhrase = BuildPotentialPassPhrase(localWordList, wordList);
      } while (passPhrase.Length < 17);

      return passPhrase;
    }

    private static string BuildPotentialPassPhrase(IEnumerable<int> words, IReadOnlyDictionary<int, string> wordList)
    {
      var passPhrase = string.Empty;

      foreach (var word in words)
      {
        var success = wordList.TryGetValue(word, out var result);
        passPhrase += success ? $"{result} " : string.Empty;
      }

      return passPhrase.TrimEnd();
    }
  }
}