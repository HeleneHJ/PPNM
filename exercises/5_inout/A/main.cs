using System;
using System.Console;
using static System.Math;
class cmdline{
static int Main(string[] args){
	WriteLine("x sin(x) cos(x)");
	foreach(var s in args){
		double x=double.Parse(s);
		WriteLine("{0} {1} {2}",x,Sin(x),Cos(x));	
	}
return 0;
}
}