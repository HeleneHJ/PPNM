all: out.txt log

out.txt: main.exe
	mono $< 1> $@ 2> log
	
main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = $(HOME)/repos/PPNM/matlib
matlib.dll: driver.cs rkstep23.cs cvector.cs cmath.cs $(LIBDIR)/matrix/vector.cs $(LIBDIR)/complex/complex.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe out* 
