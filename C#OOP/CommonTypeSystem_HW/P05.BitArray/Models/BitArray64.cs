namespace BitArray.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;    
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        private const int Length = 64;
        private int[] bits = new int[Length];

        public BitArray64(ulong number)
        {
            string binary = ConvertDecimalToBinary(number);
            this.bits = BitsIntoArray(binary);
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > Length - 1)
                {
                    throw new ArgumentOutOfRangeException("Index is in range [0 - 63]");
                }

                return this.bits[index];
            }           
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return (first.Equals(second));
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !(first.Equals(second));
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            var otherArray = obj as BitArray64;      

            for (int i = 0; i < Length; i++)
            {
                if (!otherArray[i].Equals(this[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.bits.GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(string.Empty, this.bits);
        }

        private string ConvertDecimalToBinary(ulong number)
        {
            ulong systemBase = 2;
            string binaryRep = String.Empty;

            while (number > 0)
            {
                ulong remainder = number % systemBase;
                number /= systemBase;
                binaryRep = remainder.ToString() + binaryRep;
            }

            return binaryRep.ToString().PadLeft(64, '0');
        }

        private int[] BitsIntoArray(string binary)
        {
            int[] bitArray = new int[64];
            for (int i = 0; i < binary.Length; i++)
            {
                bitArray[i] = int.Parse(binary[i].ToString());
            }

            return bitArray;
        }
    }
}
