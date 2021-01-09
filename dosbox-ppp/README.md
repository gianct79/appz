# This is PPP on DOSBox

## Requirements

* Linux Box (WSL2 can work as well)
* DOSBox
* [Windows 3.11](https://winworldpc.com/product/windows-3/311)
* [Trumpet Winsock](https://winworldpc.com/product/trumpet-winsock/3x)
* [Netscape Navigator](https://winworldpc.com/product/netscape-navigator/2x)

* On Linux box:
  * Install pppd.
  * Install socat.

* On DOSBox:  
  * Change serial configuration:

```
[serial]
serial1=modem listenport:2323
serial2=dummy
serial3=disabled
serial4=disabled
```

## Running

* Run `ppp.sh` as root (original is [here](https://gist.github.com/mainframed/2300903d9cc259a2a2ab431ca152dffc)):

  * Change line 65 from "10.10.0.200:10.10.0.201" to two IP addresses that are routable on home network.
  * The second address (10.10.0.201) will be the Windows 3.11 IP address.

* Setup Trumpet Winsock:

  * IP address: 0.0.0.0.
  * DNS server: 8.8.8.8 (or 8.8.4.4).

* Connect with Trumpet Winsock:
  * Dialler > Manual login.
  * At the prompt type:

```
# (if error, type AT again)
AT

ATDT <LINUX_IP_ADDRESS>
```

  * Hit escape and PPP is connected (notice the assigned IP address).
