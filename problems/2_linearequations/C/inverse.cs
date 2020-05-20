public partial class givens{
public matrix inverse(){
	int n=G.size1,m=G.size2;
	var B=new matrix(m,n);
	var e=new vector(n);
	for(int i=0;i<n;i++){
		e[i]=1;
		B[i]=solve(e);
		e[i]=0;				// we reset the basis-vector to avoid a accumulation of "1" in each entrance
		}
	return B;
	}//solve
}//class givens