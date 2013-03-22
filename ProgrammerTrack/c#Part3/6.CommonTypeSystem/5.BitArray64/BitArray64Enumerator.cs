using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ClassBitArray64
{
    class BitArray64Enumerator : IEnumerator<bool>
    {
        private BitArray64 array;
        private int position = -1;

        public BitArray64Enumerator(BitArray64 array)
        {
            this.array = array;
        }

        public bool Current
        {
            get
            {
                try
                {
                    return array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public bool MoveNext()
        {
            this.position++;
            return this.position <= 63;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}