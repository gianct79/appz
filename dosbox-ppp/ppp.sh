#!/bin/bash
#
# Heavily Modified from: https://www.dosbox.com/wiki/PPP_configuration_on_linux_host
#
# Usage:
# sudo ./ppp.sh
#
# This script makes it so you can browse the net with DOSBox and Trumpet Winsock in
# Windows 3.11
#
# LINUX:
#   To use this script simply change the IP addresses below to two unused IP addresses on your network
#   then run with root (needed for port 23/proxyarp)
#
# WINDOWS 3.11:
#   Install Trumpet Winsock
#   Click on 'Dialer->Manual Login'
#   Type: AT (if you see 'ERROR' type AT again)
#   ATDT <LINUX IP ADDRESS>
#   e.g. ATDT 10.10.10.10
#   You should see 'CONNECT'
#   Hit the Escape button and your good to go!
#
# DOSBox Config:
#   Add this to the bottom of your config
#   [serial]
#   serial1=modem listenport:2323
#   serial2=dummy
#   serial3=disabled
#   serial4=disabled
#

grep -q 1 /proc/sys/net/ipv4/ip_forward || \
    ( echo 1 1>/proc/sys/net/ipv4/ip_forward )

# trap ctrl-c and call ctrl_c()
trap ctrl_c INT

function ctrl_c() {
    echo "** Trapped CTRL-C"
    echo "** Shutting down ISP"
    pkill -9 pppd
    [ -e "/tmp/trumpet" ] && rm "/tmp/trumpet"
    exit 0
}

ip=$(hostname -I)

ip1=$(awk -F"." '{print $1"."$2"."$3".100"}'<<<$ip)
ip2=$(awk -F"." '{print $1"."$2"."$3".101"}'<<<$ip)

echo "** Creating fake ISP"
echo "** Using Serial /tmp/trumpet"

echo "$ip"

while true
do
    if sleep 0.1 && pgrep socat > /dev/null 2>&1
    then
        sleep 0.1
    else
        echo "** Starting socat listener on port 23"
        socat TCP4-LISTEN:23 PTY,link="/tmp/trumpet" &
    fi
    sleep 0.5
    if pgrep pppd > /dev/null 2>&1
    then
        sleep 1
    else
        echo "** Starting pppd"
        pppd "/tmp/trumpet" defaultroute mtu 576 $ip1:$ip2 login proxyarp > /dev/null 2>&1
    fi
done
