public partial class gramschmidt{
public vector solve(vector b){
	var c=Q%b;
	c.print("c:");
	backsubst(c);
	return c;
	}//solve
}//class gramschmidt