using MLog.Abstract;
using MLog.Concrete;
using System;

namespace MLogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MLog.Concrete.MLog mLog = new MLog.Concrete.MLog();

            mLog.Info("test");

            Console.WriteLine("Hello World!");
        }
    }
}
