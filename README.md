# RutCitrusManager
## At present, the program is in the test stage, many functions have not been fully developed or even not developed, time is limited. I am still in high school, this project may not be developed for a long time, and my English is not very good, please understand.

## When using or creating any of its affiliated plugins or branches in any way, it is sufficient to indicate the source, which is only [GitHub](https://github.com/psoloi/RutCitrusManager)

## The overall plan for the future
This project is a combination of server + client, and there should be a client made using Winform in the future.

## Project all warnings
```csharp
ManagementObjectSearcher searcher = new("SELECT * FROM Win32_ComputerSystem");
foreach (ManagementObject mo in searcher.Get())
{
    string? model = mo["Model"] as string;
    if (model != null && (model.Contains("Virtual") || model.Contains("VMware") || model.Contains("Xen") || model.Contains("KVM") || model.Contains("Hyper")))
    {
        isVM = true;
        break;
    }
}
```
> This code may have limitations and is only applicable to the Windows platform.

## Update list
1. Add server and client LAN chat functionality.
2. Add TCP and UDP simulation servers.
3. Add a local area network file transfer server.
4. Improve the basic function of CLI command to enable program startup functionality.
5. Add the function of program update.
6. Add the official game download market and the automated game installation function.
7. Improve configuration files and expand examples.
8. Add Extension Builder.
9. The projects related to RutCitrus connection.
    - Interface
    - Web
10. Add the function of setting options.
11. Add RutCitrus game server status detection for information monitoring.
12. Add an SQLite database.
13. Add Task Plan Function.
14. Add a project file downloader.
15. Add Server Ping Tool.
16. Add the complete toolkit.
17. Add Program Repairer.
18. Add server data packet sending mode.
19. Add client-side broadcast.


#### What better suggestions and features can be proposed, and thank you for your contribution.
