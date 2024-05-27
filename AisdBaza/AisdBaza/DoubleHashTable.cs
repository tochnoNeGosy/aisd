using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AisdBaza
{
    public class DoubleHashTable
    {
        private int[] keys;
        private int[] values;
        private bool[] deleted;
        private int size;
        private int count;

        public DoubleHashTable(){
            size = 10;
            count = 0;
            keys = new int[size];
            values = new int[size];
            deleted = new bool[size];
            Array.Fill(keys, -1);
        }

        private int Hash(int key)
        {
            return (key * 17 + 7) % size;
        }

        private int HashStep(int key)
        {
            return key % 5 + 1;
        }

        public void Add(int key, int value)
        {
            if (count >= (size * 0.75))
            {
                resize();
            }
            if (count == size)
            {
                Console.WriteLine("Table is full");
                return;
            }
            int hash = Hash(key);
            int step = HashStep(key);
            for (int i = 0; i < size; ++i)
            {
                if(keys[hash] != -1 && !deleted[hash] && keys[hash] != key)
                {
                    hash += step;
                    hash %= size;
                }
                else
                {
                    break;
                }
            }
            
            if (keys[hash] != -1)
            {
                Console.WriteLine("Hash fail");
                return;
            }
            keys[hash] = key;
            values[hash] = value;
            deleted[hash] = false;
            count += 1;
        }

        public int GetValue(int key)
        {
            int hash = Hash(key);
            int step = HashStep(key);
            for (int i = 0; i < size; ++i)
            {
                if (keys[hash] != key && (keys[hash] != -1 || deleted[hash]))
                {
                    hash += step;
                    hash %= size;
                }
                else
                {
                    break;
                }
            }
            if (keys[hash] != key || deleted[hash])
            {
                Console.WriteLine("Key dont find");
                return -1;
            }
            return values[hash];
        }

        public void Delete(int key)
        {
            int hash = Hash(key);
            int step = HashStep(key);
            for (int i = 0; i < size; ++i)
            {
                if (keys[hash] != key && (keys[hash] != -1 || deleted[hash]))
                {
                    hash += step;
                    hash %= size;
                }
                else
                {
                    break;
                }
            }
            if (keys[hash] != key || deleted[hash])
            {
                Console.WriteLine("Key dont find");
                return;
            }
            keys[hash] = -1;
            deleted[hash] = true;
        }

        private void resize()
        {
            int oldSize = size;
            size *= 2;
            int[] oldValues = values;
            int[] oldKeys = keys;
            bool[] oldDeleted = deleted;
            values = new int[size];
            keys = new int[size];
            Array.Fill(keys, -1);
            deleted = new bool[size];
            for(int i = 0; i < oldSize; ++i)
            {
                if (oldKeys[i] != -1 && !deleted[i])
                {
                    Add(oldKeys[i], oldValues[i]);
                }
            }
        }
    }
}
