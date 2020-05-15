ECHO=/bin/echo
default: Plots.png log

R1 = 2
R2 = 3
R3 = 4
R4 = 5
R5 = 10
data log: main.exe Makefile
	cat /dev/null | tee data log
	for R in $(R1) $(R2) $(R3) $(R4) $(R5); do \
	mono $< $$R 1>>data 2>>log; \
	echo | tee --append data log; \
	echo | tee --append data log; \
	done

WIDTH = 5
Plots.png: data Makefile
	$(ECHO) '\
	set term $(subst .,,$(suffix $@)); \
	set out "$@"; \
	set multiplot; \
	set title "Hydrogen s-wave shooting to $$F_\epsilon(r_\mathrm{max})=0$$"; \
	set tics out; \
	set xtics 2; \
	set mxtics 1; \
	set width $(WIDTH); \
	set xlabel "$$r$$ [$$a_\mathrm{Bohr}$$]"; \
	set ylabel "$$F_\epsilon(r)$$"; \
	plot \
	 "$<" index 1 with lines title "$$r_\mathrm{max}$$=$(R1)" \
	,"$<" index 3 with lines title "$$r_\mathrm{max}$$=$(R2)" \
	,"$<" index 5 with lines title "$$r_\mathrm{max}$$=$(R3)" \
	,"$<" index 9 with lines title "$$r_\mathrm{max}$$=$(R5)" \
	,"$<" index 9 using 1:3 with lines linetype 2 title "exact"; \
	set origin 0,-$(WIDTH)-1; \
	set mytics 0.05; \
	set title "Obtained energy as function of $$r_\mathrm{max}$$"; \
	set xlabel "$$r_\mathrm{max}$$ [$$a_\mathrm{Bohr}$$]"; \
	set ylabel "$$\epsilon$$ [Hatree]"; \
	plot [$(R1)-1:$(R5)+1][-0.6:0]\
	 "$<" index 0 with points pointtype 1 color red notitle \
	,"$<" index 2 with points pointtype 1 color red notitle \
	,"$<" index 4 with points pointtype 1 color red notitle \
	,"$<" index 6 with points pointtype 1 color red notitle \
	,"$<" index 8 with points pointtype 1 color red notitle \
	,-0.5 with lines linetype 2 title "exact"\
	'| tee log.gpi | pyxplot

main.exe: main.cs hydrogen.cs matlib.dll
	mcs $(filter %.cs,$^) -r:$(lastword $^)

LIBDIR=$(HOME)/PPNM/matlib
SRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/ode/driver.cs\
	$(LIBDIR)/ode/rkstep23.cs\
	$(LIBDIR)/qr/qr.cs\
	$(LIBDIR)/roots/bak/jacobian.cs\
	$(LIBDIR)/roots/bak/newton.cs

matlib.dll: $(SRC)
	mcs $^ -t:library -out:$@

.PHONEY:clean
clean:
	$(RM) log* data *.exe *.dll *.png