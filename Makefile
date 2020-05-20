.DEFAULT_GOAL := run

clean:
	rm -f ./src/Interpreter/Parser.fs
	rm -f ./src/Interpreter/Parser.fsi
	rm -f ./src/Interpreter/Lexer.fs
	find . -type d -name obj -prune -exec rm -rf {} \;
	find . -type d -name bin -prune -exec rm -rf {} \;

build: clean
	dotnet build --verbosity quiet ./src/Interpreter/Interpreter.fsproj
	dotnet build --verbosity quiet ./src/Lispy/Lispy.fsproj

run: build
	clear
	dotnet run --project ./src/Lispy/Lispy.fsproj

	
