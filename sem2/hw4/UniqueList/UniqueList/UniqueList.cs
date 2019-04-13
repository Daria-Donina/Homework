using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList
{
    public class UniqueList : List
    {
        /// <summary>
        /// Adds new data at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to add a new string.</param>
        /// <param name="data">A new string to add.</param>
        public override void Add(int position, string data)
        {
            if (Exists(data))
            {
                throw new ValueIsInTheListException();
            }

            base.Add(position, data);
        }

        /// <summary>
        /// Sets new data at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to set new data.</param>
        /// <param name="data">A new string to add.</param>
        public override void SetData(int position, string data)
        {
            if (Exists(data))
            {
                throw new ValueIsInTheListException();
            }

            base.SetData(position, data);
        }
    }
}
