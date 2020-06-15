all: out.txt Plot.svg Plotdiff.svg Plotint.svg

Plot.svg: out.txt Makefile
	echo '\
	set term svg size 640,480 background rgb "white" font ",14";\
	set out "$@";\
	set key out;\
	set tics out;\
	set title "Neural Network Curve Fitting" font ",18";\
	set xlabel "x";\
	set ylabel "y";\
	plot[][-1.2:1.2]\
	 "$<" index 0 u 1:2 with points pointtype 6 title "Data"\
	,"$<" index 1 u 1:2 with lines title "Fit"\
	'|gnuplot

Plotdiff.svg: out.txt Makefile
	echo '\
	set term svg size 640,480 background rgb "white" font ",14";\
	set out "$@";\
	set key out;\
	set tics out;\
	set title "Neural Network Differential Fitting" font ",18";\
	set xlabel "x";\
	set ylabel "y";\
	plot[][-1.2:1.2]\
	 "$<" index 0 u 1:3 with points pointtype 6 title "Data"\
	,"$<" index 1 u 1:3 with lines title "Fit"\
	'|gnuplot

Plotint.svg: out.txt Makefile
	echo '\
	set term svg size 640,480 background rgb "white" font ",14";\
	set out "$@";\
	set key out;\
	set tics out;\
	set title "Neural Network Anti-differential Fitting" font ",18";\
	set xlabel "x";\
	set ylabel "y";\
	plot[][-1.2:1.2]\
	 "$<" index 0 u 1:4 with points pointtype 6 title "Data"\
	,"$<" index 1 u 1:4 with lines title "Fit"\
	'|gnuplot


out.txt: main.exe
	mono $< 1>$@ 2>log

main.exe: main.cs network.cs matlib.dll
	mcs $(filter %.cs,$^) $(addprefix -r:,$(filter %.dll,$^))
#	mcs $(filter %.cs,$^) -reference:$(lastword $^)

LIBDIR=../../../matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/minimum/simplex.cs\
	$(LIBDIR)/minimum/qnewton.cs

matlib.dll: $(LIBSRC)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og* *.svg