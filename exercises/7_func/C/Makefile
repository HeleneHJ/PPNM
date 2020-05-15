# all: out.txt C.svg

C.svg: C.gpi out.txt
	gnuplot $<

out.txt : main.exe 
	mono $< > out.txt

main.exe: main.cs matlib.dll
	mcs -out:$@ -reference:matlib.dll $<

LIBDIR = ../../../matlib/integration
matlib.dll: $(LIBDIR)/quado8.cs
	mcs -target:library -out:$@ $^

.PHONEY:clean
clean:
	rm -f *.dll *.exe out.txt 

C.gpi: Makefile
	echo 'set term svg font ",18" background rgb "white"' > $@
	echo 'set title "Quantum Oscillator' >> $@
	echo 'set key bottom right' >> $@
	echo 'set xlabel "Variational Parameter α"' >> $@
	echo 'set ylabel "Energy E(α)"' >> $@
	echo 'set grid' >> $@
	echo 'set out "C.svg"' >> $@
	echo 'plot [0.1:3][0:1]\'  >>$@
	echo ' "out.txt" with lines title "E(α)"\' >> $@