using System;
using static System.Math;
public partial class jacobi{
public static int cyclic(matrix A, vector e, matrix V=null){
/* Jacobi diagonalization. Upper triangle of A is destroyed.
   e and V accumulate eigenvalues and eigenvectors */
bool changed; int sweeps=0, n=A.size1;
for(int i=0;i<n;i++) e[i]=A[i,i];			// e[i] is the diagonal elements of A
if(V!=null) for(int i=0;i<n;i++){			// we make sure that V is a diagonal matrix with value 1 in every diagonal entry
	V[i,i]=1.0; for(int j=i+1;j<n;j++){V[i,j]=0;V[j,i]=0;}
	}
do{
	sweeps++; changed=false; int p,q;		// if the ... does not change, 
	for(q=n-1;q>0;q--)for(p=0;p<q;p++){
		double app=e[p];					// we set a_pp=e[p]
		double aqq=e[q];					// we set a_qq=e[q]
		double apq=A[p,q];					// we set a_pq=A[p,q];
		double phi=0.5*Atan2(2*apq,aqq-app); 	// we calculate phi (eq. 11 in chapter) /* 0 if aqq-app>0 */
		double c = Cos(phi), s = Sin(phi);	// we define "c" as cosine and "s" as sine of phi
		double app1=c*c*app-2*s*c*apq+s*s*aqq;	// equation 10 for A'[p,p]
		double aqq1=s*s*app+2*s*c*apq+c*c*aqq;	// equation 10 for A'[q,q]
		if(app1!=app || aqq1!=aqq){		// if A[p,p] does not equal A'[p,p] OR A[q,q] does not equal A'[q,q]
			changed=true;				// then change is true (i.e., a change has happen with respect to the previous iteration)	
			e[p]=app1;					// we set e[p]=A'[p,p]
			e[q]=aqq1;					// and e[q]=A'[q,q]
			A[p,q]=0.0;					// with A[p,q]=0
			for(int i=0;i<p;i++){		// the following for loops calculates entrances in A as described in equation 10
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
			if(V!=null)for(int i=0;i<n;i++){	// calculates equation 12 in chapter, which describes the transformation at each stage
				double vip=V[i,p];				
				double viq=V[i,q];
				V[i,p]=c*vip-s*viq;
				V[i,q]=c*viq+s*vip;
			}
		}
	}
}while(changed);
return sweeps;	// sweeps equals the number of iterations required to determine the eigenvalues
}
}