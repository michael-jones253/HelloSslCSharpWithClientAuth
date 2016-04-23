#!/bin/bash

openssl x509 -inform der -in hello.cer -pubkey -noout  > hello_pub_key.pem
exit 0
