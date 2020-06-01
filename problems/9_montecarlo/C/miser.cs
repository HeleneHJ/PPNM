using System;
using static System.Console;
using static System.Math;
using static System.Double;

public partial class montecarlo{

public static double trial_fraction=0.1;

public static void randomx (vector x, double[] a, double[] b, Random RND){
	for(int i=0;i<x.size;i++) x[i]=a[i]+RND.NextDouble()*(b[i]-a[i]);
	}

public static double[] miser
(Func<vector,double> f, double[] a, double[] b, int npoints, Random RND=null)
{
if(RND==null)RND=new Random(1);
int dim=a.Length;
int min_points=8*dim;
int min_new_points=4*min_points;

double volume=1; for(int i=0;i<dim;i++) volume*=(b[i]-a[i]);
var x =new vector(dim);

if(npoints<=2*min_points){//plain MC
/*
	return plain(f,a,b,npoints,RND);
*/
	int n1=npoints/2;
	int n2=npoints-n1;
	double[] r1=plain(f,a,b,n1,RND);
	double[] r2=plain(f,a,b,n2,RND);
	double mcinteg=(n1*r1[0]+n2*r2[0])/(n1+n2);
	double mcerror=Abs(r1[0]-r2[0])/4;
	return new double[] {mcinteg,mcerror};
	}

int trial_points=(int)Max(min_points,trial_fraction*npoints);
int new_points=npoints-trial_points;

var aL=new vector(dim);
var aR=new vector(dim);
var vL=new vector(dim);
var vR=new vector(dim);
var nL=new int[dim];
var nR=new int[dim];
var sum_f_L=new vector(dim);
var sum_f2_L=new vector(dim);
var sum_f_R=new vector(dim);
var sum_f2_R=new vector(dim);

for(int n=0;n<trial_points;n++){// trial run
	randomx(x,a,b,RND);
	double fx=f(x);
	for(int i=0;i<dim;i++){ // sub-sums
		if(x[i]<(a[i]+b[i])/2){nL[i]++;sum_f_L[i]+=fx;sum_f2_L[i]+=fx*fx;}
		else                  {nR[i]++;sum_f_R[i]+=fx;sum_f2_R[i]+=fx*fx;}
		}
	}

double vmax=0;int i_bisect=RND.Next(0,dim);
for(int i=0;i<dim;i++){
	if(nL[i]>0){
		aL[i]=sum_f_L[i]/nL[i];
		vL[i]=sum_f2_L[i]/nL[i]-Pow(aL[i],2);
		}
	if(nR[i]>0){
		aR[i]=sum_f_R[i]/nR[i];
		vR[i]=sum_f2_R[i]/nR[i]-Pow(aR[i],2);
		}
	double measure=Abs(aL[i]-aR[i]);
	//double measure=vL[i]+vR[i];
	//double measure=Max(vL[i],vR[i]);
	if(measure>vmax){vmax=measure;i_bisect=i;}
	}

double weight_L=vL[i_bisect];
double weight_R=vR[i_bisect];
if(weight_L==0 && weight_R==0)weight_L=weight_R=1;

int new_points_L=min_points
+(int)Round((new_points-2*min_points)*weight_L/(weight_L+weight_R));

int new_points_R=min_points
+(int)Round((new_points-2*min_points)*weight_R/(weight_L+weight_R));

if(new_points<=min_new_points){
	new_points_L=new_points/2;
	new_points_R=new_points-new_points_L;
	}

var aa = (double[])a.Clone();aa[i_bisect]=(a[i_bisect]+b[i_bisect])/2;
var bb = (double[])b.Clone();bb[i_bisect]=(a[i_bisect]+b[i_bisect])/2;

double[] result_L = miser(f,a,bb,new_points_L,RND);
double[] result_R = miser(f,aa,b,new_points_R,RND);

double new_integ=result_L[0]+result_R[0];
double new_error=Sqrt(Pow(result_L[1],2)+Pow(result_R[1],2));

double trial_average=(sum_f_L[i_bisect]+sum_f_R[i_bisect])/trial_points;
double trial_integ=trial_average*volume;

/*
double trial_variance=(sum_f2_L[i_bisect]+sum_f2_R[i_bisect])/trial_points
	-trial_average*trial_average;
double trial_error=trial_variance*volume/Sqrt(trial_points);
*/
double trial_error=Abs(trial_integ-new_integ)/4;

double integ=(trial_integ*trial_points+new_integ*new_points)/
	(trial_points+new_points);
double error2=(Pow(new_error*new_points,2)+Pow(trial_error*trial_points,2))/
	Pow(new_points+trial_points,2);
double error=Sqrt(error2);

//return new double[] {integ,Abs(trial_integ-new_integ)};
return new double[] {integ,error};
//return new double[] {integ,new_error};
//return new double[] {new_integ,new_error};

}//miser
}//class