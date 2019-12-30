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
  public class WordBuilder
  {

    public int BuildWord(int totalRolls, int[] sidesOfDice)
    {
      var rolls = new List<int>();
      for (var x = 0; x < totalRolls; x++)
      {
        var roll = DiceRoller.RollDice((byte)sidesOfDice.Length);
        rolls.Add(roll);
        sidesOfDice[roll - 1]++;
      }
      DiceRoller.Dispose();
      return string.Join("", rolls).ParseInt();
    }
  }
}