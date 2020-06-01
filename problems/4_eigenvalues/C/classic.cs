using System;
using static System.Math;
using static System.Console;
public partial class jacobi{
    public readonly matrix A;
static public int classic(matrix B, vector e, matrix V=null){
/* Jacobi diagonalization. Upper triangle of A is destroyed.
   e and V accumulate eigenvalues and eigenvectors */
matrix A=B.copy();
bool changed; int rotations=0, n=A.size1;
for(int i=0;i<n;i++) e[i]=A[i,i];
for(int i=0;i<n;i++){
    V[i,i]=1.0; for(int j=i+1;j<n;j++){V[i,j]=0;V[j,i]=0;}
    }
do{
    rotations++; changed=false;
    WriteLine($"{A[0,0]} {A[0,1]} {A[0,2]} {A[0,3]} {A[0,4]}");
    for(int p=0;p<n-1;p++){
        WriteLine($"p: {p}");
        int q=p+1;
        double max=Abs(A[p,q]);
        for(int j=p+2;j<n;j++){
            WriteLine($"A0: {A[0,0]} {A[0,1]} {A[0,2]} {A[0,3]} {A[0,4]}");
            if(max<=Abs(A[p,j])){
                max=Abs(A[p,j]);
                q=j;
                // WriteLine($"max:({p},{q}), A[p,q]: {A[p,q]} A[1,4]: {A[1,4]}");
                }
            }
            // WriteLine($"q: {q}");
            double app=e[p];
            double aqq=e[q];
            double apq=A[p,q];                  
            double phi=0.5*Atan2(2*apq,aqq-app);
            double c=Cos(phi), s=Sin(phi);
            double app1=c*c*app-2*s*c*apq+s*s*aqq;  
            double aqq1=s*s*app+2*s*c*apq+c*c*aqq;  
            if(app1!=app || aqq1!=aqq){
                changed=true;
                e[p]=app1;
                e[q]=aqq1;
                A[p,q]=0.0;
                for(int i=0;i<p;i++){
                    double aip=A[i,p];
                    double aiq=A[i,q];
                    A[i,p]=c*aip-s*aiq;
                    A[i,q]=c*aiq+s*aip;
                }
                for(int i=p+1;i<q;i++){
                    double api=A[p,i];
                    double aiq=A[i,q];
                    A[p,i]=c*api-s*aiq;
                    A[i,q]=c*aiq+s*api;
                }
                for(int i=q+1;i<n;i++){
                    double api=A[p,i];
                    double aqi=A[q,i];
                    A[p,i]=c*api-s*aqi;
                    A[q,i]=c*aqi+s*api;
                }
                if(V!=null)for(int i=0;i<n;i++){   
                    double vip=V[i,p];              
                    double viq=V[i,q];
                    V[i,p]=c*vip-s*viq;
                    V[i,q]=c*viq+s*vip;
                    }
                }
                A.printfloat("After rotation:");
            }
    }while(changed);
    return rotations;
    }
}
