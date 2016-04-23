#!/bin/bash

openssl pkcs12 -in hello.pfx -nocerts -nodes  > hello_priv_key.pem
exit 0
