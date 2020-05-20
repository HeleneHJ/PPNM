using System;
using static System.Math;
public partial class givens{
public readonly matrix G;
public givens(matrix A){
		G = A.copy();
		int n=G.size1;
		int m=G.size2;
		double theta;
		double xp;
		double xq;
		for(int q=0;q<m;q++){ 					/* Iterating over the columns */
			for(int p=q+1;p<n;p++){ 			/* Iterating over all rows below the diagonal */
				theta=Atan2(G[p,q],G[q,q]); 	/* Recalculating the relevant rows (the angles are saved in the matrix instead of the 0's) */
				for(int k=q;k<m;k++){
					xp=Cos(theta)*G[q,k]+Sin(theta)*G[p,k];
					xq=-Sin(theta)*G[q,k]+Cos(theta)*G[p,k];
					G[q,k]=xp;
					G[p,k]=xq;	
				}	
				G[p,q]=theta;	
			}
		}
	}//givens
}//class givens