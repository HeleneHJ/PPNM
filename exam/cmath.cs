// (C) 2020 Dmitri Fedorov; License: GNU GPL v3+; no warranty.
using System;
public static class cmath{

// xtenstions
public static bool approx(this double x, double y, double abserr=1e-9, double relerr=1e-9){
	return complex.approx(x,y,abserr,relerr);
}
public static bool approx(this double x, complex y, double abserr=1e-9, double relerr=1e-9){
	return complex.approx(x,y,abserr,relerr);
}

public static void print(this double x,string s){ System.Console.WriteLine(s+x); }
public static void print(this double x)         { x.print(""); }
public static void print(this complex z)
	{System.Console.WriteLine("{0} {1}",z.Re,z.Im);}
public static void print(this complex z, string s)
	{System.Console.WriteLine(s+z);}
public static void printf(this complex z,string s)
	{System.Console.WriteLine(s,z.Re,z.Im);}


public static double  exp(double x) {return Math.Exp(x);}
public static complex exp(complex z){
	return Math.Exp(z.Re)*(new complex(Math.Cos(z.Im),Math.Sin(z.Im)));
	}

public static double  sin(double x ){return Math.Sin (x);}
public static complex sin(complex z){
	var I=new complex(0,1);
	return (exp(I*z)-exp(-I*z))/2/I;
	}

public static double  cos(double x){return Math.Cos (x);}
public static complex cos(complex z){
	var I = complex.I;
	return (exp(I*z)+exp(-I*z))/2;
	}

public static double abs (double x ){return Math.Abs (x);}
public static double abs (complex z){
	double x=abs(z.Re),y=abs(z.Im),t;
	if(x>y){ t=y/x; return x*sqrt(1+t*t); }
	else   { t=x/y; return y*sqrt(t*t+1); }
	}

//public static double  log(double x){return Math.Log (x);}
public static complex log(complex z){
	return new complex( Math.Log(abs(z)), arg(z) ); }

public static double sqrt(double x){return Math.Sqrt(x);}
public static complex sqrt(complex z){
	return Math.Sqrt(abs(z))*exp(complex.I*arg(z)/2);
	}
public static double arg(complex z){return Math.Atan2(z.Im,z.Re);}

public static double  pow (this double x, double y){return Math.Pow (x,y);}
public static double  pow (this double x, int n   ){return Math.Pow (x,n);}
public static complex pow (this complex a, double x){
	return exp(x*log(a)); }
public static complex pow (this complex a, complex b){
	return exp(b*log(a)); }

/*_________________________________________________________*/


public static bool approx(complex a, complex b, double abserr=1e-9, double relerr=1e-9){
	double d=abs(a-b),s=abs(a)+abs(b);
	if (equal(a,b)==true) return true;
	if( d<=abserr ) return true;
	else if ( d/s <= relerr/2 ) return true;
	else return false;
	}

public static bool largest(complex a, complex b){
	double c=abs(a),d=abs(b);
	if( c>d ) return true;	// if b is smaller than a
	else return false;
	}

public static bool largest(double a, complex b){
	if( a>abs(b) ) return true;	// if b is smaller than a
	else return false;
	}

public static bool largerequal(complex a, complex b){
	double c=abs(a),d=abs(b);
	if( c>=d ) return true;	// if b is larger than a
	else return false;
	}

public static bool equal(complex a, complex b){
	double c=abs(a),d=abs(b);
	if( d==c ) return true;	// if b is equal to a
	else return false;
	}

public static complex min(complex a, complex b){
	double c=abs(a);
	double d=abs(b);
	if(c<=d){ return a; }
	else { return b; }
}

public static complex max(complex a, complex b){
	double c=abs(a);
	double d=abs(b);
	if(c>=d){ return a; }
	else { return b; }
}

}// cmath
