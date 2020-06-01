all: B.svg

B.svg: B.gpi data.txt
	gnuplot $<

data.txt: main.exe
	mono $< 1> $@ 2> out.txt

DLLS = matlib.dll roots.dll
main.exe:	main.cs hydrogen.cs $(DLLS)
	mcs main.cs hydrogen.cs -reference:$(call clist,$(DLLS))

SRC := ../../../matlib/roots/bak
roots.dll:$(SRC)/jacobian.cs $(SRC)/newton.cs matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

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

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))
