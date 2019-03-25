all: bracket_balance

bracket_balance: main.o stack.o checkBalance.o test.o

main.o: main.cpp test.h
	g++ -c main.cpp

stack.o: stack.cpp stack.h
	g++ -c stack.cpp

checkBalance.o: checkBalance.cpp checkBalance.h stack.h
	g++ -c checkBalance.cpp

test.o: test.cpp test.h checkBalance.h
	g++ -c test.cpp

clean:
	rm -rf *.o bracket_balance


