using static System.Math;
public static partial class specfunc{
public static double lngamma(double x){
/// single precision gamma function (Gergo Nemes, from Wikipedia)
if(x<=0)return double.NaN;
if(x<9)return lngamma(x+1)-Log(x);
double result=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
return result;
}
}