﻿using MLog.Abstract;
using MLog.Concrete;
using System;

namespace MLogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IMLogger mLogger = new MLogger();


            mLogger.Info("test");
            mLogger.Info("test");
            mLogger.Info("test");
            mLogger.Info("test");
            mLogger.Info("test");

            Console.WriteLine("Hello World!");
        }
    }
}
