public partial class gramschmidt{
public void backsubst(vector c){// in-place
	for(int i=c.size-1;i>=0;i--){
		double s=0;
		for(int k=i+1;k<c.size;k++)s+=R[i,k]*c[k];
		c[i]=(c[i]-s)/R[i,i];
	}
}//backsubst
}//class gramschmidt