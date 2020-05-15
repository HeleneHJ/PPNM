using static System.Console;
class main{
static void Main(){
	
	double c=4;

	vector3d u=new vector3d(1,2,3);
	vector3d v=new vector3d(2,-7,6);

	u.print("u = ");
	v.print("v = ");

	double d=ivector3dfunctions.dot(u,u);
	WriteLine($"dot(u,u) = {d}");

	double e=ivector3dfunctions.dot(u,v);
	WriteLine($"dot(u,v) = {e}");

	double f=ivector3dfunctions.magnitude(u);
	WriteLine($"|u|= {f}");

	vector3d k=ivector3dfunctions.cross(u,u);
	k.print("cross(u,u) =");

	vector3d l=ivector3dfunctions.cross(v,u);
	l.print("cross(u,v) =");

	WriteLine($"4*v = {c*v}");
	WriteLine($"u+v = {u+v}");
	WriteLine($"v+u = {v+u}");
	WriteLine($"u-v = {u-v}");
}
}

