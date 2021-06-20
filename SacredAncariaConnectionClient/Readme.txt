Sacred Ancaria Connection - 1.0 (20-Jun-2021)

If you want just to play, start this program before starting Sacred, be sure it connects to the SAC Network.
Just be sure to set the ingame network speed option to MODEM / ISDN (in setting menu)

If you want to host, please be sure to change Gameserver.cfg NETWORK_PORT_LISTEN to a different port: I advise 2006, to not conflict with NETWORK_PORT_TCP in Settings.cfg. These ports should reflect the settings in SAC Client, “Listening UDP Port” and “Broadcasting UDP Port in LAN”.
Hosting via Sacred is not supported, please use dedicated server only.

Here is a quick guide of the host tab:
- “Autodetected Server IP” should show your real public IP. If this is not your real public IP, please write it in the “Force Server IP”, click on “Force IP” checkbox, then click Apply.
- “Listening UDP Port” indicates the UPD port SAC is listening for Gameserver info. It should match NETWORK_PORT_LISTEN in Gameserver.cfg.
- “Broadcasting UDP Port in LAN” broadcast the server in your host also in LAN (as the original network system). Useful if you want to mix LAN players and internet players.
- Command line parameters
- “Headless”: start the SAC Client in headless mode, using the console as primary output. Modify SacredAncariaConnectionClient.cfg (created after first start) do modify the SAC options.
- “Filelog”: write the console output to “SacredAncariaConnectionClient.log”
- “None”: SAC does not write anything in console
- “Debug”: SAC writes a lot of output (do not use in production)

Server list:
If your server is in RED, SAC Server could not connect to your server. Please be sure your TCP port is forwarded to internet.

-- About

Software made by Alby87.

Thanks to:
Lain, for server hosting and general help.
Eine Krone for the icon of the software.
Kevin Prohn for making SacredLTI, which gave me inspiration for creating this software.

Libraries used:
DotNetZip, IPAddressCOntrol and Newtonsoft.Json
