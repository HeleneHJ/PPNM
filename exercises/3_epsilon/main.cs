using System;
using static System.Console;
using static System.Math;
using static precision;
class main{
	static int Main(){
Write("A)\n"); 
	Write("i)\n");
		int i=1; while(i+1>i){i++;}
		Write("My max int = {0}\n",i);
		Write("int.MaxVal = {0}\n",int.MaxValue);
	Write("ii)\n");
		int j=-1; while(j-1<j){j--;}
		Write("My min int = {0}\n",j);
		Write("int.MinVal = {0}\n",int.MinValue);
		// All the values agree


//B) /* "Machine epsilon" gives an upper bound on the relative error due to rounding in floating point arithmetic */
Write("\nB)\n"); 
		double x=1; 
		while(1+x!=1){x/=2;} x*=2;
		Write("double = {0}\n",x);
		float y=1F; 
		while((float)(1F+y) != 1F){y/=2F;} y*=2F;
		Write("float = {0}\n",y);
		//	Write("double machine epsilon = {0}\n",System.Math.Pow(2,-52)); 
		//	Write("single precision = {0}\n",System.Math.Pow(2,-23)); 


Write("\nC)\n");		
	Write("i)\n");
		int max=int.MaxValue/3;
		float float_sum_up=1F;
		for(int k=2;k<max;k++)float_sum_up+=1F/k;
		Write("float_sum_up={0}\n",float_sum_up);		//	float_sum_up=15.40368
		float float_sum_down=1F/max;
		for(int k=max-1;k>0;k--)float_sum_down+=1F/k;
		Write("float_sum_down={0}\n",float_sum_down);	//	float_sum_down=18.80792
		Write("(Note: The maximum value is divided by 3 to reduce computation time.)\n");

		Write("ii) Explain the difference:\n");
		Write("The floating point type is not precise (it has 7 significant digits). In 'float_sum_up', we start with the largest number and add smaller and smaller values, so more of the significant digits need to be dropped for the smallest added numbers, while in 'float_sum_down' we start with the smallest number and add larger and larger numbers, allowing the least significant decimals to accumulate.\n");

		Write("iii) Does this sum converge as a functions of max?\n");
		Write("The sum does not converge.\n");

		Write("iv)\n");
		double sum_up_double=1D;
		for(int k=2;k<max;k++)sum_up_double+=1D/k;
		Write("sum_up_double={0}\n",sum_up_double);		//sum_up_double=20.9661659719623

		double sum_down_double=1D/max;
		for(int k=max-1;k>0;k--)sum_down_double+=1D/k;
		Write("sum_down_double={0}\n",sum_down_double);	//sum_down_double=20.9661659733582
		Write("Explain the result:\n");
		Write("The double point type  (with 15 significant digits) is more precise than the float type, and hence, these sums are not as sensitive to the 'direction' in which the numbers are added, however, it does not return identical values.\n");


	Write("\nD)\n");
		Write("Test:\n");
		double a=1.1e-8;
		double b=1.2e-8;
		Write($"{a} and {b} are equal with absolute precision or relative precision: ");
		if(precision.Approx(a,b)==true){
			Write("true\n");
		}
		else{
			Write("false\n");
		}

		Write("Test:\n");
		double c=1.1e-9;
		double d=1.2e-9;
		Write($"{c} and {d} are equal with absolute precision or relative precision: ");
		if(precision.Approx(c,d)==true){
			Write("true\n");
		}
		else{
			Write("false\n");
		}	
	return 0;
	}
}