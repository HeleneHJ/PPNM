using System;
public partial class roots{

public static matrix jacobian
(Func<vector,vector> f,vector x,vector fx=null,double dx=1e-7){
	int n=x.size;
	matrix J=new matrix(n,n);
	if(!(fx!=null))fx=f(x);
	for(int j=0;j<n;j++){
		x[j]+=dx;
		vector df=f(x)-fx;
		for(int i=0;i<n;i++) J[i,j]=df[i]/dx;
		x[j]-=dx;
		}
	return J;
}
}//class