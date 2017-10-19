using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary
{
    /// <summary>
    /// An extensible tool to perform operations on arrays based on installed chips
    /// </summary>
    public class Robot
    {
        #region Singleton Instance

        private static Robot _instance;

        /// <summary>
        /// Private constructor enforces singleton
        /// </summary>
        private Robot()
        {
            _installedChips = new List<Type>();
        }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static Robot Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Robot();
                }

                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// List to collect unique types of installed chips
        /// </summary>
        private List<Type> _installedChips;

        /// <summary>
        /// The currently installed chip
        /// </summary>
        private IChip _chip;

        /// <summary>
        /// Returns total count of unique chips installed
        /// </summary>
        public int TotalChipsInstalled
        {
            get { return _installedChips.Count; }
        }

        /// <summary>
        /// Accepts an input array and processes results with installed chip.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public object Execute(object[] input)
        {
            if (_chip == null)
            {
                throw new InvalidOperationException("Chip is required");
            }

            return _chip.Execute(input);
        }

        /// <summary>
        /// Installs chip into robot. Adds unique chip types to internal
        /// list for chip type count history.
        /// </summary>
        /// <param name="chip"></param>
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
