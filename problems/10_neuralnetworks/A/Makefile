Plot.svg:out.txt Makefile
	echo '\
	set term svg size 640,480 background rgb "white";\
	set out "$@";\
	set key out;\
	set tics out;\
	set title "neural network curve fitting";\
	set xlabel "x";\
	set ylabel "y";\
	plot\
	 "$<" index 0 with points pointtype 6 title "data"\
	,"$<" index 1 with lines title "fit"\
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
	$(LIBDIR)/minimum/qnewton.cs

matlib.dll: $(LIBSRC)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og* *.svg