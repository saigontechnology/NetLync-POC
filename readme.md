# .NET Carrier API server projects

API end-points have to use mutual TLS for securing the communication between ES of page https://developer.netlync.com and Carrier API spec. 
To configure this, download Certificate Signing Request (CSR) in https://developer.netlync.com and sign it with the private key which is used on Carrier API server. 
Copy/paste the resulting TLS client certificate in PEM format to the form of client to form in test environment.