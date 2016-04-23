#!/bin/bash

openssl x509 -inform der -in hello.cer -outform pem -out hello_certificate.pem

exit 0
