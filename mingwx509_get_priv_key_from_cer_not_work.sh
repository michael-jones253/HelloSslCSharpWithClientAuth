#!/bin/bash

openssl x509 -inform NET -in hello.pvk  > hello_x509priv_key.pem
exit 0
