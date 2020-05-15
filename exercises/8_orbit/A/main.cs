using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;
class main{
	public static void Main(){
		Func<double,vector,vector> LogODE = (x,y) => new vector(y[0]*(1-y[0]));
		double xstart = 0.0;
		double xend = 3.0;
		vector ycondition = new vector(0.5);
		
		List<double> xvalues = new List<double>();
		List<vector> yvalues = new List<vector>();
		
		vector yintegrated=ode.rk23(LogODE,xstart,ycondition,xend,xvalues,yvalues);
		
		for(int i=0; i<xvalues.Count; i++){
			WriteLine($"{xvalues[i]} {yvalues[i][0]}");	
	}
}
}