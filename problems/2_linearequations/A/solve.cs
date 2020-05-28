public partial class gramschmidt{
public vector solve(vector b){
	var c=Q%b;			// the operator "%" is defined in the matrix matlib and corresponds to Q.T*b
	c.print("c:");
	backsubst(c);
	return c;
	}//solve
}//class gramschmidt