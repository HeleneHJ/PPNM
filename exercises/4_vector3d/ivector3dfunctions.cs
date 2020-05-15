using System;
public class ivector3dfunctions{
	
	public static double dot(vector3d u, vector3d v){ 
		return u.x*v.x+u.y*v.y+u.z*v.z; 
	}

	public static vector3d cross(vector3d u, vector3d v){ 
		return new vector3d(u.y*v.z-u.z*v.y,u.z*v.x-u.x*v.z,u.x*v.y-u.y*v.x); 
	}

	public static double magnitude(vector3d u){ 
		return Math.Sqrt(Math.Pow(u.x,2)+Math.Pow(u.y,2)+Math.Pow(u.z,2)); 
	}
}


