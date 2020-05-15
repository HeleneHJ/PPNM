DATA = out.data
PLOT = Sin.svg
all: $(PLOT)
$(DATA): main.exe
	mono $< 1> $@ 2> Log
	
main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll: driver.cs rkstep23.cs vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe out* *.svg [Ll]og*

$(PLOT): $(DATA) Makefile
	echo '\
	set term svg background rgb "white";\
	set out "$(PLOT)";\
	set key out;\
	set tics out;\
	set title "dy_0/dx=y_1, dy_1/dx=-y_0";\
	set xlabel "x";\
	set ylabel "y";\
	plot \
	 "$(DATA)" using 1:2 with points pt 7 ps 0.5 title "y_0" \
	,"$(DATA)" using 1:3 with points pt 5 ps 0.5 title "y_1" \
	,sin(x) title "sin"\
	,cos(x) title "cos"\
	,"$(DATA)" using ($$1):(0) w p pt 7 ps 0.1 not \
	'|gnuplot
	