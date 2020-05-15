out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs vector3d.dll
	mcs -reference:$(word 2,$^) -out:$@ $<

vector3d.dll : vector3d.cs ivector3d.cs ivector3dfunctions.cs
	mcs -target:library -out:$@ $^

PHONEY:all
clean:
	rm -f *.dll *.exe out*
