# license - by Avery Stafford 2021-2022
echo EMULATION-THOR
echo Put in any directory with code.ethor file -ETHOR is a zip with Thor/ArdenWare code in it- and activate EMULATION-THOR.
echo What dir will the ETHOR be? :
read location
cd $location
echo What is the name of the .ethor file? -do not include the extension ETHOR :
read fdata
mv ./$fdata.ethor ./$fdata.zip
unzip $fdata.zip
wget https://github.com/ArdenyUser/LoadD-Software-Libary/raw/main/ArdenWareThorium/emulator.zip
unzip emulator.zip
# ADD AARCH64 MAKEFILE OR ARM MAKEFILE
echo Which installation which you have? arm or aarch64
read archti
arm-linux-gnueabi-gcc main.c -o helloworld-arm -static
if [ $archti == "arm" ]; arm-linux-gnueabi-gcc main.c -o helloworld-arm $fdata-static; fi
if [ $archti == "aarch64" ]; aarch64-linux-gnueabi-gcc main.c -o $fdata-static; fi
