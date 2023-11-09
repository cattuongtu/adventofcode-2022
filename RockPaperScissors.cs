using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Program2
{
    public static void Main()
    {

        // Read the text file line by line.
        string textFile = "RockPaperScissors.txt";
        string[] lines = File.ReadAllLines(textFile);
        // A = ROCK = 1, B = PAPER = 2, C = SCISSORS = 3 - What your opponent is going to play
        // X = LOSS, Y = DRAW, Z = WIN - What you should play
        // Score = shape you selected (1-rock,2-paper,3-scissors) + outcome (0-L, 3-D, 6-W)
        int totalScore = 0;
        foreach (string line in lines)
        {
            switch (line)
            {
                case "A X":
                    totalScore += 0 + 3;
                    break;
                case "A Y":
                    totalScore += 3 + 1;
                    break;
                case "A Z":
                    totalScore += 6 + 2;
                    break;
                case "B X":
                    totalScore += 0 + 1;
                    break;
                case "B Y":
                    totalScore += 3 + 2;
                    break;
                case "B Z":
                    totalScore += 6 + 3;
                    break;
                case "C X":
                    totalScore += 0 + 2;
                    break;
                case "C Y":
                    totalScore += 3 + 3;
                    break;
                case "C Z":
                    totalScore += 6 + 1;
                    break;
            }
        }
        Console.WriteLine(totalScore);
     }
    
}

