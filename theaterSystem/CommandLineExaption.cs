using System;

namespace theaterSystem
{
    class CommandLineExaption : Exception
    {
        public CommandLineExaption()
        {
        }

        public CommandLineExaption(string message)
        : base(message)
        {
        }

        public CommandLineExaption(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
