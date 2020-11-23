using System.Collections.Generic;

namespace Hashing
{
    public interface IHashTable
    {
        public bool Add(int key, int value);

        public int? Get(int key);
    }
}