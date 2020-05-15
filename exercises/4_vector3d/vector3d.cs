using System;
using static System.Math;
public struct vector3d : ivector3d{

	private double a,b,c;
	public double x{get{return a;} set{a=value;}}
	public double y{get{return b;} set{b=value;}}
	public double z{get{return c;} set{c=value;}}

	//constructors
	public vector3d(double x,double y,double z){a=x;b=y;c=z;}

	//operators
	public static vector3d operator*(vector3d v, double c){return new vector3d(c*v.x,c*v.y,c*v.z);}
	public static vector3d operator*(double c, vector3d v){return new vector3d(c*v.x,c*v.y,c*v.z);}
	public static vector3d operator+(vector3d u, vector3d v){return new vector3d(u.x+v.x,u.y+v.y,u.z+v.z);}
	public static vector3d operator-(vector3d u, vector3d v){return new vector3d(u.x-v.x,u.y-v.y,u.z-v.z);}

	//printing
	public void print(string s=""){
		System.Console.WriteLine($"{s} {this.x} {this.y} {this.z}");
		}
	public override string ToString(){
		return string.Format("{0} {1} {2}",x,y,z);
	} 
}