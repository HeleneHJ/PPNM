all:B.txt

B.txt : main.exe ; mono $< > $@

DLLS = gramschmidt.dll matlib.dll
main.exe: main.cs $(DLLS)
	mcs $< -reference:$(call clist,$(DLLS))

LIBDIR = $(HOME)/PPNM/matlib
LIBSRC = \
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs
matlib.dll: $(LIBSRC)
	mcs $^ -target:library -out:$@

SRC=gramschmidt.cs backsubst.cs solve.cs inverse.cs
gramschmidt.dll:$(SRC) matlib.dll
	mcs $(SRC) -target:library -out:$@ -reference:$(lastword $^)

clean:
	$(RM) *.dll *.exe out* log* Out* B*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))