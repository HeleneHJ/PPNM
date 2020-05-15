using System;
using static System.Console;
public partial class roots{

public static int newton
(Func<vector,vector> f, ref vector x, double eps=1e-3, double dx=1e-7){
	vector fx=f(x),z,fz;
	int nsteps=0;
	while(++nsteps<999){
		matrix J=jacobian(f,x,fx);
		qrdecomposition qrJ=new qrdecomposition(J);
		vector Dx=qrJ.solve(-fx);
		double s=1;
		do{// backtracking linesearch
			z=x+Dx*s;
			fz=f(z);
			if(fz.norm()<(1-s/2)*fx.norm()){ break; }
			if(s<1.0/32){ break; }
		}while( (s/=2)>1.0/64 );
		x=z;
		fx=fz;
		if(fx.norm()<eps){break;}
	}
	return nsteps;
}//broyden

public static int broyden
(Func<vector,vector> f, ref vector x, double eps=1e-3){
	vector fx=f(x),z,fz;
	matrix J=jacobian(f,x,fx);
	var qrJ=new qrdecomposition(J);
	matrix B=qrJ.inverse();
	int nsteps=0;
	while(++nsteps<999){
		vector Dx=-B*fx;
		double s=1;
		while(true){
			z=x+Dx*s;
			fz=f(z);
			if(fz.norm()<(1-s/2)*fx.norm()){ break; }
			if(s<1.0/32){
				J=jacobian(f,x,fx);
				qrJ=new qrdecomposition(J);
				B=qrJ.inverse();
				break;
				}
			s/=2;
		}
		vector dx=z-x;
		vector df=fz-fx;

		if(dx.dot(df)>1e-9){
			vector c=(dx-B*df)/dx.dot(df);
			B.update(c,dx);
		}

		//vector c=(dx-B*df)/(df%df); B.update(c,df);
		//vector c=(dx-B*df)/(dx%(B*df)); B.update(c,B*df);
		
		x=z;
		fx=fz;
		if(fx.norm()<eps)break;
	}
	return nsteps;
}//broyden

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