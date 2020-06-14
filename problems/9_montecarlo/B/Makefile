all: out.txt plot.svg

plot.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font ",14" ;\
	set out "plot.svg" ;\
	set tics out ;\
	set key top right ;\
	set ylabel "Absolute Error" ;\
	set xlabel "N" ;\
	set grid ;\
	plot "out.txt" u 1:4 w l lw 2 t "Actual Error"\
	,"out.txt" u 1:3 w l lw 3 t "Estimated Error"\
	,"out.txt" u 1:2 w l lw 1 lc 8 t "O(1/sqrt(N))"\
	'|gnuplot

# linecolor: 1=purple, 2=green, 3=blue, 4=orange, 5=yellow, 6=dark blue, 7=red, 8=black

out.txt: main.exe
	mono $< 1>out.txt

main.exe: main.cs montecarlo.cs matlib.dll
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
	$(RM) *.exe *.dll out* *.svg