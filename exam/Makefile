DATA = out.txt
PLOT = plot.svg
all: out.txt plot.svg

out.txt: main.exe
	mono $< 1> $@ 2> out2.txt
	
main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../matlib
matlib.dll: driver.cs rkstep23.cs cvector.cs cmath.cs $(LIBDIR)/matrix/vector.cs $(LIBDIR)/complex/complex.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe out* 

$(PLOT): $(DATA) Makefile
	echo '\
	set term svg background rgb "white";\
	set out "$(PLOT)";\
	set key out;\
	set tics out;\
	set xlabel "x";\
	plot \
	 "$(DATA)" using 1:2 with points pt 7 ps 0.5 title "y_0" \
	,"$(DATA)" using 1:3 with points pt 5 ps 0.5 title "y_1" \
 	,sin(x) title "sin"\
	,cos(x) title "cos"\
	'|gnuplot
	