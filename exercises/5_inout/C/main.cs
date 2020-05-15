using System;
using System.IO;
using static System.Math;
class fileinout{
static int Main(string[] args){
	// if(args.Length < 2)return 1;
	string infile=args[0];
	string outfile=args[1];
	StreamReader instream=new StreamReader(infile);
	StreamWriter outstream=new StreamWriter(outfile,append:false);
	outstream.WriteLine("x cos(x)");
	do{
		string line=instream.ReadLine();
		if(line==null)break;
		string[] words=line.Split(' ',',','\t');
		foreach(var word in words){
			double x=double.Parse(word);
			outstream.WriteLine($"{x} {Cos(x)}");	
			}
		}while(true);
	outstream.Close();
	instream.Close();
return 0;
}
}