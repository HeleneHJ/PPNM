Plot.svg:out.txt Makefile
	echo '\
	set term svg size 640,480 background rgb "white" font ",14";\
	set out "$@";\
	set key out;\
	set tics out;\
	set title "Neural Network Curve Fitting" font ",18";\
	set xlabel "x";\
	set ylabel "y";\
	plot\
	 "$<" index 0 with points pointtype 6 title "Data"\
	,"$<" index 1 with lines title "Fit"\
	,"$<" index 2 u 1:3 with points pointtype 1 title "Integ"\
	,"$<" index 2 u 1:4 with points pointtype 1 title "Deriv"\
	'|gnuplot

out.txt:main.exe
	mono $< 1>$@ 2>log

main.exe:main.cs network.cs matlib.dll
	mcs $(filter %.cs,$^) $(addprefix -r:,$(filter %.dll,$^))
#	mcs $(filter %.cs,$^) -reference:$(lastword $^)

LIBDIR=../../../matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/minimum/simplex.cs\
	$(LIBDIR)/minimum/qnewton.cs\
	$(LIBDIR)/integration/quado8.cs

matlib.dll: $(LIBSRC)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og* *.svg