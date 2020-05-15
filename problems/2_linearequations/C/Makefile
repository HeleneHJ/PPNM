all: out.txt
	cat out.txt

MATLIB = ../../../matlib
SRC := $(MATLIB)/matrix/matrix.cs
SRC += $(MATLIB)/matrix/vector.cs
# SRC += $(MATLIB)/complex/complex.cs
# SRC += $(MATLIB)/complex/cmath.cs
# LIB = $(HOME)/Desktop/PPNM/Exercises/TrialAndError/lineareq/C
# SRC += $(LIB)/givens.cs
# SRC += $(LIB)/qr_abstract.cs
# SRC += $(LIB)/QRgivens.cs

matlib.dll: $(SRC) QRgivens.cs
	mcs -target:library -out:$@ $^

out.txt: main.exe
	mono $< 1> $@

main.exe: main.cs matlib.dll
	mcs -out:$@ -reference:matlib.dll $<

.PHONEY:clean
clean:
	rm -f out.* *.txt *.dll *.exe 