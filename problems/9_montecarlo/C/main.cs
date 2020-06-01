using System;
using System.IO;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	//StreamWriter strata_points = new StreamWriter("out.strata",append:false);
	//int ncalls;
	double R=0.876543;
	Func<vector,double> f=(v)=>{
		v.print();
		if(v%v<R*R)return 1;else return 0;
		};
	double exact=PI*R*R/4;
	double[] a={0,0};
	double[] b={1,1};
	int N=(int)10000;
	double[] r;
	r = montecarlo.miser(f,a,b,npoints:N,RND:new Random(5));
	Error.Write($"===== miser: x%x<R*R =====\n");
	Error.Write($"npoints={N}\n");
	Error.Write($"integ={r[0]:f5} ");
	Error.Write($"sigma={r[1]:f5}\n");
	Error.Write($"exact={exact:f5} ");
Error.Write($"error={Abs(exact-r[0]):f5} = {Abs(exact-r[0])/r[1]:f3} sigma\n");

/*
	{
	ncalls=0;double acc=0.001,eps=0;
	f=v=>{ncalls++;v.fprint(strata_points);if(v%v<R*R)return 1;else return 0;};
	r = montecarlo.strata(f,a,b,acc:acc,eps:eps,RND:new Random(5));
	Error.Write($"\n===== strata: x%x<R*R =====\n");
	Error.Write($"npoints={ncalls} acc={acc} eps={eps}\n");
	Error.Write($"integ={r[0]:f5} ");
	Error.Write($"sigma={r[1]:f5}\n");
	Error.Write($"exact={exact:f5} ");
Error.Write($"error={Abs(exact-r[0]):f5} = {Abs(exact-r[0])/r[1]:f3} sigma\n");
	}
*/

	{
	f=v=>{if(v%v<R*R)return 1;else return 0;};
	r = montecarlo.plain(f,a,b,npoints:N,RND:new Random(5));
	Error.Write($"\n===== plain: x%x<R*R =====\n");
	Error.Write($"npoints={N}\n");
	Error.Write($"integ={r[0]:f5} ");
	Error.Write($"sigma={r[1]:f5}\n");
	Error.Write($"exact={exact:f5} ");
Error.Write($"error={Abs(exact-r[0]):f5} = {Abs(exact-r[0])/r[1]:f3} sigma\n");
	}

	Func<vector,double> F=(k)=>{
		double A = 1.0 / (PI * PI * PI);
		return A / (1.0 - Cos (k[0]) * Cos (k[1]) * Cos (k[2]));
		};
	exact = 1.3932039296856768591842462603255;
	a=new double[] {0,0,0};
	b=new double[] {PI,PI,PI};
	N=500000;

	r = montecarlo.miser(F,a,b,npoints:N);
	Error.Write($"\n===== miser: difficult integral =====\n");
	Error.Write($"npoints={N}\n");
	Error.Write($"integ={r[0]:f5} ");
	Error.Write($"sigma={r[1]:f5}\n");
	Error.Write($"exact={exact:f5} ");
Error.Write($"error={Abs(exact-r[0]):f5} = {Abs(exact-r[0])/r[1]:f3} sigma\n");

	{
	Random rnd=new Random(2);
	r = montecarlo.plain(F,a,b,npoints:N,RND:rnd);
	Error.Write($"\n===== plain: difficult integral =====\n");
	Error.Write($"npoints={N}\n");
	Error.Write($"integ={r[0]:f5} ");
	Error.Write($"sigma={r[1]:f5}\n");
	Error.Write($"exact={exact:f5} ");
Error.Write($"error={Abs(exact-r[0]):f5} = {Abs(exact-r[0])/r[1]:f3} sigma\n");
	}

}//Main
}//main