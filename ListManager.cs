using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VT24A5
{
    internal class ListManager<T>
    {
        private List<T> internalList;

        // Constructor
        public ListManager()
        {
            internalList = new List<T>();
        }

        // Method to add an item to the list
        public void Add(T item)
        {
            internalList.Add(item);
            OnDisplayInfo();
        }

        // Method to get list
        public List<T> GetList()
        {
            return internalList;
        }

        public event EventHandler<EventArgs> DisplayInfo;

        // Method to trigger DisplayInfo event
        protected virtual void OnDisplayInfo()
        {
            DisplayInfo?.Invoke(this, EventArgs.Empty);
        }


    }

}
