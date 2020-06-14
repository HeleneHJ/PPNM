using System;
using static System.Math;
using static System.Console;
public partial class simplex{

public static double size(vector[] p){
	double s=0;
	for(int i=1;i<p.Length;i++){ 
		s=Max(s,(p[0]-p[i]).norm()); 
		}
	return s;
	}

public static double downhill(Func<vector,double> F,ref vector x,double step=1.0/4,double dx=1e-3){
vector[] p=new vector[x.size+1];
double[] f=new double[x.size+1];
p[x.size]=x.copy();
f[x.size]=F(p[x.size]);
for(int i=0;i<x.size;i++){
	x[i]+=step;
	p[i]=x.copy();
	f[i]=F(p[i]);
	x[i]-=step;
	}
int hi=0,lo=0,nsteps=0;	//hi: highest point, lo: lowest point

while(size(p)>dx && ++nsteps<999){
	hi=0;lo=0;
	double fhi=f[hi],flo=f[lo];	//f_hi: vertex with highest function value, f_lo: vertex with lowest function value
	for(int k=1;k<p.Length;k++){
		double fnext=f[k];
		if(fnext>fhi){fhi=fnext;hi=k;} 	//finding the highest point
		if(fnext<flo){flo=fnext;lo=k;}	//finding the lowest point
		}
	vector pce=new vector(p[0].size);
	for(int i=0;i<p.Length;i++) if(i!=hi)pce+=p[i];	//centroid
	pce/=pce.size;									//centroid

	vector pre=2*pce-p[hi]; //try reflection
	double fre=F(pre);		//try reflection
	if(fre<flo){ 			//if φ(reflected) < φ(lowest): try expansion
		vector pex=3*pce-2*p[hi];	//try expansion
		double fex=F(pex);			//try expansion
		if(fex<fre){ 		//if φ(expanded) < φ(reflected): accept expansion
			Error.Write("expansion\n"); 	//highest point reflects and doubles its distance from the centroid (p_hi -> p_ex = p_ce + 2(p_ce - p_hi))
			p[hi]=pex;
			f[hi]=fex;
			continue;
		}
		else{ 	//else accepted reflection
			Error.Write("reflection\n"); 	//highest point reflected against the centroid (p_hi -> p_re = p_ce + (p_ce - p_hi))
			p[hi]=pre;
			f[hi]=fre;
			continue;
		}
	}
	else if(fre<fhi){ 	//else if φ(reflected) < φ(highest): accept reflection
		Error.Write("reflection\n"); 	//highest point reflected against the centroid (p_hi -> p_re = p_ce + (p_ce - p_hi))
		p[hi]=pre;
		f[hi]=fre;
		continue;
	}
	else{ 	//else: try contraction
		vector pco=(pce+p[hi])/2;
		double fco=F(pco);
		if(fco<fhi){ 	//if φ(contracted) < φ(highest): accept contraction
			Error.Write("contraction\n"); 	//the highest point reflects and halves its distance from the centroid (p_hi -> p_co = p_ce + 1/2(p_hi - p_ce))
			p[hi]=pco;
			f[hi]=fco;
			continue;
		} 	//else do reduction
		Error.Write("reduction\n"); //all points move towards the lowest points halving the distance (p_k!=lo -> 1/2(p_k + p_lo))
		for(int i=0;i<p.Length;i++)
		if(i!=lo){
			p[i]=(p[i]+p[lo])/2;
			f[i]=F(p[i]);
		}
	}
}//while
x=p[lo];
return size(p);
}//simplex
}//class amoeba