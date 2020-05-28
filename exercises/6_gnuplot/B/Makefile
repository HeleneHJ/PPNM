default: LnGamma.svg

LnGamma.svg: lngamma.gpi out.lngamma.txt
	gnuplot $<

out.lngamma.txt: main.exe
	mono $< > $@ 2>log

main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll: lngamma.cs
	mcs $< -target:library -out:$@

clean:
	rm -rf *.exe *.dll *.svg out* log* lngamma.gpi

lngamma.gpi: Makefile
	echo 'set term svg background rgb "white" font ",14" ' > $@
	echo 'set title "Logarithm of gamma-function lngamma(x)'  >> $@
	echo 'set key bottom right'  >> $@
	echo 'set tics out'  >> $@
	echo 'set grid'  >> $@
	echo 'set xzeroaxis'  >> $@
	echo 'set yzeroaxis'  >> $@
	echo 'set xlabel "x"'  >> $@
	echo 'set ylabel "y"'  >> $@
	echo 'set log x'  >> $@
	echo 'set log y'  >> $@
	echo 'set out "LnGamma.svg"'  >> $@
	echo 'plot [][] \' >>$@
	echo ' "out.lngamma.txt" with lines title "lngamma(x)"\' >> $@
