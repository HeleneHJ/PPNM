all: out.txt
	cat $<

out.txt: main.exe 
	mono main.exe 1 2 3 4 5 > $@

main.exe: main.cs
	mcs -out:$@ $^

.PHONY:clean
clean:
	rm -f main.exe out.txt