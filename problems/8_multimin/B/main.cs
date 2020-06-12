using System;
using static System.Math;
using static System.Console;
static class main{

static double pow(this double x,int n){return Pow(x,n);}
static double pow(this double x,double n){return Pow(x,n);}

static System.Collections.Generic.List<double> energy,signal,error;

static double chi2(vector x){	// deviation function
	double m = x[0];
	double G = x[1];
	double A = x[2];
	double sum=0;
	for(int i=0;i<energy.Count;i++){
		double e=energy[i];
		double y=signal[i];
		double u=error[i];
		sum+=(A*breitwigner(e,m,G)-y).pow(2)/u/u; 	// D(m,Γ,A)=Σ_i(F(E_i|m,Γ,A)-σ_i)^2
		}
	return sum;
	}

static double breitwigner(double e, double m, double G){
	return 1/((e-m).pow(2)+G.pow(2)/4); 	// F(E,m,Γ)=1/((E-m)^2+Γ^2/4) (with A=1)
}

static void Main(){
energy = new System.Collections.Generic.List<double>();
signal = new System.Collections.Generic.List<double>();
error  = new System.Collections.Generic.List<double>();
System.IO.TextReader stdin = Console.In;
do{
	string s=stdin.ReadLine();
	if(s==null)break;
	char[] separators = new char[] {' '};
	string[] w=s.Split(separators,StringSplitOptions.RemoveEmptyEntries);
	energy.Add(double.Parse(w[0]));
	signal.Add(double.Parse(w[1]));
	error.Add (double.Parse(w[2]));
	}while(true);

vector p=new vector("120 2 6");		// starting point
int nsteps=qnewton.sr1(chi2,ref p,acc:1e-3);
double m=p[0];
double G=p[1];
double A=p[2];
Write($"nsteps       ={nsteps}\n");
Write($"mass         ={m}\n");
Write($"Gamma        ={G}\n");
Write($"Sqrt(chi^2/n)={Sqrt(chi2(p)/energy.Count)}\n");

for(double e=energy[0];e<=energy[energy.Count-1];e+=1.0/8)
	Error.WriteLine($"{e} {A*breitwigner(e,m,G)}");

}//Main
}//main