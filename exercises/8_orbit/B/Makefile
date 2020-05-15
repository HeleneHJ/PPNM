MATLIB = ../../../matlib

all : circular.svg elliptic.svg relativistic.svg
# 	@gio open $^

# i)
circular.svg : circular.gpi circular.txt
	@gnuplot $<
circular.txt : maincircular.exe
# 	epsilon u(0) u'(0) xEnd
	@mono $< 0 1 1e-7 100 1> $@ #2> log

# ii)
elliptic.svg : elliptic.gpi elliptic.txt
	@gnuplot $<
elliptic.txt : maineccentric.exe
# 	epsilon u(0) u'(0) xEnd
	@mono $< 0 1 -0.5 100 1> $@ 2> log

# iii)
relativistic.svg : relativistic.gpi relativistic.txt
	@gnuplot $<
relativistic.txt : maineccentric.exe
# 	epsilon u(0) u'(0) xEnd
	@mono $< 0.01 1 -0.5 50 1> $@ 2> log

maincircular.exe : maincircular.cs odelib.dll
	@mcs $< -reference:odelib.dll

maineccentric.exe : maineccentric.cs odelib.dll
	@mcs $< -reference:odelib.dll

odelib.dll : $(MATLIB)/ode/bak.ode.cs $(MATLIB)/matrix/vector.cs
	@mcs -target:library -out:$@ $^

.PHONEY : clean

clean : 
	rm -f *.txt log *.dll *.svg