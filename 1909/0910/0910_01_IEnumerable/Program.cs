﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;

namespace _0910_01_IEnumerable
{
    class MyList : IEnumerable, IEnumerator
    {
        private int[] array;
        int position = -1;

        public MyList()
        {
            array = new int[3];
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }

            set
            {
                if (index >= array.Length) // 컬렉션..?
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine("Array Resized : {0}", array.Length);
                }

                array[index] = value;
            }
        }

        // IEnumerator 멤버
        public object Current
        {
            get
            {
                return array[position];
            }
        }

        // IEnumerator 멤버
        public bool MoveNext()
        {
            if (position == array.Length - 1)
            {
                Reset();
                return false;
            }

            position++;
            return (position < array.Length);
        }

        // IEnumerator 멤버
        public void Reset()
        {
            position = -1;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return (array[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
                list[i] = i;

            foreach (int e in list)
                Console.WriteLine(e);
        }
    }
}
