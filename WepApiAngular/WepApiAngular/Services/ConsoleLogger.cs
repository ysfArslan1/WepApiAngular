﻿namespace WepApiAngular.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] " + message);
        }
    }
}
