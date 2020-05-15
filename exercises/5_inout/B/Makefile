all: out.txt
	cat $<

out.txt: main.exe 
	echo 1 2 3 4 5 | mono main.exe > out.txt

main.exe: main.cs
	mcs -out:$@ $^

.PHONY:clean
clean:
	rm -f *.txt *.exe