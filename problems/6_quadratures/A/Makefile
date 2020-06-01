out.txt:main.exe
	mono $< > $@ 2>log

main.exe: main.cs matlib.dll
	mcs $(filter %.cs,$^) -reference:$(filter %.dll,$^)

LIBDIR = ../../../matlib/integration
matlib.dll: quad.cs $(LIBDIR)/quado8.cs
	mcs $^ -target:library -out:$@

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*