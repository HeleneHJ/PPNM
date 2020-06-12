all: out.txt
out.txt: main.exe
	mono $< >$@ 2>log

main.exe: main.cs minimum.dll matlib.dll
	mcs $< -r:$(call clist,$(filter %.dll,$^))

LIBDIR=../../../matlib/matrix
matlib.dll: $(LIBDIR)/vector.cs $(LIBDIR)/matrix.cs
	mcs $^ -target:library -out:$@

minimum.dll: simplex.cs matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

clean:
	$(RM) *.exe *.dll [o]ut* [l]og*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))