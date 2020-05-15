public partial class gramschmidt{
public vector solve(vector b){
	var c=Q%b;
	backsubst(c);
	return c;
	}//solve
}//class gramschmidt