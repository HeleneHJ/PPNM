linearspline.svg: linearspline.gpi out.txt
	gnuplot $<

matlib.dll: lspline.cs
	mcs $< -target:library -out:$@

main.exe: main.cs matlib.dll 
	mcs $< -reference:$(lastword $^)

out.txt: main.exe
	mono $< >$@

ECHO=/bin/echo
linearspline.gpi: out.txt Makefile
	$(ECHO) '\
	set term svg font "Arial,15" size 1024,600;\
	set out "linearspline.svg";\
	set multiplot layout 2,2 title "Linear Spline and Integral of sin(x)" font ",18";\
	set key bottom left;\
	set xtics 1;\
	set grid;\
	set rmargin 0;\
	plot [][-1.5:1.5]\
	"out.txt" index 0 with points pointtype 7 title "points"\
	,"out.txt" index 1 u 1:2 with lines title "exact"\
	,"out.txt" index 1 u 1:3 with lines title "lspline";\
	set key bottom center;\
	set ytics 1;\
	set rmargin;\
	plot [][-0.5:2.5]\
	"out.txt" index 2 u 1:2 with lines title "exact integral"\
	,"out.txt" index 2 u 1:3 with lines title "spline integral";\
	unset multiplot;\
	'| gnuplot

clean:
	rm -f *.exe *.dll *.gpi