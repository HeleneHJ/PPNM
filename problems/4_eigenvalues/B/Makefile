MCS = mcs -optimize+ -platform:arm
MONO = mono -O=all #-O=all,-shared #--optimize=unsafe,loop,inline #--gc=sgen --llvm --optimize=all

comma:=,
empty:=
space:=$(empty) $(empty)
commalist = $(subst $(space),$(comma),$(1))

all: out.B1.txt out.B2.txt out.B3.txt B1.svg B2.svg B3.svg #B.compare-times.svg B.check-energies.svg B.compare-rotations.svg

out.B1.txt: main1.exe Makefile
	mono $^ > $@

out.B2.txt: main2.exe Makefile
	mono $^ > $@

out.B3.txt: main3.exe Makefile
	mono $^ > $@

B1.svg: out.B1.txt Makefile
	echo '\
	set term svg size 640,480 background "white" font "Arial,14";\
	set out "$@";\
	set key bottom right;\
	 	b=1; a=30; c=3;\
	 	f(x)=b+(x/a)**c;\
	 	fit f(x) "out.B1.txt" via a,b;\
	set title "Matrix Diagonalization Times: Cyclic Method" font ",18";\
	set xlabel "Matrix Size n";\
	set ylabel "Diagonalization Time [ms]";\
	plot [][1:1000] \
	"out.B1.txt" index 0 pointtype 7 notitle \
	,x>250?0.1/0:f(x) title sprintf("Best fit: (n/%.f)^{%.2f}%.3f",a,c,b) \
	'| gnuplot
# 	set log y;\

B2.svg: out.B2.txt Makefile
	echo '\
	set term svg size 640,480 background "white" font "Arial,14";\
	set out "$@";\
	set key bottom right;\
	set title "Matrix Diagonalization Times: cyclic, 1st lowest, 1st highest" font ",18";\
	set xlabel "Matrix Size n";\
	set ylabel "Number of Operations";\
	set log y;\
	plot\
	"$<" index 0 u 1:2 with lines title "cyclic" \
	,"$<" index 0 u 1:3 with lines title "lowest" \
	,"$<" index 0 u 1:4 with lines title "highest" \
	'| gnuplot

B3.svg: out.B3.txt Makefile
	echo '\
	set term svg size 640,480 background "white" font "Arial,14";\
	set out "$@";\
	set key bottom right;\
	set title "Matrix Diagonalization Times: cyclic, full lowest, full highest" font ",18";\
	set xlabel "Matrix Size n";\
	set ylabel "Number of Operations";\
	set log y;\
	plot\
	"$<" index 0 u 1:2 with lines title "cyclic" \
	,"$<" index 0 u 1:3 with lines title "lowest" \
	,"$<" index 0 u 1:4 with lines title "highest" \
	'| gnuplot

main1.exe: main1.cs matlib.dll #jacobi.dll matrix.dll
	mcs -reference:matlib.dll $<

main2.exe: main2.cs matlib.dll #jacobi.dll matrix.dll
	mcs -reference:matlib.dll $<

main3.exe: main3.cs matlib.dll #jacobi.dll matrix.dll
	mcs -reference:matlib.dll $<


LIBDIR=../../../matlib
matlib.dll: jacobi.cs highest.cs lowest.cs $(LIBDIR)/matrix/matrix.cs $(LIBDIR)/matrix/vector.cs
	$(MCS) $^ -t:library -out:$$(pwd)/$@
	#mcs -target:library -out:math.dll $^

clean: ; $(RM) *.exe out.* log* #*.dll