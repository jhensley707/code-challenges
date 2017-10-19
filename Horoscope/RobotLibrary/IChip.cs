using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary
{
    public interface IChip
    {
        object Execute(object[] input, bool sortAscending = true);
    }
}
