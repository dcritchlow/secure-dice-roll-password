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

using System;
using System.Collections.Generic;
using System.Linq;

namespace SecureDiceRoll
{
  public class SpecialCharacterGenerator
  {
    private Dictionary<int, string> _specialCharacterList => new SpecialCharacter().List;
    public string GenerateSpecialCharacter(int[] sidesOfDice, string passPhrase)
    {
      var passPhraseList = passPhrase.Split(' ').ToList();
      var indexOfWordToRemove = DiceRoller.RollDice((byte)sidesOfDice.Length);
      var wordToContainSpecialCharacter = passPhraseList[indexOfWordToRemove];
      var potentialIndexOfLetterToRemove = DiceRoller.RollDice((byte) sidesOfDice.Length);
      var indexOfLetterToReplace = potentialIndexOfLetterToRemove > wordToContainSpecialCharacter.Length - 1 ? wordToContainSpecialCharacter.Length - 1 : potentialIndexOfLetterToRemove;
      var specialCharacterRolls = new List<byte> { DiceRoller.RollDice((byte)sidesOfDice.Length), DiceRoller.RollDice(1) };
      var specialCharacterKey = string.Join("", specialCharacterRolls).ParseInt();
      
      var success = _specialCharacterList.TryGetValue(specialCharacterKey, out var specialCharacter);
      if (!success)
      {
        return passPhrase;
      }
      
      var firstHalfOfWord = wordToContainSpecialCharacter.Substring(0, indexOfLetterToReplace);
      var secondHalfOfWord = wordToContainSpecialCharacter.Substring(indexOfLetterToReplace + 1);
      var newWord = $"{firstHalfOfWord}{specialCharacter}{secondHalfOfWord}";
      passPhraseList.RemoveAt(indexOfWordToRemove);
      passPhraseList.Insert(indexOfWordToRemove, newWord);
      return string.Join(" ", passPhraseList);
    }
  }
}