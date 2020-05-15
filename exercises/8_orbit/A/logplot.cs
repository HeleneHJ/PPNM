using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;
class main{
	public static void Main(){
		// Logistic function values saved in output txt-file "out.logplot.txt"
		double dx=1.0/32;
		for(double x=0; x<=3; x+=dx)
			WriteLine($"{x} {logfunc.logistic(x)}");
		}
}
