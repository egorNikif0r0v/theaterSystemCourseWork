using MatthiWare.CommandLine.Core.Attributes;

namespace theaterSystem.Options
{
    internal class ProgramOprions
    {
        [Name("r", "request"), Description("enter the path of the request file"), Required]
        public string RequestPath { get; set; }

        [Name("i", "info_file_name"), Description("enter the name or path of the results file")]
        public string InfoFileName { get; set; }
    }
}
