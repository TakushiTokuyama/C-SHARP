using System;

namespace SampleCode
{
    public class Country<T>
        where T : new()
    {
        public Country() 
        {
            new T();
        }
    }
}
