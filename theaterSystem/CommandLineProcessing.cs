using MatthiWare.CommandLine;
using theaterSystem.Options;

namespace theaterSystem
{
    internal class CommandLineProcessing
    {
       static public ProgramOprions GetCommandLineData(string[] args)
       {
            var result = new CommandLineParser<ProgramOprions>().Parse(args);

            return result.HasErrors ? throw new CommandLineExaption("command line error") : result.Result;
       }
    }
}
