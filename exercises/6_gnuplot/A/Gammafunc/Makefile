default: Gamma.svg
Gamma.svg: gamma.gpi out.gamma.txt out.table.txt
	gnuplot $<

out.gamma.txt: main.exe
	mono $< > $@ 2>log

main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll: gamma.cs
	mcs $< -target:library -out:$@

clean:
	rm -rf *.exe *.dll *.svg out* log* gamma.gpi

gamma.gpi: Makefile
	echo 'set term svg font ",18" background rgb "white"' > $@
	echo 'set title "Gamma-Function vs Tabulated Values'  >> $@
	echo 'set key bottom right'  >> $@
	echo 'set tics out'  >> $@
	echo 'set grid'  >> $@
	echo 'set xzeroaxis'  >> $@
	echo 'set yzeroaxis'  >> $@
	echo 'set xlabel "x"'  >> $@
	echo 'set ylabel "Γ(x)"'  >> $@
	echo 'set out "Gamma.svg"'  >> $@
	echo 'plot [][-5:5] \' >>$@
	echo ' "out.gamma.txt" with lines title "gamma function"\' >> $@
	echo ',"out.table.txt" with points pt 7 ps 0.7 title "tabulated values"\' >> $@

PI := 3.14159265359
out.table.txt: Makefile
	cat /dev/null > $@
	echo "-2.5 $$(echo '-8/15*sqrt($(PI))' | bc -l)" >>$@
	echo "-1.5 $$(echo '4/3*sqrt($(PI))' | bc -l)" >>$@
	echo "-0.5 $$(echo '-2*sqrt($(PI))' | bc -l)" >>$@
	echo "0.5 $$(echo 'sqrt($(PI))' | bc -l)" >>$@
	echo '1.0 1.0' >>$@
	echo '2.0 1.0' >>$@
	echo '3.0 2.0' >>$@
	echo "3.5 $$(echo '15/8*sqrt($(PI))' | bc -l)" >>$@
	echo '4.0 6.0' >> $@
	echo '5.0 24.0' >> $@

test:
	echo $(PI)