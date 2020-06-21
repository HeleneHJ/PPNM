all: out.txt log sin.svg cos.svg

out.txt: main.exe
	mono $< 1> $@ 2> log
	
main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = $(HOME)/repos/PPNM/matlib
matlib.dll: driver.cs rkstep23.cs cvector.cs cmath.cs $(LIBDIR)/matrix/vector.cs $(LIBDIR)/complex/complex.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe out* 

sin.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16" size 1024,600;\
	set out "sin.svg";\
	set key out;\
	set tics out;\
	set title "dy_0=sin(z)" font ",18";\
	set xlabel "x";\
	set ylabel "y";\
	plot \
	 "out.txt" using 1:3 with points pt 7 ps 0.5 title "Re(y_0)" \
	,"out.txt" using 1:4 with points pt 5 ps 0.5 title "Im(y_0)" \
	,sin(x)*cosh(x) title "Real part of sin(z)"\
	,cos(x)*sinh(x) title "Imaginary part of sin(z)"\
	'|gnuplot

cos.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16" size 1024,600;\
	set out "cos.svg";\
	set key out;\
	set tics out;\
	set title "dy_1=cos(z)" font ",18";\
	set xlabel "x";\
	set ylabel "y";\
	plot \
	 "out.txt" using 1:5 with points pt 7 ps 0.5 title "Re(y_0)" \
	,"out.txt" using 1:6 with points pt 5 ps 0.5 title "Im(y_1)" \
	,cos(x)*cosh(x) title "Real part of cos(z)"\
	,-sin(x)*sinh(x) title "Imaginary part of cos(z)"\
	'|gnuplot