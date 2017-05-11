﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IHashTable
    {
        bool Contains(object key);
        void Add(object key, object value);
        bool TryGet(object key, out object value);
        object this[object key] { get; set; }
    }
}
