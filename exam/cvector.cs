// (C) 2020 Dmitri Fedorov; License: GNU GPL v3+; no warranty.
using System;
using System.IO;
using static System.Math;
using static System.Console;
using static cmath;
public partial class cvector{

public static complex I = new complex(0,1);
private complex[] data;
public int size{ get{return data.Length;} }

public complex this[int i]{
	get{return data[i];}
	set{data[i]=value;}
}

public cvector(int n){data=new complex[n];}
public cvector(complex[] a){data=a;}
public cvector(complex a)
	{ data = new complex[]{a}; }
public cvector(complex a, complex b)
	{ data = new complex[]{a,b}; }
public cvector(complex a, complex b, complex c)
	{ data = new complex[]{a,b,c}; }
public cvector(complex a, complex b, complex c, complex d)
	{ data = new complex[]{a,b,c,d}; }
// public cvector(string s){
//         string[] words = s.Split(',',' ');
//         int n = words.Length;
//         data = new complex[n];
//         for(int i=0;i<size;i++){
//                         this[i]=complex.Parse(words[i]);
//                         }
// 	}


public static implicit operator cvector (complex[] a){ return new cvector(a); }
public static implicit operator complex[] (cvector v){ return v.data; }

public void print(string s="",string format="{0,10:g3} "){
	this.fprint(Console.Out,s,format);
	}

public void fprint(TextWriter file,string s="",string format="{0,10:g3} "){
	file.Write(s);
	for(int i=0;i<size;i++) file.Write(format,this[i]);
	file.Write("\n");
}

public static cvector operator+(cvector v, cvector u){
	cvector r=new cvector(v.size);
	for(int i=0;i<r.size;i++)r[i]=v[i]+u[i];
	return r; }

public static cvector operator-(cvector v){
	cvector r=new cvector(v.size);
	for(int i=0;i<r.size;i++)r[i]=-v[i];
	return r; }

public static cvector operator-(cvector v, cvector u){
	cvector r=new cvector(v.size);
	for(int i=0;i<r.size;i++)r[i]=v[i]-u[i];
	return r; }

public static cvector operator*(cvector v, complex a){
	cvector r=new cvector(v.size);
	for(int i=0;i<v.size;i++)r[i]=a*v[i];
	return r; }

public static cvector operator*(complex a, cvector v){
	return v*a; }

public static cvector operator/(cvector v, complex a){
	cvector r=new cvector(v.size);
	for(int i=0;i<v.size;i++)r[i]=v[i]/a;
	return r; }

public complex dot(cvector o){
	complex sum=0;
	for(int i=0;i<size;i++)sum+=this[i]*o[i];
	return sum;
	}

public static complex operator%(cvector a,cvector b){
	return a.dot(b);
	}

public cvector map(System.Func<complex,complex>f){
	cvector v=new cvector(size);
	for(int i=0;i<size;i++)v[i]=f(this[i]);
	return v;
	}

// public double norm(){
// 	double meanabs=0;
// 	for(int i=0;i<size;i++)meanabs+=abs(this[i]);
// 	if(meanabs==0)meanabs=1;
// 	meanabs/=size;
// 	double sum=0;
// 	for(int i=0;i<size;i++)sum+=(this[i]/meanabs)*(this[i]/meanabs);
// 	return meanabs*Sqrt(sum);
// 	}

public cvector copy(){
	cvector b=new cvector(this.size);
	for(int i=0;i<this.size;i++)b[i]=this[i];
	return b;
}

public static bool approx(complex x, complex y, double acc=1e-9, double eps=1e-9){
	if(abs(x-y)<acc)return true;
	if(abs(x-y)/Max(abs(x),abs(y))<eps)return true;
	return false;
	}

public static bool approx(cvector a,cvector b,double acc=1e-9,double eps=1e-9){
	if(a.size!=b.size)return false;
	for(int i=0;i<a.size;i++)
		if(!approx(a[i],b[i],acc,eps))return false;
	return true;
}
public bool approx(cvector o){
	for(int i=0;i<size;i++)
		if(!approx(this[i],o[i]))return false;
	return true;
	}


/*_________________________________________________________*/

public static cvector operator*(double a, cvector v){
	cvector r=new cvector(v.size);
	for(int i=0;i<v.size;i++) r[i]=a*v[i].Re+v[i].Im*I;
	return r; }



}//vector