using System;

namespace Interfaces
{
	interface IConvertible
	{
		string ConvertToCSharp(string ConvertToCSharp);
		string ConvertToVB(string ConvertToVB);
	}

	interface ICodeChecker
    {
		bool CheckCodeSyntax(string StringToCheck, string WhichLang);
    }

	class ProgramConverter : IConvertible
    {
        public ProgramConverter()
        {
            Console.WriteLine("Creating ProgramConverter!");
        }
        public string ConvertToCSharp(string ConvertToCSharp)
		{
			Console.WriteLine("Converting the string you passed in to CSharp syntax");
			return "This is a C# String.";
		}
		public string ConvertToVB(string ConvertToVB)
		{
			Console.WriteLine("Converting the string you passed in to VB syntax");
			return "This is a VB String.";
		}
	}

	class ProgramHelper : ProgramConverter, ICodeChecker
    {
		public ProgramHelper()
        {
			Console.WriteLine("Creating ProgramHelper!");
        }

		public bool CheckCodeSyntax(string StringToCheck, string WhichLang)
        {
			switch(WhichLang)
            {
				case "CSharp":
					Console.WriteLine("Checkin the string for C# Syntax: {0}", StringToCheck);
					return true;
				case "VB":
					Console.WriteLine("Checking the string for VB Syntax: {0}", StringToCheck);
					return true;
				default:
					return false;
            }
        }
    }
	
	class Program
    {
        static void Main(string[] args)
        {
			ProgramConverter[] converters = new ProgramConverter[4];
			converters[0] = new ProgramConverter();
			converters[1] = new ProgramHelper();
			converters[2] = new ProgramHelper();
			converters[3] = new ProgramConverter();

			foreach(ProgramConverter pc in converters)
            {
				string CSharpString = pc.ConvertToCSharp("This is a CSharp String to convert.");
				Console.WriteLine(CSharpString);

				ProgramHelper ph = pc as ProgramHelper;
				if (ph != null)
				{
					Console.WriteLine("Checking the string for syntax... Result {0}", ph.CheckCodeSyntax(CSharpString, "CSharp"));
				}
				else
					Console.WriteLine("No CSharp syntax check - not a Program Helper!");

				string VBString = pc.ConvertToVB(CSharpString);
				Console.WriteLine(VBString);

				if (ph != null)
				{
					Console.WriteLine("Checking the string for syntax... Result {0}", ph.CheckCodeSyntax(VBString, "VB"));
				}
				else
					Console.WriteLine("No VB syntax check - not a Program Helper!");
			}
			Console.ReadKey();
	    }
    }
}
