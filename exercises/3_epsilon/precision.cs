using System;
using static System.Math;
public static class precision{

	public static bool Approx(double a, double b, double tau = 1e-9, double epsilon = 1e-9){
		if(Abs(a-b)<tau){
			return true;
		}
		else if(Abs(a-b)/(Abs(a)+Abs(b))<epsilon/2){
			return true;
		}
		else{
			return false;
		}
	}
}
