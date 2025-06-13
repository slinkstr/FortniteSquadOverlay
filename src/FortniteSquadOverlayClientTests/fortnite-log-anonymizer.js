/*
 * Cleans PII from Fornite log files.
 * Includes hardware specs, system info, attached device IDs/serials, etc.
 * Makes no guarantee of fully anonymizing logs.
 *
 * Usage: deno run --allow-all fortnite-log-anonymizer.js [input file]
 */

const regexes = {
    os              : /LogCsvProfiler: Display: Metadata set : os="(.*)"/,
    cpu             : /LogCsvProfiler: Display: Metadata set : cpu="(.*)\|(.*)"/,
    timezone        : /LogICUInternationalization: ICU TimeZone Detection - Raw Offset: (.*), Platform Override: ''/,
    windowsPath     : /LogPlatformFileManagedStorage: Display: Scan directory (C:\/Users\/.*)\/AppData\/Local\/FortniteGame\/Saved\/demos/,
    machineId       : /LogInit: MachineId=(.*)/,
    deviceId        : /LogInit: DeviceId=(.*)/,
    authPassword    : /-AUTH_PASSWORD=(\S*)/,
    gameDir         : /LogInit: Base Directory: (.*)Fortnite\/FortniteGame\/Binaries\/Win64\//,
    computerName    : /\[.*\]\[[\d\s]+\]LogInit: Computer: (.*)/,
    windowsName     : /\[.*\]\[[\d\s]+\]LogInit: (User: .*)/,
    cpuPageAndCores : /\[.*\]\[[\d\s]+\]LogInit: CPU Page (size=.*, Cores=.*)/,
    memoryTotal     : /\[.*\]\[[\d\s]+\]LogMemory: Memory total: Physical=(.*) \((.*) approx\) Virtual=(.*)/,
    memoryPhysical  : /\[.*\]\[[\d\s]+\]LogMemory: Physical Memory: (.*) used,  (.*) free, (.*) total/,
    memoryVirtual   : /\[.*\]\[[\d\s]+\]LogMemory: Virtual Memory: (.*) used,  (.*) free, (.*) total/,
    gpuDeviceId     : /\[.*\]\[[\d\s]+\]LogD3D11RHI:     GPU DeviceId: (.*) \(for the marketing name, search the web for "GPU Device Id"\)/,
    refreshRate     : /- Resolution: (.*x.*@.*Hz) at .*% 3D Resolution/,
    audioOutput     : /\[.*\]\[[\d\s]+\]LogFort: Display:   (.*) \(\{.*\}\.\{(.*)\}\)/,
    epicAccount     : /\[.*\]\[[\d\s]+\]LogOnlineAccount: Display: \[UOnlineAccountCommon::ProcessUserLogin\] Successfully logged in user. UserId=\[(.*)\] DisplayName=\[(.*)\] EpicAccountId=\[MCP:(.*)\] AuthTicket=\[<Redacted>\]/,
    epicAccount2    : /\[.*\]\[[\d\s]+\]LogOnlineAccount: Display: \[OnlineAccount:0\]\[process_user_login\] Successfully logged in user. UserId=\[(.*)\] DisplayName=\[(.*)\] EpicAccountId=\[MCP:(.*)\] AuthTicket=\[<Redacted>\]/,
    region          : /\[.*\]\[[\d\s]+\]LogQos: Verbose: \[UQosRegionManager::GetBestRegion\] Best region: "(.*)"  \(Current selected: "(.*)"\)/,
    audioInput      : /\[.*\]\[[\d\s]+\]LogEOSVoiceChat: \[.*\] SetInputDeviceId effective device Id=\[\{(.*)\}\] DisplayName=\[(.*)\]/,
    gpuName         : /\[.*\]\[[\d\s]+\]LogRHI:             Name: (.*)/,
    gpuDriverVersion: /\[.*\]\[[\d\s]+\]LogRHI:   Driver Version: (.*)/,
    gpuDriverDate   : /\[.*\]\[[\d\s]+\]LogRHI:      Driver Date: (.*)/,

    gpuDetails      : /.*LogD3D11RHI: (.*)/,
    monitorDetails  : /.*LogWindows: (.*)/,
};

function collectStrings(fileContent) {
    let ret = new Set();
    let lines = fileContent.split(/\r?\n/g);
    for (let line of lines) {
        for (let key of Object.keys(regexes)) {
            let match = line.match(regexes[key]);
            if (!match || match.length < 2) { continue; }
            match.slice(1).forEach((elm) => ret.add(elm));
        }
    }

    return ret;
}

function cleanStrings(fileContent, stringArray) {
    for (let str of stringArray) {
        fileContent = fileContent.replaceAll(str, "*ANONYMIZED*");
    }
    return fileContent;
}

for (let arg of Deno.args) {
    let logContent   = await Deno.readTextFile(arg);
    if (!logContent) {
        throw new Error("Blank log file");
    }

    let stringSet = collectStrings(logContent);
    let cleanLog  = cleanStrings(logContent, Array.from(stringSet).filter(Boolean));
    await Deno.writeTextFile(arg + ".cleaned.log", cleanLog);
}
