Out.htm : main.exe
	echo '<meta charset="UTF-8"><pre>' >$@
	mono $< >> $@ 2>log

main.exe : main.cs matlib.dll
	mcs $< -reference:$(lastword $^)

DIR=../../../matlib/integration
SRC=$(DIR)/quado8.cs
matlib.dll : $(SRC)
	mcs $^ -target:library -out:$@

clean:
	rm -f Out.htm main.exe matlib.dll log