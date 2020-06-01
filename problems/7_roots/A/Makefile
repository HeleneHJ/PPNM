LIBDIR=../../../matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/qr/qr.cs\
	$(LIBDIR)/roots/bak/newton.cs\
	$(LIBDIR)/roots/bak/jacobian.cs\
	$(LIBDIR)/roots/bak/broyden.cs\

all: out.txt
out.txt:main.exe
	mono $< >$@ 2>Log

main.exe:main.cs matlib.dll #roots.dll
	mcs $< -r:$(call clist,$(filter %.dll,$^))

matlib.dll:$(LIBSRC)
	mcs $^ -target:library -out:$@

# roots.dll:jacobian.cs newton.cs broyden.cs matlib.dll
# 	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
# 	mcs $$src -t:library -r:$$libs -out:$@

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))