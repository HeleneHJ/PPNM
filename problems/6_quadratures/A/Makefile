Out.txt:main.exe
	mono $< > $@ 2>log
main.exe:main.cs matlib.dll
	mcs $(filter %.cs,$^) -reference:$(filter %.dll,$^)
matlib.dll:quad.cs quado8.cs
	mcs $^ -target:library -out:$@
clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*