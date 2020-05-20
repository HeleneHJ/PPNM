public partial class gramschmidt{
public readonly matrix Q,R;
public gramschmidt(matrix A){
	Q=A.copy(); int m=Q.size2;
	R=new matrix(m,m);				// R is created with 0 in all entrances
	for(int i=0;i<m;i++){
		R[i,i]=Q[i].norm(); 	
		Q[i]/=R[i,i];   			// Q[i]=Q[i]/R[i,i]
		for(int j=i+1;j<m;j++){		// start value for j=i+1, and then 1 is added for each iteration
			R[i,j]=Q[i]%Q[j];		// "%" takes the dot product of the two vectors
			Q[j]-=Q[i]*R[i,j]; 		// Q[j]=Q[j]-Q[i]*R[i,j]
			}
		}
	}//gramschmidt
}//class gramschmidt