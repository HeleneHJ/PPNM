all: rk12.svg rk23.svg rk45.svg

out12.txt: main12.exe
	mono $< 1> $@ 2>> Log
main12.exe: main12.cs matlib.dll
	mcs $< -reference:matlib.dll
out23.txt: main23.exe
	mono $< 1> $@ 2> Log
main23.exe: main23.cs matlib.dll
	mcs $< -reference:matlib.dll
out45.txt: main45.exe
	mono $< 1> $@ 2> Log
main45.exe: main45.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR=../../../matlib/matrix
matlib.dll: $(LIBDIR)/vector.cs driver12.cs rkstep12.cs driver23.cs rkstep23.cs driver45.cs rkstep45.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe out* *.svg [Ll]og*

rk12.svg: out12.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16";\
	set out "rk12.svg";\
	set key out;\
	set tics out;\
	set title "dy_0/dx=y_1, dy_1/dx=-y_0 (using RK 1-2)" font ",18";\
	set xlabel "x";\
	set ylabel "y";\
	plot[0:7][-1.1:1.1] \
	 "out12.txt" using 1:2 with points pt 7 ps 0.5 title "y_0" \
	,"out12.txt" using 1:3 with points pt 5 ps 0.5 title "y_1" \
	,sin(x) title "sin"\
	,cos(x) title "cos"\
	'|gnuplot

rk23.svg: out23.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16";\
	set out "rk23.svg";\
	set key out;\
	set tics out;\
	set title "dy_0/dx=y_1, dy_1/dx=-y_0 (using RK 2-3)" font ",18";\
	set xlabel "x";\
	set ylabel "y";\
	plot[0:7][-1.1:1.1] \
	 "out23.txt" using 1:2 with points pt 7 ps 0.5 title "y_0" \
	,"out23.txt" using 1:3 with points pt 5 ps 0.5 title "y_1" \
	,sin(x) title "sin"\
	,cos(x) title "cos"\
	'|gnuplot

rk45.svg: out45.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16";\
	set out "rk45.svg";\
	set key out;\
	set tics out;\
	set title "dy_0/dx=y_1, dy_1/dx=-y_0 (using RK 4-5)" font ",18";\
	set xlabel "x";\
	set ylabel "y";\
	plot[0:7][-1:1] \
	 "out45.txt" using 1:2 with points pt 7 ps 0.5 title "y_0" \
	,"out45.txt" using 1:3 with points pt 5 ps 0.5 title "y_1" \
	,sin(x) title "sin"\
	,cos(x) title "cos"\
	'|gnuplot	