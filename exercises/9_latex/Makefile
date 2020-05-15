all: texfile.pdf

texfile.pdf: texfile.tex Fresnel.tex
	pdflatex $<
	pdflatex $<

main.exe: main.cs matlib.dll
	mcs -out:$@ -reference:matlib.dll $<

Fresnel.tex: Fresnel.gpi out.txt out.c.txt
	gnuplot $<

# fresnel.svg: fresnel.gpi out.txt out.c.txt
# 	gnuplot $<

out.txt : main.exe 
	mono $< > out.txt

out.c.txt: cfresnel.exe
	mono $< > $@

cfresnel.exe: cfresnel.cs matlib.dll
	mcs -out:$@ -reference:matlib.dll cfresnel.cs


LIBDIR = $(HOME)/PPNM/matlib/integration
matlib.dll: $(LIBDIR)/quado8.cs
	mcs -target:library -out:$@ $^

.PHONEY:clean
clean:
	rm -f *.dll *.exe 

# fresnel.gpi: Makefile
# 	echo 'set term svg background rgb "white"' > $@
# 	echo 'set tics font ",20"' >> $@
# 	echo 'set title "The Fresnel Integrals" font ",20"' >> $@
# 	echo 'set key bottom right' >> $@
# 	echo 'set xlabel "x" font ",20"' >> $@
# 	echo 'set ylabel "f(x)" font ",20"' >> $@
# 	echo 'set grid' >> $@
# 	echo 'set out "fresnel.svg"' >> $@
# 	echo 'plot [0:10][0:1]\'  >>$@
# 	echo ' "out.txt" with lines linetype 2 title "S(x)" \' >> $@
# 	echo ' ,"out.c.txt" with lines linetype 4 title "C(x)"\' >> $@