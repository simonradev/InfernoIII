namespace InfernoIII
{
    using System;
    using System.Linq;

    public class Startup
    {
        private const string Forge = "Forge";
        private const string Exclude = "Exclude";
        private const string SumLeft = "Sum Left";
        private const string SumRight = "Sum Right";
        private const string SumLeftRight = "Sum Left Right";

        public static void Main()
        {
            Gem[] gems = SplitString(Console.ReadLine(), ' ').Select(g => new Gem(long.Parse(g))).ToArray();

            string inputLine = Console.ReadLine();
            while (inputLine != Forge)
            {
                string[] commandInfo = SplitString(inputLine, ';');

                int leftIndex = 0;
                int rightIndex = 0;

                if (commandInfo[1] == SumLeft)
                {
                    rightIndex = OperationInfo.RightIndexDefaul;
                }
                else if (commandInfo[1] == SumRight)
                {
                    leftIndex = OperationInfo.LeftIndexDefault;
                }

                OperationInfo operationInfo = new OperationInfo(leftIndex, rightIndex, int.Parse(commandInfo[2]));
                Exclusion excludeInfo = commandInfo[0] == Exclude ? Exclusion.Exclude : Exclusion.Reverse;

                Function.TraverseAndModifyTheGems(gems, operationInfo, excludeInfo, Function.SumNeighbourElements);

                inputLine = Console.ReadLine();
            }

            Function.PrintGemsAndSkipCondition(gems, g => g.IsExcluded);
        }

        private static string[] SplitString(string toSplit, char toSplitBy)
        {
            return toSplit.Split(new[] { toSplitBy }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
