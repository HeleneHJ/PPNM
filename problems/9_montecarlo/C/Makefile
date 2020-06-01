all: Miser.png

Miser.png:out.miser Makefile
	echo '\
	set term png;\
	set out "$@";\
	set title "Stratified sampling: miser";\
	set size ratio 1;\
	set xlabel "x";\
	set ylabel "y";\
	set xtics 0.5;\
	set ytics 0.5;\
	set pointsize 0.2;\
	plot "$<" notitle with points pt 3;\
	'|gnuplot

out.miser:main.exe
	mono $< 1>out.miser 2>Log

main.exe:main.cs miser.cs plain.cs matlib.dll
	mcs $(filter %.cs,$^) $(addprefix -r:,$(filter %.dll,$^))

LIBDIR=../../../matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/minimum/simplex.cs\
	$(LIBDIR)/minimum/qnewton.cs

matlib.dll: $(LIBSRC)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og* *.svg *.png