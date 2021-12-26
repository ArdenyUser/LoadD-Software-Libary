#!/bin/bash

while :
do

type -a break continue
filename= ./appexecute
declare -i i=0
declare -i c=1

while read line
do
    if [ $c -eq $i ] then
          i+=1
          apptoread=$line
          break
          
    fi
    c+=1
done < $filename
file_path= $apptoread
while IFS = read  -r line
do
    elfexecute $line
done < “$file_path”
done < $filename
