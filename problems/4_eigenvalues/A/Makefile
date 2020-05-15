MCS = mcs -optimize+ -platform:arm
MONO = mono -O=all
#-O=all,-shared #--optimize=unsafe,loop,inline #--gc=sgen --llvm --optimize=all

comma:=,
empty:=
space:=$(empty) $(empty)
commalist = $(subst $(space),$(comma),$(1))

all: A.evd.out A.box.psi.svg A.box.e.svg

A.evd.out: main-a1.exe
	$(MONO) $< > $@

main-a1.exe: main-a1.cs matlib.dll
	$(MCS) $< -o:$@ -r:$(call commalist,$(filter-out $<,$^))
main-a2.exe: main-a2.cs matlib.dll
	$(MCS) $< -o:$@ -r:$(call commalist,$(filter-out $<,$^))

SRC=\
$(HOME)/PPNM/matlib/matrix/vector.cs\
$(HOME)/PPNM/matlib/matrix/matrix.cs\
$(HOME)/PPNM/matlib/jacobi/jacobi.cs
matlib.dll: $(SRC)
	$(MCS) $^ /t:library /out:$$(pwd)/$@

A.box.psi.svg: out.data Makefile
	echo '\
	set term svg enhanced size 640,480 background "white" font "Arial,18";\
	set out "$@";\
	set key left;\
	set title "Quantum particle in a box: eigenfunctions";\
	set xlabel "x";\
	set ylabel "Î¨_n(x)";\
	plot \
	 "$<" index 1 with lines notitle\
	,sqrt(2) with lines notitle\
	,-sqrt(2) with lines notitle\
	'| gnuplot

A.box.e.svg: out.data Makefile
	echo '\
	set term svg enhanced size 640,480 background "white" font "Arial,18";\
	set out "$@";\
	set key left;\
	set tics out;\
	set title "Quantum particle in a box: eigenvalues";\
	set xlabel "n";\
	set ylabel "âˆšE_n";\
	plot \
	 "$<" index 0 u 1:(sqrt($$2)) with lines title "calculated"\
	,"$<" index 0 u 1:(sqrt($$3)) with lines title "exact"\
	'| gnuplot

out.data:main-a2.exe
	$(MONO) $< > $@

clean:
	$(RM) *.dll *.exe out.* *.log *.svg A*

#%.dll: %.cs ; $(MCS) -t:library $*.cs -o:$*.dll *log