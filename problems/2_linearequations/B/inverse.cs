public partial class gramschmidt{
public matrix inverse(){
	int n=Q.size1,m=Q.size2;
	var B=new matrix(m,n);
	var e=new vector(n);
	for(int i=0;i<n;i++){
		e[i]=1;
		B[i]=solve(e);
		e[i]=0;
		}
	return B;
	}//solve
}//class gramschmidt