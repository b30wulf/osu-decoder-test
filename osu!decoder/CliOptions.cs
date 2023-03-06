﻿using System;
using CommandLine;
using CommandLine.Text;

namespace osu_decoder_dnlib
{
	internal class CliOptions
	{
		[ValueOption(0)]
		public string Input { get; set; }
        
		[Option('o', "output", HelpText = "Path of the output file")]
		public string Output { get; set; }
        
		[Option('v', "verbose", HelpText = "Prints more output.")]
		public bool Verbose { get; set; }
        
		[Option('d', "debug", HelpText = "Prints a lot more output, you should pipe this to a file.")]
		public bool Debug { get; set; }
        
		[Option('s', "sourcemap", HelpText = "Writes a file containing an original:decoded source map.")]
		public bool Sourcemap { get; set; }
        
		[Option('r', "dry-run", HelpText = "Do not write decoded executable to disk.")]
		public bool DryRun { get; set; }

        [Option('n', "no-types", HelpText = "Don't decrypt types, but strings")]
        public bool NoTypes { get; set; }

        [Option('p', "password", HelpText = "Specify a custom password")]
        public string Password { get; set; } = "recorderinthesandybridge";
        
		[Option("exp-patch", HelpText = "Apply patch to remove signature and filename check", DefaultValue = true)]
		public bool ExperimentPatch { get; set; }

		[HelpOption]
		public string GetHelp()
		{
			HelpText helpText = new HelpText();
			helpText.Heading = new HeadingInfo("osu!decoder", "v1.4");
			helpText.Copyright = new CopyrightInfo("HoLLy/JustM3", 2017);
			helpText.AdditionalNewLineAfterOption = false;
			helpText.AddDashesToOption = true;
			helpText.MaximumDisplayWidth = Console.BufferWidth;
			helpText.AddPreOptionsLine("\nExample usage:");
			helpText.AddPreOptionsLine("\t- osu!decoder osu!.exe");
			helpText.AddPreOptionsLine("\t- osu!decoder osu!.exe -v -p updated_password -o c:/newosu!.exe");
			helpText.AddOptions(this);
			helpText.AddPostOptionsLine("Please do not distribute. If you have this, it means I trust you :)");
			return helpText;
		}
	}
}
