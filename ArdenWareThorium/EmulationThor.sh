# license - by Avery Stafford 2021-2022
echo EMULATION-THOR
echo Put in any directory with code.ethor file -ETHOR is a zip with Thor/ArdenWare code in it- and activate EMULATION-THOR.
echo Begin? Y -CAPS- or N:
read rqa
if [ $rqa -eq Y ] then
mv ./code.ethor ./code.zip
unzip code.zip
wget [ETHOR EMULATION BOX]
unzip emulator.zip
make
fi
