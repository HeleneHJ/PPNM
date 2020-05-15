default: Erf.svg

Erf.svg: erf.gpi out.erf.txt out.table.txt
	gnuplot $<

out.erf.txt: main.exe
	mono $< > $@ 2>log

main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll: erf.cs
	mcs $< -target:library -out:$@

clean:
	rm -rf *.exe *.dll *.svg out* log* erf.gpi

erf.gpi: Makefile
	echo 'set term svg font ",18" background rgb "white"' > $@
	echo 'set title "Error-Function vs Tabulated Values'  >> $@
	echo 'set key bottom right'  >> $@
	echo 'set tics out'  >> $@
	echo 'set grid'  >> $@
	echo 'set xzeroaxis'  >> $@
	echo 'set yzeroaxis'  >> $@
	echo 'set xlabel "x"'  >> $@
	echo 'set ylabel "Erf(x)"'  >> $@
	echo 'set out "Erf.svg"'  >> $@
	echo 'plot [][-1.5:1.5] \' >>$@
	echo ' "out.erf.txt" with lines title "error function"\' >> $@
	echo ',"out.table.txt" with points pt 7 ps 0.7  title "tabulated values"\' >> $@

out.table.txt: Makefile # Values from Wikipedia
	echo '0.0 0.0' >$@
	echo '0.3 0.328626759' >>$@
	echo '0.6 0.603856091' >>$@
	echo '0.9 0.796908212' >> $@
	echo '1.3 0.934007945' >> $@