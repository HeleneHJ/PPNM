all:C.txt

C.txt : main.exe ; mono $< > $@

DLLS = givens.dll matlib.dll
main.exe: main.cs $(DLLS)
	mcs $< -reference:$(call clist,$(DLLS))

LIBDIR = ../../../matlib
LIBSRC = \
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs
matlib.dll: $(LIBSRC)
	mcs $^ -target:library -out:$@

SRC=givens.cs backsubst.cs solve.cs inverse.cs
givens.dll:$(SRC) matlib.dll
	mcs $(SRC) -target:library -out:$@ -reference:$(lastword $^)

clean:
	$(RM) *.dll *.exe out* C*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))