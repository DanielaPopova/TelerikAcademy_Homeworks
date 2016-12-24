namespace Generics
{
    using System;
    using System.Text;

    public class GenericList<T>
        where T : IComparable
    {
        private const int DeafultCapacity = 16;
        
        private int capacity;
        private int count;
        private T[] elements;

        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.count = 0;
            this.elements = new T[capacity];
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0 || value > int.MaxValue)
                {
                    throw new ArgumentException(String.Format("Capacity should be in range 0 - {0}", int.MaxValue));
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
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException(String.Format("Index should be in range 0 - {0}", this.count - 1));
                }

                return this.elements[index];
            }           
        }

        public void AddElement(T element)
        {
            if (this.count >= this.Capacity)
            {
                this.DoubleSize();
            }

            this.elements[this.count] = element;
            this.count++;
        }

        public void RemoveElementAt(int index)
        {
            if (this.count == 0)
            {
                throw new ArgumentException("The list is empty!");
            }

            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException(String.Format("Index should be in range 0 - {0}", this.count - 1));
            }

            for (int i = index; i < this.count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.elements[this.count - 1] = default(T);  // last element should be default value since one element is removed and resp. count decrease with 1
            this.count--;
        }

        // Guidance from List<T>.Insert() method - msdn.microsoft.com
        public void InsertElementAt(T element, int index)
        {
            if (index < 0 || index > this.count)
            {
                throw new IndexOutOfRangeException(String.Format("Index should be in range 0 - {0}", this.count - 1));
            }

            if (this.count == this.Capacity)
            {
                this.DoubleSize();
            }

            if (index == this.count)
            {
                this.AddElement(element);                
            }
            else
            {
                var oldElements = this.elements;
                this.count++;
                this.elements = new T[this.count];

                for (int i = this.count - 1; i > index; i--)
                {
                    this.elements[i] = oldElements[i - 1];
                }

                this.elements[index] = element;

                for (int i = index - 1; i >= 0; i--)
                {
                    this.elements[i] = oldElements[i];
                }
            }            
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            this.Capacity = DeafultCapacity;
            this.count = 0;
            this.elements = new T[DeafultCapacity];
        }

        public T Min()
        {
            if (this.count <= 0)
            {
                throw new ArgumentException("There are no elements in the list!");
            }

            T min = this.elements[0];

            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(min) < 0)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.count <= 0)
            {
                throw new ArgumentException("There are no elements in the list!");
            }

            T max = this.elements[0];

            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(max) > 0)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            if (this.count == 0)
            {
                return string.Format("The list is empty!");
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.count; i++)
            {
                result.Append(this.elements[i]);
                if (i < this.count - 1)
                {
                    result.Append(", ");
                }
            }

            return result.ToString();
        }

        private void DoubleSize()
        {
            var oldElements = this.elements;
            this.Capacity *= 2;
            this.elements = new T[this.Capacity];
            Array.Copy(oldElements, this.elements, this.count);
        }
    }
}
