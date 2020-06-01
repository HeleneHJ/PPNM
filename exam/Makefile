all: plot.svg

plot.svg: plot.gpi out.txt
	gnuplot $<

out.txt: main.exe
	mono $< 1> $@ 

main.exe: main.cs matlib.dll
	mcs main.cs hydrogen.cs

LIBDIR=../../../matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/ode/driver.cs\
	$(LIBDIR)/ode/rkstep23.cs\
	$(LIBDIR)/qr/qr.cs\
	
matlib.dll: $(LIBSRC)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* *.dll