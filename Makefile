.DEFAULT_GOAL := run

clean:
	rm -f ./src/Interpreter/Parser.fs
	rm -f ./src/Interpreter/Parser.fsi
	rm -f ./src/Interpreter/Lexer.fs
	find . -type d -name obj -prune -exec rm -rf {} \;
	find . -type d -name bin -prune -exec rm -rf {} \;

build: clean
	dotnet build ./src/Interpreter/Interpreter.fsproj
	dotnet build ./src/Lispy/Lispy.fsproj

run: build
	dotnet run --project ./src/Lispy/Lispy.fsproj
