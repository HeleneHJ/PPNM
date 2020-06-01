all: outB1.txt SIRmodel1.svg outB2.txt SIRmodel2.svg outB3.txt SIRmodel3.svg outB4.txt SIRmodel4.svg outB5.txt SIRmodel5.svg comments.txt

outB1.txt: main.exe
	mono $< 1> outB1.txt 2> comments.txt
outB2.txt: main.exe
	mono $< 1> outB2.txt 
outB3.txt: main.exe
	mono $< 1> outB3.txt 
outB4.txt: main.exe
	mono $< 1> outB4.txt 
outB5.txt: main.exe
	mono $< 1> outB5.txt 

main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix/vector.cs
matlib.dll: $(SRC) rkstep23.cs driver23.cs rkstep45.cs driver45.cs
	mcs -target:library -out:$@ $^

.PHONY:clean
clean:
	rm -f *.exe out.*.txt *.svg matlib.dll

SIRmodel1.svg: outB1.txt Makefile
	echo '\
	set term svg background rgb "white" font ",14";\
	set out "SIRmodel1.svg";\
	set key out;\
	set tics out;\
	set title "SIR-model: Corona Virus in Denmark, 2020 (T_c=0.8)";\
	set xlabel "Days";\
	set ylabel "Number of People";\
	plot[0:250][] "outB1.txt" u 1:2 with lines title "S" \
 	, "outB1.txt" u 1:3 with lines title "I" \
 	, "outB1.txt" u 1:4 with lines title "R" \
	'|gnuplot

SIRmodel2.svg: outB2.txt Makefile
	echo '\
	set term svg background rgb "white" font ",14";\
	set out "SIRmodel2.svg";\
	set key out;\
	set tics out;\
	set title "SIR-model: Corona Virus in Denmark, 2020 (T_c=2)";\
	set xlabel "Days";\
	set ylabel "Number of People";\
	plot[0:250][] "outB2.txt" u 1:2 with lines title "S" \
 	, "outB2.txt" u 1:3 with lines title "I" \
 	, "outB2.txt" u 1:4 with lines title "R" \
	'|gnuplot

SIRmodel3.svg: outB3.txt Makefile
	echo '\
	set term svg background rgb "white" font ",14";\
	set out "SIRmodel3.svg";\
	set key out;\
	set tics out;\
	set title "SIR-model: Corona Virus in Denmark, 2020 (T_c=5)";\
	set xlabel "Days";\
	set ylabel "Number of People";\
	plot[0:250][] "outB3.txt" u 1:2 with lines title "S" \
 	, "outB3.txt" u 1:3 with lines title "I" \
 	, "outB3.txt" u 1:4 with lines title "R" \
	'|gnuplot

SIRmodel4.svg: outB4.txt Makefile
	echo '\
	set term svg background rgb "white" font ",14";\
	set out "SIRmodel4.svg";\
	set key out;\
	set tics out;\
	set title "SIR-model: Corona Virus in Denmark, 2020 (T_c=8)";\
	set xlabel "Days";\
	set ylabel "Number of People";\
	plot[0:250][] "outB4.txt" u 1:2 with lines title "S" \
 	, "outB4.txt" u 1:3 with lines title "I" \
 	, "outB4.txt" u 1:4 with lines title "R" \
	'|gnuplot

SIRmodel5.svg: outB5.txt Makefile
	echo '\
	set term svg background rgb "white" font ",14";\
	set out "SIRmodel5.svg";\
	set key out;\
	set tics out;\
	set title "SIR-model: Corona Virus in Denmark, 2020 (T_c=13)";\
	set xlabel "Days";\
	set ylabel "Number of People";\
	plot[0:250][] "outB5.txt" u 1:2 with lines title "S" \
 	, "outB5.txt" u 1:3 with lines title "I" \
 	, "outB5.txt" u 1:4 with lines title "R" \
	'|gnuplot