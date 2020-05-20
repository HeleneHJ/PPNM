using System;
using static System.Math;
public partial class givens{
public vector solve(vector b){
		vector x=b.copy();
		double theta;
		double xp;
		double xq;
		for(int q=0;q<G.size2;q++){				/* Iterating over all thetas */
			for(int p=q+1;p<G.size1;p++){
				theta=G[p,q];
				xp=Cos(theta)*x[q]+Sin(theta)*x[p];
				xq=-Sin(theta)*x[q]+Cos(theta)*x[p];
				x[q]=xp;
				x[p]=xq;
			}
		}
	backsubst(G,x);
	return x;
	}//solve
}//class givens