# RelayDiscovery
A Relay Pool api server that filters the data from relays.syncthing.net

## Background
I have a network of clients that often are behind different firewalls, and I have been having perfomance problems that I, 
for lack of another explanation, blame on the firewall. The client happily advertices itself with a bunch of addresses that will never work.
Also clients on the outside sometimes connect to relays that the firewalled client will never reach. 

After a while they usially find each other, but it takes time and transfer speed has been low.

## Solution
This is a simple webapi that on each request to /relays fetches the data from relays.syncthing.net, filters out those with Port = 443 
(and atm also those that are geographically local to me), sorts them by transfer speed (don't know it this makes any difference, but anyway)
and returns the result

Then I select "dynamic+<webapi address>" as Listen Address in my syncthing clients.
