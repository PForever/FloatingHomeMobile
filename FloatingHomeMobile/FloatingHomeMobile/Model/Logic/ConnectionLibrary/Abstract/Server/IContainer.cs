using System;
using System.Collections.Generic;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Server
{
    public interface IContainer<T>
    {
        bool Contains(T element);
        bool Contains(string elementKey);
        T Search(string elementKey);
        IEnumerable<T> Search(Predicate<T> predicate);
    }
}