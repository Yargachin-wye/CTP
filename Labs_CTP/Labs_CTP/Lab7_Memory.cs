using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CTP
{
    public class Memory<T> where T : new()
    {
        public T data;
        private bool fState = false;

        public Memory()
        {
            data = new T();
            fState = false;
        }

        public void WriteMemory(T number)
        {
            data = number;
            fState = true;
        }

        public T Get()
        {
            fState = true;
            return data;
        }

        public void Add(T addComplex)
        {
            data = (dynamic)addComplex + (dynamic)data;
            fState = true;
        }

        public void Clear()
        {
            data = new T();
            fState = false;
        }

        public bool ReadState()
        {
            return fState;
        }

        public T ReadNumber()
        {
            return data;
        }
    }
}
