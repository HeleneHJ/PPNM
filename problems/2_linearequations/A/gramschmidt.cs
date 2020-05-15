public partial class gramschmidt{
public readonly matrix Q,R;
public gramschmidt(matrix A){
	Q=A.copy(); int m=Q.size2;
	R=new matrix(m,m);
	for(int i=0;i<m;i++){
		R[i,i]=Q[i].norm();
		Q[i]/=R[i,i];
		for(int j=i+1;j<m;j++){
			R[i,j]=Q[i]%Q[j];
			Q[j]-=Q[i]*R[i,j];
			}
		}
	}//gramschmidt
}//class gramschmidt