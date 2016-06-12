namespace Generic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        private int capacity;
        private int count;
        private T[] elements;

        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.elements = new T[capacity];
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < 0 || value > int.MaxValue)
                {
                    throw new ArgumentException("Range of capacity [0 - 2,147,483,647]");
                }

                this.capacity = value;
            }
        }

        public int Count
        { 
            get
            {
                return this.count;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Count should be a positive number!");
                }

                this.count = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException("Index should be between 0 and the length of the list!");
                }

                return this.elements[index];
            }

            set
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Index should be between 0 and the length of the list!");
                }
                else if (index >= this.Capacity)
                {
                    this.IncreaseSize();
                }

                if (this.elements[index] == null || this.elements[index].ToString().Equals("0"))     // if it's an unused index => count grows, otherwise it just rewrites an already existing element in this index
                {
                    this.Count++;
                }

                this.elements[index] = value;
            }
        }

        public void AddElement(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.IncreaseSize();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public void RemoveElement(int index)
        {
            if (index < 0 || index > this.Capacity)
            {
                throw new IndexOutOfRangeException("There is no such index in the list!");
            }
            else if (index > this.Count)
            {
                throw new ArgumentException("There is no element in this position");    // Example: Capacity = 5, Count = 2 ( 0 1 2) -> there are three elements so far, so the 4th element is 0 or null -> no point in removing it
            }

            if (this.Count == 0)
            {
                throw new ArgumentException("The list is empty");
            }
            else
            {
                for (int i = index + 1; i < this.Count; i++)
                {
                    this.elements[i - 1] = this.elements[i];
                }

                this.elements[this.Count - 1] = default(T);
                this.Count--;
            }
        }

        public void InsertElementAtIndex(T element, int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("Index should be between 0 and list capacity");
            }

            var oldElements = this.elements;
            this.Count = 0;
            this.elements = new T[this.Capacity];
            
            for (int i = 0; i < index; i++)
            {
                this.AddElement(oldElements[i]);
            }

            this.AddElement(element);

            for (int i = index + 1; i < oldElements.Length - 1; i++)
            {
                this.AddElement(oldElements[i - 1]);
            } 
        }

        public int FindIndexOf(T value)
        {
            var index = -1;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(value) == 0)
                {
                    return i;                    
                }
            }

            return index;
        }

        public void ClearElements()
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.elements = new T[this.Capacity];
        }        

        public override string ToString()
        {
            var list = new StringBuilder();

            if (this.Count == 0)
            {
                return string.Format("The list is empty!");
            }
            else
            {
                for (int i = 0; i < this.Count; i++)
                {
                    list.Append(this.elements[i] + " ");
                }

                return list.ToString().Trim();
            }            

            // return String.Join(" ", this.elements);
        }

        public T Min()
        {
            if (this.Count <= 0)
            {
                throw new ArgumentException("There are no elements in the list!");
            }

            T min = this.elements[0];

            foreach (var element in this.elements)
            {
                if (element.CompareTo(min) < 0)
                {
                    min = element;
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.Count <= 0)
            {
                throw new ArgumentException("There are no elements in the list!");
            }

            T max = this.elements[0];

            foreach (var element in this.elements)
            {
                if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }

            return max;
        }

        private void IncreaseSize()
        {
            var oldElements = this.elements;
            this.Capacity *= 2;
            this.elements = new T[this.Capacity];
            Array.Copy(oldElements, this.elements, this.Count);
        }
    }
}