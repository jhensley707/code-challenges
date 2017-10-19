using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary
{
    public class TotalSumIntChip : IChip
    {
        public object Execute(object[] input, bool sortAscending = true)
        {
            var sum = 0;
            for(var i = 0; i < input.Length; i++)
            {
                var value = 0;
                if (int.TryParse(input[i].ToString(), out value))
                {
                    sum += value;
                }
            }

            return sum;
        }
    }
}
