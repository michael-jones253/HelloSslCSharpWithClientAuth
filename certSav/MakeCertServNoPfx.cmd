makecert.exe ^
-pe ^
-n "CN=catapultsports.com" ^
-iv CARoot.pvk ^
-ic CARoot.cer ^
-a sha512 ^
-len 4096 ^
-b 01/01/2014 ^
-e 01/01/2017 ^
-sky exchange ^
-eku 1.3.6.1.5.5.7.3.1 ^
-sv %1.pvk ^
%1.cer