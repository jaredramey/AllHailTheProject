using System;

namespace DataModel
{
    class Program
    {
        private const uint c_uNumIterations = 1000;
        static void Main(string[] args)
        {
            ITimeControlledObject model = new Model();
            for (uint i = 0; i < c_uNumIterations; i++)
            {
                model.Trigger();
            }
            Console.ReadLine();
        }
    }
}
