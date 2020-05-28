all: out.txt plot.svg
# 	cat out.txt

plot.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font ",14" ;\
	set out "plot.svg" ;\
	set xlabel "x" ;\
	set ylabel "y" ;\
	set size ratio -1 ;\
	set title "3 Body figure 8 motion for m = 1, G = 1, and tb = 100" ;\
	set yrange [-0.8:0.8] ;\
	set grid ;\
	plot "out.txt" u 2:3 with lines dt 3 notitle \
	,"out.txt" u 4:5 with lines dt 2 notitle \
	,"out.txt" u 6:7 with lines dt 1 notitle \
	'|gnuplot

out.txt: main.exe
	mono $< 1> out.txt

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll -out:$@ $<

LIBDIR = $(HOME)/PPNM/matlib
matlib.dll: $(LIBDIR)/matrix/vector.cs rkstep23.cs driver23.cs
	mcs -target:library -out:$@ $^

.PHONY:clean
clean:
	rm -f *.exe out.*.txt *.svg 