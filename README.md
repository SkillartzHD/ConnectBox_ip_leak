# ConnectBox_ip_leak

This could help native application developers to identify a specific user in case he uses a vpn with a ConnectBox router
it wouldn't matter what system it uses as long as the request is made on **192.168.0.1:5000** (it can also be android & ios & mac & windows & linux) as long as the request is made on the internal router (so it can't bypass it like that easy)

### Video
[![POC](https://img.youtube.com/vi/jnvPLNpik4w/0.jpg)](https://www.youtube.com/watch?v=jnvPLNpik4w)


![Untitled](https://user-images.githubusercontent.com/8433325/130368684-3cdf6328-41bf-4999-a257-7748ab5390de.png)


only functional on the ConnectBox (https://www.upc.ch/pdf/support/en/manuals/internet/connectbox/connect-box-manual.pdf)
it will probably be on other router models as well.




header soapaction

```xml
urn:schemas-upnp-org:service:WANIPConnection:1#GetExternalIPAddress
```

response from 192.168.0.1:5000

```xml
<?xml version="1.0"?>
<s:Envelope
	xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
	<s:Body>
		<u:GetExternalIPAddressResponse
			xmlns:u="urn:schemas-upnp-org:service:WANIPConnection:1">
			<NewExternalIPAddress>MY.IP (1.1.1.1.1) </NewExternalIPAddress>
		</u:GetExternalIPAddressResponse>
	</s:Body>
</s:Envelope>
```
