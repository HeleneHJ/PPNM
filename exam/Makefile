all: out.txt sinRe.svg sinIm.svg cosRe.svg cosIm.svg

out.txt: main.exe
	mono $< 1> $@ 2> log
	
main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../matlib
matlib.dll: driver.cs rkstep23.cs cvector.cs cmath.cs $(LIBDIR)/matrix/vector.cs $(LIBDIR)/complex/complex.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe out* 


sinRe.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16";\
	set out "sinRe.svg";\
	set view ,300;\
	set title "|sin(z)|";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "Re(sin(z))" rotate parallel;\
	set cntrlabel onecolor;\
	set linetype 1 linecolor rgb "black";\
	set cntrparam levels incremental 0.0,0.25,50;\
	set palette rgb 33,13,10;\
	splot "out.txt" using 1:2:3 with lines notitle;\
	'|gnuplot

sinIm.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16";\
	set out "sinIm.svg";\
	set view ,300;\
	set title "|sin(z)|";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "Im(sin(z))" rotate parallel;\
	set cntrlabel onecolor;\
	set linetype 1 linecolor rgb "black";\
	set cntrparam levels incremental 0.0,0.25,50;\
	set palette rgb 33,13,10;\
	splot "out.txt" using 1:2:4 with lines notitle;\
	'|gnuplot

cosRe.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16";\
	set out "cosRe.svg";\
	set view ,300;\
	set title "|cos(z)|";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "Re(cos(z))" rotate parallel;\
	set cntrlabel onecolor;\
	set linetype 1 linecolor rgb "black";\
	set cntrparam levels incremental 0.0,0.25,50;\
	set palette rgb 33,13,10;\
	splot "out.txt" using 1:2:5 with lines notitle;\
	'|gnuplot

cosIm.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16";\
	set out "cosIm.svg";\
	set view ,300;\
	set title "|cos(z)|";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "Im(cos(z))" rotate parallel;\
	set cntrlabel onecolor;\
	set linetype 1 linecolor rgb "black";\
	set cntrparam levels incremental 0.0,0.25,50;\
	set palette rgb 33,13,10;\
	splot "out.txt" using 1:2:6 with lines notitle;\
	'|gnuplot

#set contour both;\

# $(PLOT): $(DATA) Makefile
# 	echo '\
# 	set term svg background rgb "white";\
# 	set out "$(PLOT)";\
# 	set key out;\
# 	set tics out;\
# 	set xlabel "x";\
# 	plot \
# 	 "$(DATA)" using 1:2 with points pt 7 ps 0.5 title "y_0" \
# 	,"$(DATA)" using 1:3 with points pt 5 ps 0.5 title "y_1" \
#  	,sin(x) title "sin"\
# 	,cos(x) title "cos"\
# 	'|gnuplot
	