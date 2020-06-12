Higgs.svg: plot.txt Makefile
	gnuplot -e "\
	set term svg background rgb 'white' font ',14';\
	set title 'Higgs Production Signal' font ',18';\
	set xlabel 'Energy [GeV]';\
	set ylabel 'Signal [arb.u.]';\
	plot 'higgs.txt' using 1:2:3 with errorbars title 'exp'\
	, '$<' using 1:2 with lines title 'fit' ;\
	" > $@

plot.txt: main.exe
	mono $< <higgs.txt 1>results.txt 2>$@

main.exe: main.cs qnewton.dll matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:exe -r:$$libs -out:$@

LIBDIR=../../../matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs
matlib.dll:$(LIBSRC)
	mcs $^ -target:library -out:$@

qnewton.dll: ../A/qnewton.cs matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og* *.svg

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))