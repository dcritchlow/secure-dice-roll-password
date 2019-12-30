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
using System.Security.Cryptography;

namespace SecureDiceRoll
{
  public class DiceRoller
  {
    private static readonly RNGCryptoServiceProvider RngCsp = new RNGCryptoServiceProvider();

    // This method simulates a roll of the dice. The input parameter is the
    // number of sides of the dice.
    public static byte RollDice(byte numberSides)
    {
      if (numberSides <= 0)
        throw new ArgumentOutOfRangeException("numberSides");

      // Create a byte array to hold the random value.
      var randomNumber = new byte[1];
      do
      {
        // Fill the array with a random value.
        RngCsp.GetBytes(randomNumber);
      }
      while (!IsFairRoll(randomNumber[0], numberSides));
      // Return the random number mod the number
      // of sides.  The possible values are zero-
      // based, so we add one.
      return (byte)((randomNumber[0] % numberSides) + 1);
    }

    private static bool IsFairRoll(byte roll, byte numSides)
    {
      // There are MaxValue / numSides full sets of numbers that can come up
      // in a single byte.  For instance, if we have a 6 sided die, there are
      // 42 full sets of 1-6 that come up.  The 43rd set is incomplete.
      var fullSetsOfValues = byte.MaxValue / numSides;

      // If the roll is within this range of fair values, then we let it continue.
      // In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use
      // < rather than <= since the = portion allows through an extra 0 value).
      // 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair
      // to use.
      return roll < numSides * fullSetsOfValues;
    }

    public static void Dispose()
    {
      RngCsp.Dispose();
    }
  }
}