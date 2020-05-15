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
	echo 'set term svg font ",18" background rgb "white"' > $@
	echo 'set title "Logarithm of Gamma-Function ln Γ(x)'  >> $@
	echo 'set key bottom right'  >> $@
	echo 'set tics out'  >> $@
	echo 'set grid'  >> $@
	echo 'set xzeroaxis'  >> $@
	echo 'set yzeroaxis'  >> $@
	echo 'set xlabel "x"'  >> $@
	echo 'set ylabel "ln Γ(x)"'  >> $@
	echo 'set log x'  >> $@
	echo 'set log y'  >> $@
	echo 'set out "LnGamma.svg"'  >> $@
	echo 'plot [][] \' >>$@
	echo ' "out.lngamma.txt" with lines title "ln Γ(x)"\' >> $@
# 	echo 'ls(z)=z*log(z)-z-0.5*log(z/2*pi)' >>$@  # Stirling's Formula
# 	echo ' "out.lngamma.txt" with lines title "lnΓ(x)"\' >> $@
# 	echo ',"out.lngamma.txt" using ($$1):(ls($$1))\' >> $@
# 	echo '  with lines title "Stirling Formula"' >> $@

PI := 3.14159265359
test:
	echo $(PI)