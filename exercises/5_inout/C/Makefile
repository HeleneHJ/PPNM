all: outputfile.txt 

INPUT=inputfile.txt

outputfile.txt: main.exe inputfile.txt Makefile
	mono main.exe inputfile.txt outputfile.txt

main.exe: main.cs     
	mcs $<

clean:
	$(RM) *.exe outputfile* inputfile.txt

# in.txt: Makefile
# 	/bin/echo -e '0.5\n2.5\n3.5' > $@
