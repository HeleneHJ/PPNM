using static System.Math;
public static class logfunc{
public static double logistic(double x){
	// calculates the Logistic function
	double y=1/(1+Exp(-1*x));
	return y;
}
}