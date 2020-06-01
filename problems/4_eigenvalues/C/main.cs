using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;
class main{
static void Main(){
    int n=5; //size of real symmetric matrix 
    matrix A=new matrix(n,n);
    var rnd=new Random(1);
    for(int i=0;i<n;i++){                       /* Construction of a random vector */
        for(int j=0;j<n;j++){
            A[i,j]=(rnd.NextDouble()*10);
            A[j,i]=A[i,j];                      /* We make sure that the matrix is symmetric */
    }
    }
    A.printfloat("Random symmetric matrix, A:");
    matrix V=new matrix(n,n);
    matrix V2=new matrix(n,n);
    vector e=new vector(n);
    vector e2=new vector(n);
    // matrix B=A.copy();
    matrix B2=A.copy();

    int rotations=jacobi.classic2(A,e,V);            /* We use the jacobi matlib for the implementation of the cyclic sweeps: public static int cyclic(matrix A, vector e, matrix V=null){...} */
    WriteLine($"\nNumber of rotations: {rotations}");
    // matrix D=(V.T*B*V);
    // D.printfloat("\nClassic: Eigenvalue-decomposition, V^T*A*V (should be diagonal):"); 
    
    int sweeps=jacobi.cyclic(B2,e2,V2);
    WriteLine($"Number of sweeps: {sweeps}");
    // matrix D2=(V2.T*B*V2);
    // D2.printfloat("\nCyclic: Eigenvalue-decomposition, V^T*A*V (should be diagonal):"); 

    // var rnd = new Random(1);
    // int n = 4;
    // matrix v_c = new matrix(n,n);
    // matrix v_classic = new matrix(n,n);
    // vector e_classic = new vector(n);

    // var A_c = new matrix(n,n);
    // for(int i=0;i<n;i++){
    //     for(int j=i;j<n;j++){
    //         A_c[i,j]=2*(rnd.NextDouble()-0.5); 
    //         A_c[j,i]=A_c[i,j];
    //     }
    // }
    // matrix B=A_c.copy();

    // var A_classic = A_c.copy();
    // int rotations = classic(A_classic,e_classic,v_classic);
    // A_classic.printfloat("A classic transformed");
    // // e_classic.print("Eigenvalues calculated with classic:");
    // // v_classic.print("Eigenvectors calculated with classic:");
    // var VTAV=v_classic.T*B*v_classic;
    // VTAV.printfloat("V^T*A*V:");
}
}