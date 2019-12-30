using System;
using System.Collections.Generic;

namespace SecureDiceRoll
{
  public class Program
  {
    public static void Main()
    {
      var numberOfWords = 3;
      var specialCharacter = true;
      const int totalRolls = 5;
      var sidesOfDice = new int[6];
      var wordBuilder = new WordBuilder();
      IList<int> wordsKeys = new List<int>();

      for (var i = 0; i < numberOfWords; i++)
      {
        wordsKeys.Add(wordBuilder.BuildWord(totalRolls, sidesOfDice));
      }

      var passPhrase = new ImprovedPassPhrase(wordsKeys).PassPhraseString;
      if (specialCharacter && numberOfWords > 6)
      {
        var specialCharacterGenerator = new SpecialCharacterGenerator();
        passPhrase = specialCharacterGenerator.GenerateSpecialCharacter(sidesOfDice, passPhrase);
      }
      Console.WriteLine(string.Join(Environment.NewLine, passPhrase));
      
      Console.ReadLine();
    }
  }
}
