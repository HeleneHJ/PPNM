LIBDIR=$(HOME)/PPNM/matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/qr/qr.cs

all:Out.txt
Out.txt:main.exe
	mono $< >$@ 2>Log

main.exe:main.cs roots.dll matlib.dll
	mcs $< -r:$(call clist,$(filter %.dll,$^))

matlib.dll:$(LIBSRC)
	mcs $^ -target:library -out:$@

roots.dll:roots.cs matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

clean:
	$(RM) *.exe *.dll [Oo]out* [Ll]og*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))