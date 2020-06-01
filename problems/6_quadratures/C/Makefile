out.txt:main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $(filter %.cs,$^) -reference:$(filter %.dll,$^)

LIBDIR = ../../../matlib/integration
matlib.dll: $(LIBDIR)/quado8.cs quad.cs infint.cs
	mcs $^ -target:library -out:$@

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*