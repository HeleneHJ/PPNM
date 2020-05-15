using System;
using System.IO;
using static System.Math;
class stdinout{
static int Main(){
	TextReader stdin  = Console.In;
	TextWriter stdout = Console.Out;
	stdout.WriteLine("# x sin(x) cos(x)");
	do{
		string s=stdin.ReadLine();
		if(s==null)break;
		string[] words=s.Split(' ',',','\t');
		foreach(var word in words){
			double x=double.Parse(word);
			stdout.WriteLine("{0} {1} {2}",x,Sin(x),Cos(x));	
		}
	}while(true);
return 0;
}
}