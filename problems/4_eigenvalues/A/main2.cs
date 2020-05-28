using System;
using static System.Console;
using static System.Math;
public class main{
public static void Main(string[] args){
/* In the problem: the Schrödinger equation is rewritten to a matrix eigenvalue problem: H*u = epsilon*u  */
/* "If [we] give the matrix H to [the] diagonalization routine it will return a vector e with eigenvalues and a matrix V with the corresponding eigenvectors as columns */

  int n=200;

  var H = new matrix(n,n);
  double s=1.0/(n+1);
    for(int i=0;i<n-1;i++){         /* Building the Hamiltonian matrix H (as described in the problem) */
      matrix.set(H,i,i,-2);             /* The diagonal of H */
      matrix.set(H,i,i+1,1);            /* Entries right "after" the diagonal elements */
      matrix.set(H,i+1,i,1);            /* Entries right "before" the diagonal elements*/
      }
  matrix.set(H,n-1,n-1,-2);             /* The last diagonal element equal to -2 */
  matrix.scale(H,-1/s/s);               /* The scaling factor of -1/s^2 */

  var e=new vector(n);
  var V=new matrix(n,n);
  int sweeps=jacobi.cyclic(H,e,V);  /* Diagonalizing using the Jabobi routine */

  // for(int k=0;k<Min(n/3,30);k++){     /* Checking that the energies are correct */
  for(int k=0;k<30;k++){     /* Checking that the energies are correct */
      double calculated = e[k];
      double exact = PI*PI*(k+1)*(k+1);             /* E_n = n^2*pi^2*hbar^2/(2*m*L^2) */
      WriteLine($"{k} {calculated} {exact}");
    }

  WriteLine("\n\n");

  int waves=4;                     /* Number of standing waves in the plot */
  for(int k=0;k<waves;k++){        /* For plotting several of the lowest eigenfunctions */
    WriteLine($"{0} {0}");
    for(int i=0;i<n;i++){
      double factor=Sign(V[0,k])/Sqrt(s);
      WriteLine($"{(i+1.0)/(n+1)} {matrix.get(V,i,k)*factor}");
      }
    WriteLine($"{1} {0}\n");
  }

}//Main
}//main