# Triage
- [ ] Test loading broken config
- [ ] Check updating from zip

# Fix

# Enhance

# Add
- [ ] Right click tray icon
- [ ] Debug features: Debug overlay, skip in-game check, skip fortnite open check, skip current squad check

# Ideas
- [ ] Client rework
    - [ ] UI
        - MAUI: seems to use 2x the ram, is designed for mobile-first, does not seem like a good choice
        - Avalonia: Cross-platform, desktop-first, potential
        - WPF: next logical step after winforms
    - [ ] components
        - [x] ProcessMonitor
            - [x] monitors Fortnite exe, runs callback when opened/closed, focused/unfocused
        - [x] LogReader
            - [x] monitors log file, runs callback with each line
        - [ ] FortniteLogParser
            - [ ] regexes and callbacks
        - [x] Config
            - [ ] upload API
            - [ ] API key
            - [x] upload interval, default 5 sec
            - [ ] download speed throttle? downloads per second? per minute? default infinite
                - [ ] probably throttle, for e.g. chrys - skip new downloads if one comes in while downloading
                - [ ] OR: download interval enforced per user, so if you only want every 5 seconds and they upload every second it downloads 1 and ignores next 4
            - [x] show console
            - [x] hud scale
            - [x] overlay opacity
            - [x] enable overlay
            - [x] minimize to tray
            - [x] start minimized
            - [x] always on top
            - [x] run at startup
        - [ ] Screen Overlay manager
            - [ ] needs window position, size, and desired opacity, updated every time these change
            - [ ] will handle stale images by hiding
            - [ ] updated by taking ordered squad name array and ordered bitmap array
        - [ ] UI manager
            - [ ] needs access to read and write config
            - [ ] updated with squad name array, bitmap array
            - [ ] provides log func
            - [ ] modify squad order callback
            - [ ] will handle stale images by darkening
            - [ ] could also have Main, Config, and Console tabs
        - [ ] Screen Grabber
            - [ ] needs window position, size, and hud scale, updated every time these change
            - [x] can't use gold bars anymore because they hide themselves
                - [x] use squad color diamonds top-left? I don't think those can ever be hidden, but 4 separate colors + colorblind mode + no way to know which color you're supposed to be = very trigger happy
            - [ ] revisit squad name OCR to get order
            - [ ] screenshots, crops, and invokes callback with created bitmap
            - [ ] provides "suspend"/"resume" func for when game is closed
        - [ ] Download manager
            - [ ] subscribe to websocket and invoke callback with new bitmaps
            - [ ] fallback to json index
            - [ ] needs squad
                - [ ] if streamed through socket: needs to communicate who's in the current squad to only receive updates for them
                - [ ] if url provided by socket: can just ignore non-squad members
            - [ ] provides suspend/resume func when game is closed
        - [x] Logger
            - [x] Info, warning, error, etc.
            - [x] Log to file, stdout, and form
        - [ ] Main
            - [ ] tracks game open, squad members, config, configures all pieces
- [ ] server
    - [ ] ASP.NET for API https://dotnet.microsoft.com/en-us/apps/aspnet/apis
        - [ ] websocket endpoint? `subscribe`, authorization: apikey, listen to gear updates
            - [ ] should websocket send image data or just notify that new image is available? It will reduce noise in nginx logs if it sends image data, might reduce latency
        - [ ] POST endpoint: `upload`, authorization: apikey, data: { name, bitmap }, restrict bitmap to ?mb
        - [ ] GET endpoint: `list`, authorization: apikey
    - [ ] API doc: swagger? `Microsoft.AspNetCore.OpenApi`?
    - [ ] Config
        - [ ] API keys - "name": "key", allows fine control and logging, flexible for per user or per group
        - [ ] Image destination folder
    - [ ] Text ui
        - [ ] Perhaps? https://www.nuget.org/packages/Terminal.Gui
        - [ ] Take inspiration from htop, display uptime, total bandwidth (in/out), active connections per api key name, log lines

# Wontfix
- HDR
    - Does not seem possible without directX
