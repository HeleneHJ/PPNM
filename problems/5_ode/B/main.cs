using System;
using System.IO;
using System.Collections.Generic;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	double N = 5.8e6;	//population 
	double Tr = 10; 	//typical recovery time (days)
	double Istart = 500; 		// initial number of infected people
	vector ya = new vector(new double[] {N-Istart, Istart, 0});		// startvalues
	double a=0.0;				// boundary condition
	double b=250;				// "end" value
	double h=0.01;				// step size
	double acc=1e-3;			// precision (used in "approx")
	double eps=1e-3;			// precision (used in "approx")


	double Tc1 = 0.8; 	//typical time between contacts (days)  (True value ~4.7 days)
		var xs1=new List<double>();	// x-values (to be filled)
		var ys1=new List<vector>();	// y-values (to be filled)
		vector y1=ode.rk23(SIR(N,Tc1,Tr),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs1,ylist:ys1); // solving the ODE
	StreamWriter outB1 = new StreamWriter("outB1.txt", append:false);
	for(int i=0;i<ys1.Count;i++){
		outB1.WriteLine($"{xs1[i]} {ys1[i][0]} {ys1[i][1]} {ys1[i][2]}");		
		}
	outB1.Close();


	double Tc2 = 2; 	//typical time between contacts (days)
			var xs2=new List<double>();	// x-values (to be filled)
			var ys2=new List<vector>();	// y-values (to be filled)
			vector y2=ode.rk23(SIR(N,Tc2,Tr),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs2,ylist:ys2); // solving the ODE
	StreamWriter outB2 = new StreamWriter("outB2.txt", append:false);
	for(int i=0;i<ys2.Count;i++){
		outB2.WriteLine($"{xs2[i]} {ys2[i][0]} {ys2[i][1]} {ys2[i][2]}");		
		}
	outB2.Close();


	double Tc3 = 5; 	//typical time between contacts (days)
			var xs3=new List<double>();	// x-values (to be filled)
			var ys3=new List<vector>();	// y-values (to be filled)
			vector y3=ode.rk23(SIR(N,Tc3,Tr),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs3,ylist:ys3); // solving the ODE
	StreamWriter outB3 = new StreamWriter("outB3.txt", append:false);
	for(int i=0;i<ys3.Count;i++){
		outB3.WriteLine($"{xs3[i]} {ys3[i][0]} {ys3[i][1]} {ys3[i][2]}");		
		}
	outB3.Close();


	double Tc4 = 8; 	//typical time between contacts (days)
			var xs4=new List<double>();	// x-values (to be filled)
			var ys4=new List<vector>();	// y-values (to be filled)
			vector y4=ode.rk23(SIR(N,Tc4,Tr),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs4,ylist:ys4); // solving the ODE
	StreamWriter outB4 = new StreamWriter("outB4.txt", append:false);
	for(int i=0;i<ys4.Count;i++){
		outB4.WriteLine($"{xs4[i]} {ys4[i][0]} {ys4[i][1]} {ys4[i][2]}");		
		}
	outB4.Close();


	double Tc5 = Tr+3; 	//typical time between contacts (days)
			var xs5=new List<double>();	// x-values (to be filled)
			var ys5=new List<vector>();	// y-values (to be filled)
			vector y5=ode.rk23(SIR(N,Tc5,Tr),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs5,ylist:ys5); // solving the ODE
	StreamWriter outB5 = new StreamWriter("outB5.txt", append:false);
	for(int i=0;i<ys5.Count;i++){
		outB5.WriteLine($"{xs5[i]} {ys5[i][0]} {ys5[i][1]} {ys5[i][2]}");		
		}
	outB5.Close();

	Error.WriteLine("It is clear that the larger T_c is, the flatter the curve of 'I' becomes, i.e., the longer between contacts that spread the disease, the fewer people will be infected at one time.");
	Error.WriteLine("However, this also means that the disease will remain in the population longer.");
	Error.WriteLine("This model is a simplification that does not take into account the measures implemented to stop the disease from spreading, such as social distancing, and a general 'shut down' of society.");
	Error.WriteLine("If T_c is larger than T_r, i.e., that the recovery time is smaller than the time between contacts, as is the idea behind social distancing, then there can be no epidemic.");
}
	

static Func<double, vector, vector> SIR(double N, double Tc, double Tr){
	return (x, y) => {
	vector ydiff = new vector(3);
	ydiff[0] = -(y[1]*y[0])/(N*Tc);
	ydiff[1] = (y[1]*y[0])/(N*Tc)-y[1]/Tr;
	ydiff[2] = y[1]/Tr;
	return ydiff;
	};
	}	
}
	// y[0]=S, y[1]=I, y[2]=R
	
	// dS/dt = -I*S/(N*Tc) 			=>		y'[0] = ydiff[0] = -y[1]*y[0]/(N*Tc)
	// dI/dt = I*S/(N*Tc)-I/Tr 		=> 		y'[1] = ydiff[1] = y[1]*y[0]/(N*Tc)-y[1]/Tr
	// dR = I/Tr 					=> 		y'[2] = ydiff[2] = y[1]/Tr
