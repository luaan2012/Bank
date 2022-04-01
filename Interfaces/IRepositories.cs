using System.Collections.Generic;
using bank.Models;

namespace bank.Interfaces
{
    public interface IRepositories<T>
    {
        void Insert(T register);
        string Remove(int number);
        Account Find(int number);

    }
}