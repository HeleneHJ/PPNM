CSFLAGS = -warn:4

out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs precision.dll
	mcs $(CSFLAGS) -reference:precision.dll -out:main.exe main.cs

precision.dll : precision.cs
	mcs $(CFLAGS) -target:library -out:$@ $^ 

.PHONEY:clean
clean:
	rm --force out* *.dll *.exe

