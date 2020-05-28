using System;
using System.IO;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

class main{
static void Main() {
	double m = 1.0;	// all three masses should me equal, here they are all set to 1.0
	double G = 1.0; // the gravitational constant is approximated as 1
			
	vector r1_0 = new vector(new double[] {0.97000436,-0.24308753}); // initial conditions (given in figure 1 of the article)
	vector r2_0 = -r1_0.copy();
	vector r3_0 = new vector(new double[] {0,0});
	vector dr3_0 = new vector(new double[] {-0.93240737,-0.86473146});
	vector dr2_0 = -dr3_0.copy()/2;
	vector dr1_0 = dr2_0.copy();
	
	vector y0 = new vector(new double[]{r1_0[0], r1_0[1], r2_0[0], r2_0[1], r3_0[0], r3_0[1], dr1_0[0], dr1_0[1], dr2_0[0], dr2_0[1], dr3_0[0], dr3_0[1]});	// initial values of y
	
	double t0 = 0; 		// "start value"
	double tb = 10;	// "end value"
	double acc = 1e-5;	// precision
	double eps = 1e-5;	// precision
	double h = 1e-3;	// step size
	var ts = new List<double>();
	var ys = new List<vector>();

	ode.rk23(threebody(m,G),t0,y0,tb,h,acc,eps,ts,ys);

	StreamWriter output = new System.IO.StreamWriter("out.txt");
	for(int i=0;i<ys.Count;i++){
		output.WriteLine($"{ts[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]} {ys[i][3]} {ys[i][4]} {ys[i][5]}");		
		}
	output.Close();
	}

public static Func<double, vector, vector> threebody(double m, double G){
	return (x, y) => {
		vector r1 = new vector(new double[] {y[0], y[1]});	//r1(x,y)
		vector r2 = new vector(new double[] {y[2], y[3]}); 	//r2(x,y)
		vector r3 = new vector(new double[] {y[4], y[5]});	//r3(x,y)

		vector ddr1 = -G*m*(r1-r2)/(Pow((r1-r2).norm(),3)) - G*m*(r1-r3)/(Pow((r1-r3).norm(),3)); // second derivative of r1 with respect to time
		vector ddr2 = -G*m*(r2-r3)/(Pow((r2-r3).norm(),3)) - G*m*(r2-r1)/(Pow((r2-r1).norm(),3)); // second derivative of r2 with respect to time
		vector ddr3 = -G*m*(r3-r1)/(Pow((r3-r1).norm(),3)) - G*m*(r3-r2)/(Pow((r3-r2).norm(),3)); // second derivative of r3 with respect to time
				
		vector dy = new vector(new double[] {y[6], y[7], y[8], y[9], y[10], y[11], ddr1[0], ddr1[1], ddr2[0], ddr2[1], ddr3[0], ddr3[1]});
		return dy;
			};
		}	
}