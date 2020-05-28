all: out.txt plot.svg
# 	cat out.txt

plot.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font ",14" ;\
	set out "plot.svg" ;\
	set xlabel "x" ;\
	set ylabel "y" ;\
	set size ratio -1 ;\
	set title "Special-case Solution to the Three Body Problem (Figure-8)" font ",18" ;\
	set yrange [-0.8:0.8] ;\
	set grid ;\
	plot "out.txt" u 2:3 with lines dt 3 title "m_1" \
	,"out.txt" u 4:5 with lines dt 2 title "m_2" \
	,"out.txt" u 6:7 with lines dt 1 title "m_3" \
	'|gnuplot
# all three masses are plotted, but only one can be seen because they all travel on the same path 

out.txt: main.exe
	mono $< 1> out.txt 2> steps.txt

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll -out:$@ $<

LIBDIR = ../../../matlib
matlib.dll: $(LIBDIR)/matrix/vector.cs rkstep23.cs driver23.cs
	mcs -target:library -out:$@ $^

.PHONY:clean
clean:
	rm -f *.exe out.*.txt *.svg 