MCS = mcs -optimize+ -platform:arm
MONO = mono -O=all
#-O=all,-shared #--optimize=unsafe,loop,inline #--gc=sgen --llvm --optimize=all

comma:=,
empty:=
space:=$(empty) $(empty)
commalist = $(subst $(space),$(comma),$(1))

all: A1.txt A.eigenfuncs.svg A.eigenvals.svg

A1.txt: main1.exe
	$(MONO) $< > $@

main1.exe: main1.cs matlib.dll
	$(MCS) $< -o:$@ -r:$(call commalist,$(filter-out $<,$^))

main2.exe: main2.cs matlib.dll
	$(MCS) $< -o:$@ -r:$(call commalist,$(filter-out $<,$^))

SRC=\
../../../matlib/matrix/vector.cs\
../../../matlib/matrix/matrix.cs\
../../../matlib/jacobi/jacobi.cs
matlib.dll: $(SRC)
	$(MCS) $^ /t:library /out:$$(pwd)/$@

A.eigenfuncs.svg: out.txt Makefile
	echo '\
	set term svg enhanced size 640,480 background "white" font "Arial,18";\
	set out "$@";\
	set key left;\
	set title "Quantum Particle in a Box: Eigenfunctions";\
	set xlabel "x";\
	set ylabel "Ψ_n(x)";\
	plot \
	 "$<" index 1 with lines notitle\
	,sqrt(2) with lines notitle\
	,-sqrt(2) with lines notitle\
	'| gnuplot

A.eigenvals.svg: out.txt Makefile
	echo '\
	set term svg enhanced size 640,480 background "white" font "Arial,18";\
	set out "$@";\
	set key left;\
	set tics out;\
	set title "Quantum Particle in a Box: Eigenvalues";\
	set xlabel "n";\
	set ylabel "√E_n";\
	plot[0:30][] \
	 "$<" index 0 u 1:(sqrt($$2)) with lines title "calculated"\
	,"$<" index 0 u 1:(sqrt($$3)) with lines title "exact"\
	'| gnuplot

out.txt: main2.exe
	$(MONO) $< > $@

clean:
	$(RM) *.dll *.exe out.* *.log *.svg A*
