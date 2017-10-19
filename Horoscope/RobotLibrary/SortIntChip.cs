using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary
{
    /// <summary>
    /// Sorts an int array with option for ascending or descending
    /// </summary>
    public class SortIntChip : IChip
    {
        public object Execute(object[] input, bool sortAscending = true)
        {
            var list = new List<int>();
            for (var i = 0; i < input.Length; i++)
            {
                var value = 0;
                if (int.TryParse(input[i].ToString(), out value))
                {
                    list.Add(value);
                }
            }

            if (sortAscending)
            {
                return list.OrderBy(i => i).ToArray();
            }
            else
            {
                return list.OrderByDescending(i => i).ToArray();
            }
        }
    }
}
