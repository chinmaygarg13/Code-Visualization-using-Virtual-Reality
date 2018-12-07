/usr/bin/time -o time.txt -f "\nCPU seconds used by user = %U \nCPU seconds used by kernel = %S \nInputs = %I \nOutputs = %O\nPage Faults = %F \nTotal Memory used (KB) = %K \nCPU percentage used = %P \n" /bin/sh -c '>gdb.txt;g++ -g main.cpp;gdb a.out < inputgdb.txt' 
#!/bin/bash
g++ func_finder.cpp
./a.out main.cpp > fun_list.txt
cp -- "main.cpp" "main.txt"
