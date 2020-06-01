using System;
using static System.Console;
public partial class roots{
public static vector newton(Func<vector,vector> f, vector x, double eps=1e-3, double dx=1e-7){
	int n=x.size;
	vector fx=f(x);
	vector z,fz;
	while(true){
		matrix J=jacobian(f,x,fx); // define the Jacobian matrix with partial derivatives
		qrdecomposition qrJ=new qrdecomposition(J); // use QR-decomposition 
		matrix B=qrJ.inverse(); // construct the inverse of our QR-decomposition
		vector Dx=-B*fx;	// solve the Newton's algorithm in matrix form (using eq. 5)
		
		double s=1;
		while(true){	// backtracking linesearch
			z=x+Dx*s;   // creating left-hand side of eq. 8
			fz=f(z);	// creating left-hand side of eq. 8
			if(fz.norm()<(1-s/2)*fx.norm()){	// stop if step is good
				break;
				}
			if(s<1.0/32){						// stop if minimum step-size is reached
				break;
				}
			s/=2;								// backtrack using half the step-size
		}
		x=z;
		fx=fz;
		if(fx.norm()<eps)break;					// until converged
	}
	return x;
}//newton
}//class