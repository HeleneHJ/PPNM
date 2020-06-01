all: out.txt 
	cat out.txt

out.txt: main.exe
	mono $< > out.txt

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^)

LIBDIR = $(HOME)/repos/PPNM/matlib
SRC :=$(LIBDIR)/matrix/vector.cs
SRC +=$(LIBDIR)/matrix/matrix.cs

matlib.dll: classic2.cs jacobi.cs $(SRC) 
	mcs $^ -target:library -out:$@

clean:
	$(RM) out* *.exe *.dll