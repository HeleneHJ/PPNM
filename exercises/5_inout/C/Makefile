all: outputfile.txt 

INPUT=inputfile.txt

outputfile.txt: main.exe inputfile.txt Makefile
	mono main.exe inputfile.txt outputfile.txt

main.exe: main.cs     
	mcs $<

clean:
	$(RM) *.exe outputfile* inputfile.txt