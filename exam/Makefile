all: out.txt sinRe.svg sinIm.svg cosRe.svg cosIm.svg sinabs.svg cosabs.svg#plot.svg #plot.svg plot2.svg  

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
	set view ,20;\
	set title "Re[sin(z)]";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "Re[sin(z)]" rotate parallel;\
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
	set view ,20;\
	set title "Im[sin(z)]";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "Im[sin(z)]" rotate parallel;\
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
	set view ,20;\
	set title "Re[cos(z)]";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "Re[cos(z)]" rotate parallel;\
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
	set view ,20;\
	set title "Im[cos(z)]";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "Im[cos(z)]" rotate parallel;\
	set cntrlabel onecolor;\
	set linetype 1 linecolor rgb "black";\
	set cntrparam levels incremental 0.0,0.25,50;\
	set palette rgb 33,13,10;\
	splot "out.txt" using 1:2:6 with lines notitle;\
	'|gnuplot


sinabs.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16";\
	set out "sinabs.svg";\
	set view ,20;\
	set title "|sin(z)|";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "|sin(z)|" rotate parallel;\
	set cntrlabel onecolor;\
	set linetype 1 linecolor rgb "black";\
	set cntrparam levels incremental 0.0,0.25,50;\
	set palette rgb 33,13,10;\
	splot "out.txt" using 1:2:7 with lines notitle;\
	'|gnuplot

cosabs.svg: out.txt Makefile
	echo '\
	set term svg background rgb "white" font "Arial,16";\
	set out "cosabs.svg";\
	set view ,20;\
	set title "|cos(z)|";\
	set hidden3d;\
	set pm3d;\
	set dgrid3d;\
	set xlabel "Re(z)";\
	set ylabel "Im(z)";\
	set zlabel "|cos(z)|" rotate parallel;\
	set cntrlabel onecolor;\
	set linetype 1 linecolor rgb "black";\
	set cntrparam levels incremental 0.0,0.25,50;\
	set palette rgb 33,13,10;\
	splot "out.txt" using 1:2:8 with lines notitle;\
	'|gnuplot


#set contour both;\

# plot.svg: out.txt Makefile
# 	echo '\
# 	set term svg background rgb "white";\
# 	set out "plot.svg";\
# 	set title "Re";\
# 	set key out;\
# 	set tics out;\
# 	set xlabel "x";\
# 	plot \
# 	 "out.txt" index 0 using 1:2 with points pt 7 ps 0.5 title "y_0" \
# 	,"out.txt" index 0 using 1:3 with points pt 5 ps 0.5 title "y_1" \
#  	,sin(x) title "sin"\
# 	,cos(x) title "cos"\
# 	'|gnuplot
	
# plot2.svg: out.txt Makefile
# 	echo '\
# 	set term svg background rgb "white";\
# 	set out "plot2.svg";\
# 	set title "Im";\
# 	set key out;\
# 	set tics out;\
# 	set xlabel "x";\
# 	plot \
# 	 "out.txt" index 1 using 1:2 with points pt 7 ps 0.5 title "y_0" \
# 	,"out.txt" index 1 using 1:3 with points pt 5 ps 0.5 title "y_1" \
#  	,sin(x) title "sin"\
# 	,cos(x) title "cos"\
# 	'|gnuplot
	