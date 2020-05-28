all: Out.txt
Out.txt:main.exe
	mono $< >$@ 2>Log

main.exe:main.cs minimum.dll matlib.dll
	mcs $< -r:$(call clist,$(filter %.dll,$^))

LIBDIR=../matrix
matlib.dll: $(LIBDIR)/vector.cs $(LIBDIR)/matrix.cs
	mcs $^ -target:library -out:$@

minimum.dll: qnewton.cs simplex.cs matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))