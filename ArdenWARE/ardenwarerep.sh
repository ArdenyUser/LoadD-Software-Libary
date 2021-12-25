#!/bin/bash
toilet -f mono12 -F gay ArdenWARE
toilet -f mono12 -F metal From Ardeny Foundation
echo -----------------------------------------------
echo -----------------------------------------------
TMPFILE=$(mktemp)

dialog --menu "Choose one:" 10 30 3 \
    1 ArdenWARE OS Installer \
    2 QuikUtils \
    3 Emulation Thor 2>$TMPFILE

RESULT=$(cat $TMPFILE)

case $RESULT in
    1) echo "Red";;
    2) echo "Green";;
    3) echo "Blue";;
    *) echo "Unknown color";;
esac

rm $TMPFILE
