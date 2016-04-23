Make root - MakeCARoot.cmd
Make server cert - MakeCertServ.cmd
Make client - MakeClientCert.cmd

To run c# against boost c++ server
mingw_cer_to_pem.sh
mingw_get_priv_key_from_cer.sh

The first makes hello_certificate.pem (I think this contains public key as well as cert).
The second makes hello_priv_key.pem


NB mingw_get_pub_key_from_cer.sh does not seem to be needed.


Run boost security
--port 22 --cert hello_certificate.pem --private-key hello_priv_key.pem --password catapult

Run HelloSslClient 

--server localhost --clientcert "D:\MJ-HelloWorld\HelloSsl\client.pfx" --machine "catapultsports.com" --port 22

NB this will handshake with server and give certificate chain errors.

To fix certificate chain errors install CARoot.cer

See https://www.jayway.com/2014/09/03/creating-self-signed-certificates-with-makecert-exe-for-development/
Windows key -> MMC -> File -> Add/Remove snap in -> Certificates -> Add -> OK ->Computer Account

Save "Console1 to Windows Administrative Tools" to some name e.g. Console1Certificates.msc


Then when need to run MMC again don't need to add snap in. Just File -> Open -> Console1Certificates.msc

Then can do things such as Trusted Root Certification Authorities -> Certificates -> All Tasks -> Import.

Then run HelloSslClient again and it should be all good.

NB this currently does not do client cert verification, but allows the client to verify that the boost server is for real.


