out.txt:main.exe
	mono $< > $@ 2>log

main.exe: main.cs matlib.dll
	mcs $(filter %.cs,$^) -reference:$(filter %.dll,$^)

# LIBDIR = ../../../matlib/integration
# matlib.dll: $(LIBDIR)/quado8.cs quad.cs clenshawcurtis.cs
# 	mcs $^ -target:library -out:$@


LIBDIR = $(HOME)/repos/PPNM/matlib/integration
matlib.dll: $(LIBDIR)/quado8.cs quad.cs clenshawcurtis.cs
	mcs $^ -target:library -out:$@

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*