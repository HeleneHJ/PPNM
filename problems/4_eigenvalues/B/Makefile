MCS = mcs -optimize+ -platform:arm
MONO = mono -O=all #-O=all,-shared #--optimize=unsafe,loop,inline #--gc=sgen --llvm --optimize=all

comma:=,
empty:=
space:=$(empty) $(empty)
commalist = $(subst $(space),$(comma),$(1))

all: B.out.txt B.compare-times.svg B.check-energies.svg B.compare-rotations.svg

TC=out.t.cyclic
EC=out.e.cyclic
T1=out.t.1value
E1=out.e.1value
TV=out.t.values
EV=out.e.values

B.compare-rotations.svg:$(EC) $(E1) $(EV) Makefile
	echo '\
	set term svg enhanced size 640,480 background "white" font "Arial,18";\
	set out "$@";\
	set title "Rotations: cyclic vs 1value";\
	set xlabel "matrix size n";\
	set ylabel "number of rotations";\
	set key left;\
	set log x;\
	set log y;\
	plot [][]\
	 "$(EC)" using 1:3 with linespoints pt 5 title "cyclic" \
	,"$(E1)" using 1:3 with linespoints pt 7 title "1value" \
	,"$(EV)" using 1:3 with linespoints pt 9 title "1by1" \
	'| gnuplot

B.check-energies.svg: $(EC) $(E1) Makefile
	echo '\
	set term svg enhanced size 640,480 background "white" font "Arial,18";\
	set out "$@";\
	set title "Lowest eigenvalue: cyclic vs 1value";\
	set xlabel "matrix size n";\
	set ylabel "e_0";\
	plot [:][]\
	 "$(EC)" with linespoints pt 1 title "cyclic" \
	,"$(E1)" with linespoints pt 2 title "1value" \
	'| gnuplot

B.out.txt: main.exe Makefile
	$(MONO) $< 7 >$@

B.compare-times.svg: out.t.cyclic out.t.1value out.t.values Makefile
	echo '\
	set term svg size 640,480 background "white" font "Arial,18";\
	set out "$@";\
	set key top left;\
	set log x;\
	set log y;\
	set title "matrix diagonalization times: cyclic vs 1value vs 1by1";\
	set xlabel "matrix size n";\
	set ylabel "diagonalization time t, sec";\
	bc=1; ac=90; cc=3;\
	bv=1; av=90; cv=3;\
	b1=1; a1=90; c1=3;\
	fc(x)=bc+(x/ac)**cc;\
	f1(x)=b1+(x/a1)**c1;\
	fv(x)=bv+(x/av)**cv;\
	fit fc(x) "out.t.cyclic" via ac,bc;\
	fit f1(x) "out.t.1value" via a1,b1;\
	fit fv(x) "out.t.values" via av,bv;\
	plot [:1000][:]\
	 "out.t.values" pointtype 9 notitle \
	,"out.t.cyclic" pointtype 5 notitle \
	,"out.t.1value" pointtype 7 notitle \
	,x>80?1/0:fv(x) t sprintf("1by1: (n/%.f)^{%.2f}+%.3f",av,cv,bv) \
	,x>200?1/0:fc(x) title sprintf("cyclic: (n/%.f)^{%.2f}+%.3f",ac,cc,bc) \
	,x<200?1/0:f1(x) t sprintf("1value: (n/%.f)^{%.2f}+%.3f",a1,c1,b1) \
	'| gnuplot

$(TC) $(EC): main.exe #Makefile
	cat /dev/null | tee $(TC) $(EC)
	for N in `seq 73 5 93`; do \
	echo "N=$$N";\
	\time -ao $(TC) -f "$$N %U" $(MONO) main.exe $$N cyclic >>$(EC); \
	done
$(E1): main.exe #Makefile
	cat /dev/null | tee $(E1)
	for N in `seq 73 5 93`; do \
	echo "N=$$N";\
	$(MONO) main.exe $$N values 1 >>$(E1); \
	done
$(T1): main.exe #Makefile
	cat /dev/null | tee $(T1)
	for N in `seq 400 25 500`; do \
	echo "N=$$N";\
	\time -ao $(T1) -f "$$N %U" $(MONO) main.exe $$N values; \
	done
$(TV) $(EV): main.exe #Makefile
	cat /dev/null | tee $(TV) $(EV)
	for N in `seq 23 5 53`; do \
	echo "N=$$N";\
	\time -ao $(TV) -f "$$N %U" $(MONO) main.exe $$N values $$N >>$(EV); \
	done

main.exe: main.cs jacobi.dll matrix.dll
	$(MCS) $< -o:$@ -r:$(call commalist,$(filter-out $<,$^))

jacobi.dll: jacobi.cs values.cs matrix.dll
	mcs $(filter %.cs,$^) -t:library -r:$(filter %.dll,$^) -o:$@

LIBDIR=$(HOME)/PPNM/matlib/
matrix.dll: $(LIBDIR)/matrix/matrix.cs $(LIBDIR)/matrix/vector.cs
	$(MCS) $^ -t:library -out:$$(pwd)/$@

clean: ; $(RM) *.dll *.exe out.* log* *.svg B*

#%.dll: %.cs ; $(MCS) -t:library $*.cs -o:$*.dll *log *.log