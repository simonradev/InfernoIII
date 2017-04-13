namespace InfernoIII
{
    using System;
    using System.Text;
    public static class Function
    {
        public static readonly Func<Gem[], OperationInfo, bool> SumNeighbourElements = (gems, operationInfo) =>
                               {
                                   long leftPower = operationInfo.LeftIndex >= 0 ? 
                                                    gems[operationInfo.LeftIndex].Power : 
                                                    0L;
                                   long rightPower = operationInfo.RightIndex < gems.Length ?
                                                     gems[operationInfo.RightIndex].Power :
                                                     0L;

                                   long resultSum = leftPower + gems[operationInfo.CurrIndex].Power + rightPower;

                                   return resultSum == operationInfo.WantedSum;
                               };

        public static readonly Action<Gem[], OperationInfo, Exclusion, Func<Gem[], OperationInfo, bool>> TraverseAndModifyTheGems = 
                               (gems, operationInfo, exclusion, func) =>
                               {
                                   for (int currElement = 0; currElement < gems.Length; currElement++)
                                   {
                                       operationInfo.LeftIndex = currElement - 1;
                                       operationInfo.CurrIndex = currElement;
                                       operationInfo.RightIndex = currElement + 1;

                                       if (func(gems, operationInfo))
                                       {
                                           gems[currElement].SetItemExclusion(exclusion);
                                       }
                                   }
                               };

        public static readonly Action<Gem[], Func<Gem, bool>> PrintGemsAndSkipCondition = (gems, func) =>
                               {
                                   StringBuilder result = new StringBuilder();
                                   foreach (Gem gem in gems)
                                   {
                                       if (func(gem))
                                       {
                                           continue;
                                       }

                                       result.Append(gem.Power);
                                       result.Append(" ");
                                   }

                                   Console.WriteLine(result.ToString());
                               };
    }
}
