using static System.Console;
using static System.Math;

public class QRgivens{
	protected int n;
	protected int m;

	public QRgivens(matrix A){
		n = A.size1;
		m = A.size2;
		decomp(A);
	}

	matrix G;
	public matrix _G{get{return G;}}

	public void decomp(matrix A){ 				/* Decomposes A to an upper triangular matrix R with the relevant Givens angles below the diagonal */
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
	}	
	
	public vector solve(vector b){
		vector x=applyrot(b); 					/* Applying the Givens rotations (specified by the thetas in G) to the vector b */
		backsubst(G,x);							/* Solving the system by backsubstitution with the upper diagonal part of the matrix */
		return x;
	}
	
	public vector applyrot(vector b){
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
		return x;
	}

	public void backsubst(matrix R,vector x){
		int l=x.size;
		x[l-1]=x[l-1]/R[l-1,l-1];
		for(int i=l-2;i>=0;i--){
			double s=0;
			for(int k=i+1;k<=l-1;k++)s+=R[i,k]*x[k];
			x[i]=(x[i]-s)/(R[i,i]);
		}
	}
	
	public matrix inverse(){
		matrix inv = new matrix(n,m);
		vector v;
		for(int j=0;j<m;j++){
			v = solve(unitvector(j));
			for(int i=0;i<n;i++){
				inv[i,j]=v[i];
			}
		}
		return inv;
	}
	
	vector unitvector(int i){					/* Unit vector with 1 in i and 0 everywhere else */
		vector e=new vector(n);
		for(int j=0;j<n;j++){
			if(j==i){
				e[j]=1;
			}
			else{
				e[j]=0;
			}
		}
		return e;
	}
}