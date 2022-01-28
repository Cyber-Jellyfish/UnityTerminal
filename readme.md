# Unity Terminal

UnityTerminal is a tool that allows you to start standard or administrator instance of Command Prompt and/or the Powershell within Unity
Editor.<br/>
You can also add your own System Diagnostic Processes to a CustomProcesses script that can be executed within the editor via the Menu
Bar.<br/>
Additionally you can also add them to a specialized scriptable object called CustomProcessesSo.

## Main Scripts

### Process Utilities Script

This is a simple script that currently has 2 static methods.

```c#
StartProcess(string filename, bool runAsAdmin = false);
StartAdvProcess(string filename, string argument, bool hideWindow = false, bool runAsAdmin = false)
```

StartProcess - allows you to start any process without arguments as a standard user or administrator.<br/>
StartAdvProcess - allows you start any process with arguments as a standard user or administrator with additional options to hide the
console window.

### Windows Command Prompt Script

The Windows Command Prompt Script contains methods that allow you to open a Command Prompt (CMD) or Powershell window from within Unity.

To open a Command Prompt window you can navigate to "System/Command Prompt" and select one of the CMD instance you wish to open.<br/>
Alternatively you can open a CMD instance with the "ctrl+shift+l" (standard instance) or
"ctrl+alt+l" (admin instance) keyboard shortcuts.

To open a Powershell window you can navigate to "System/Powershell" and select on of the Powershell instances you wish to open.<br/>
Alternatively you can open a Powershell instance with the "ctrl+shift+h" (standard instance) or
"ctrl+alt+h" (admin instance) keyboard shortcuts.

### Custom Processes Script

The Custom Processes Script allows you to code you own custom Processes. Your custom processes can be used with the unity [MenuItem]
attribute to allow the method to be called from within the Unity Editor via the Menubar or Inspector.

To create a process in the Custom Process Script you need to do the following:<br/>

+ Use one of the predefined methods (StartProcess or StartAdvProcess) in the ProcessUtilities class, or
+ Code your own custom Process using System.Diagnostic namespace

#### Examples
Here are a few examples of creating your own custom processes.

##### 1. Simple Process using StartProcess Method in ProcessUtilities Script
```c#
// Starting a simple Notepad Process
public static async Task Notepad()
{
    await Task.Run(() => ProcessUtilities.StartProcess("notepad.exe"));
}
```

##### 2. Advanced Process using StartAdvProcess Method in ProcessUtilities Script
```c#
// Starting an Advanced Process
public static async Task Echo()
{
    await Task.Run(() => ProcessUtilities.StartAdvProcess("cmd.exe", "/k echo hello, world"));
}
```

##### 3. Coding your Custom Process Method
```c#
// Creating your own Custom Advanced Process
public static async Task CustomProcess()
{
    await Task.Run(() => 
    {
        using Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.Arguments = @"/c echo hello world";
        process.Start();
                
        process.StandardInput.WriteLine("echo hello");
        process.StandardInput.Flush();
        process.StandardInput.Close();
        process.WaitForExit();
        Debug.Log(process.StandardOutput.ReadToEnd());
    });
}
```

[//]: # (## Command Script Scriptable Object)

[//]: # ()
[//]: # (The Command Script Scriptable Object is a visual representation of creating processes.<br/>)

[//]: # (You can easily add and delete and edit your processes without hassle and just as easily execute them with a single button click.)

[//]: # ()
[//]: # (To create a Process in the Command Script you need the follow information:<br/>)

[//]: # ()
[//]: # (+ A Process Name<br/>)

[//]: # (+ A Filename or name of the process for example "cmd.exe"<br/>)

[//]: # (+ An optional Argument<br/>)

[//]: # (+ Run As Admin Optional Setting<br/>)

[//]: # (+ Hide Window Optional Setting<br/>)

## Unity Specific Tips
#### MenuItem

The MenuItem attribute allows you to add menu items to the main menu and inspector context menus.<br/>
The MenuItem attribute turns any static function into a menu command. Only static functions can use the MenuItem attribute.

The Unity documentation states that:
```text
To create a hotkey you can use the following special characters: 
% (ctrl on Windows, cmd on macOS), 
# (shift), 
& (alt). 

If no special modifier key combinations are required the key can be given after an underscore. 
For example to create a menu with hotkey shift-alt-g use "MyMenu/Do Something #&g". 
To create a menu with hotkey g and no key modifiers pressed use "MyMenu/Do Something _g".
```

## Useful Links
### C# - Process
https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=net-6.0

### C# - Process Start Info
https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.processstartinfo?view=net-6.0

### Windows - Command Prompt: Syntax and Parameters
https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/cmd

### Unity - MenuItem Attribute
https://docs.unity3d.com/ScriptReference/MenuItem.html#:~:text=The%20MenuItem%20attribute%20turns%20any,)%2C%20%26%20(alt).
