using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ClassBitArray64
{
    class BitArray64 : IEnumerable<bool>
    {
        private ulong bits;

        public bool this[int index]
        {
            get
            {
                return GetEleemntByIndex(index);
            }
            set
            {
                SetEleemntByIndex(index, value);
            }
        }

        private bool GetEleemntByIndex(int index)
        {
            IsIndexInRange(index);
            bool element = ((this.bits >> index) & 1UL) == 1;
            return element;
        }

        private void SetEleemntByIndex(int index, bool value)
        {
            IsIndexInRange(index);
            if (value)
            {
                this.bits = this.bits | (1UL << index);
            }
            else
            {
                this.bits = this.bits & (~(1UL << index));
            }
        }

        private bool IsIndexInRange(int index)
        {
            if (0 <= index && index <= 63)
            {
                return true;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override bool Equals(object obj)
        {
            BitArray64 other = obj as BitArray64;
            if (other == null)
            {
                return false;
            }
            if (BitArray64.Equals(this.bits, other.bits))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.bits.GetHashCode();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }

        public IEnumerator<bool> GetEnumerator()
        {
            return new BitArray64Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
