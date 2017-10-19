using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary
{
    public class Robot : IRobot
    {
        private List<Type> _installedChips = new List<Type>();

        private IChip _chip;

        public Robot(IChip chip)
        {
            
            InstallChip(chip);
        }

        public int TotalChipsInstalled
        {
            get { return _installedChips.Count; }
        }

        public object Execute(object[] input)
        {
            return _chip.Execute(input);
        }

        public void InstallChip(IChip chip)
        {
            if (chip == null)
            {
                throw new ArgumentNullException("chip");
            }

            if (!_installedChips.Contains(chip.GetType()))
            {
                _installedChips.Add(chip.GetType());
            }
            _chip = chip;
        }
    }
}
