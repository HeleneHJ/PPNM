using System;
public class lsfit{
public vector c;
public Func<double,double>[] f;
public lsfit(vector x, vector y, vector dy, Func<double,double>[] f){
	int n=x.size;
	int m=f.Length;
	matrix A=new matrix(n,m);
	vector b=new vector(n);
	for(int i=0;i<n;i++){
		b[i]=y[i]/dy[i];	
		for(int k=0;k<m;k++){
			A[i,k]=f[k](x[i])/dy[i];		
		}
	} 
	gramschmidt Q=new gramschmidt(A);
	c=Q.solve(b);
}

public double eval(double z){
	double s=0;
	for(int i=0;i<f.Length;i++)s+=c[i]*f[i](z);
	return s;
	}
}