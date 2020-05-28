all:A.svg B.txt C.svg

A.svg: out.txt Makefile
# 	rm fit.log
	echo '\
	set term svg font "Arial,14";\
	set out "$@";\
	set title "Rutherford and Soddy Experiment" font ",18";\
	set grid;\
	set xlabel "Time [Days]" font ",16";\
	set ylabel "Per-cent Activity" font ",16";\
	plot "$<" with errorbars title "Experimental Data"\
	,"$<" index 1 with lines title "Exponential Fit"\
	' | gnuplot

C.svg: out.txt Makefile
	echo '\
	set term svg font "Arial,14";\
	set out "$@";\
	set title "Rutherford and Soddy Experiment" font ",18";\
	set log y;\
	set xlabel "Time [Days]" font ",16";\
	set ylabel "Per-cent Activity" font ",16";\
	set grid;\
	plot[][10:200] "out.txt" with errorbars title "Experimental Data"\
	,"out.txt" index 1 with lines title "Best Fit"\
	,"out.txt" index 2 with lines title "c_0+dc_0"\
	,"out.txt" index 3 with lines title "c_0-dc_0"\
	,"out.txt" index 4 with lines title "c_1+dc_1"\
	,"out.txt" index 5 with lines title "c_1-dc_1"\
	' | gnuplot

out.txt B.txt :main.exe
	mono $< 1> out.txt 2>B.txt

main.exe: main.cs lsfit.cs matlib.dll
	mcs $(filter-out %.dll,$^) -reference:$(lastword $^)

SRC := \
$(HOME)/PPNM/matlib/matrix/vector.cs\
$(HOME)/PPNM/matlib/matrix/matrix.cs\
$(HOME)/PPNM/problems/2_linearequations/B/gramschmidt.cs\
$(HOME)/PPNM/problems/2_linearequations/B/backsubst.cs\
$(HOME)/PPNM/problems/2_linearequations/B/solve.cs\
$(HOME)/PPNM/problems/2_linearequations/B/inverse.cs\

matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.dll *.exe A* B* C* log*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))