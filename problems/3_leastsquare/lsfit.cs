using System;
public class lsfit{
public vector c;
public matrix sigma;
public Func<double,double>[] f;
public lsfit(vector x, vector y, vector dy, Func<double,double>[] fs){
	f=fs;
	int n=x.size,m=fs.Length;
		// Console.WriteLine($"n: {n} m: {m}\n");
	var A = new matrix(n,m);
	var b = new vector(n);
	for(int i=0;i<n;i++){
		b[i]=y[i]/dy[i];										// Equation (7) in chapter
		for(int k=0;k<m;k++)A[i,k] = f[k](x[i])/dy[i];			// Equation (7) in chapter
		}

	var q=new gramschmidt(A);			// We use the Gram-Schmidt routine to decompose A
	c=q.solve(b);						// We solve the system

	var ai=q.inverse();	
	sigma=ai*ai.T;						// equation (14) in chapter to determine the covariance matrix
	}

public double eval(double z){			// We construct the linear combination of the functions c[k]*f[k](x)
	double s=0;
	for(int i=0;i<f.Length;i++)s+=c[i]*f[i](z);				// Equation (5) in chapter
	return s;
	}
}