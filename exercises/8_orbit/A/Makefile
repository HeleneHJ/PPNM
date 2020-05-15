all : plot.svg

out.txt: main.exe
	mono $^ 1> $@ 2> log

main.exe: main.cs math.dll 
	mcs -reference:math.dll main.cs

logplot.exe: logplot.cs logfunc.cs math.dll
	mcs -reference:math.dll logplot.cs logfunc.cs

out.logplot.txt: logplot.exe #logfunc.exe
	mono $< > $@ 2> log

LIBDIR = ../../../matlib
math.dll: $(LIBDIR)/matrix/vector.cs $(LIBDIR)/ode/bak.ode.cs logfunc.cs
	mcs -target:library -out:math.dll $^

plot.svg: out.txt out.logplot.txt Makefile
	echo '\
	set term svg font ",18" background rgb "white" ;\
	set out "$@" ;\
	set title "Logistic Function" ;\
	set xlabel "x" ;\
	set ylabel "f(x)" ;\
	set xzeroaxis ;\
	set yzeroaxis ;\
	set key bottom right ;\
	set grid ;\
	plot [0:3][0.5:1] "out.logplot.txt" with lines lt rgb "red" title "Logistic Function", "out.txt" with points pt 7 ps 0.7 title "Numerical Solution" ;\
	'| gnuplot

clean :
	rm --force *-dll out* *.exe *.svg