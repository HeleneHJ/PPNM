all:A.svg 

A.svg: out.txt Makefile
#	rm fit.log
	echo '\
	set term svg font ",20";\
	set out "$@";\
	set title "Rutherford and Soddy experiment";\
	set xlabel "Time in Days";\
	set ylabel "Per-cent Activity";\
	a=100;b=0.2;c=1;\
	f(x)=a*exp(-b*x)+c;\
	fit f(x) "$<" u 1:2:3 yerrors via a,b,c;\
	plot "$<" with errorbars title "experimental data"\
	,"$<" index 1 with lines title "exponential fit"\
	,f(x) with lines title "gnuplot fit"\
	' | gnuplot

main.exe: main.cs lsfit.cs matlib.dll
	mcs $(filter-out %.dll,$^) -reference:$(lastword $^)

out.txt: main.exe
	mono $< 1> $@

SRC := \
$(HOME)/PPNM/matlib/matrix/vector.cs\
$(HOME)/PPNM/matlib//matrix/matrix.cs\
$(HOME)/PPNM/problems/2_linearequations/B/gramschmidt.cs\
$(HOME)/PPNM/problems/2_linearequations/B/backsubst.cs\
$(HOME)/PPNM/problems/2_linearequations/B/solve.cs\
$(HOME)/PPNM/problems/2_linearequations/B/inverse.cs\

matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.dll *.exe A* log*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))