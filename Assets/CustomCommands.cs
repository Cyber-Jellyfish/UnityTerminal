#if UNITY_EDITOR
using System;
using System.Threading.Tasks;
using UnityEditor;

namespace UnityTerminal
{
    /// <summary>
    /// You can add your custom Command Prompt Processes here with a MenuItem Attribute.<br/>
    ///<br/>
    /// For simple processes use the ProcessUtilities.StartProcess(Filename, (optional) runAsAdmin)<br/>
    /// <br/>
    /// For advanced processes use the ProcessUtilities.StartAdvProcess(Filename, (optional) arguments, (optional) hideWindow, (optional) runAsAdmin)<br/>
    ///<br/>
    /// There is an example below to Open a Notepad
    /// </summary>
    public static class CustomCommands
    {
        #region METHODS

        [MenuItem("Window/Example/Notepad")]
        public static async Task Notepad()
        {
            await Task.Run(() => ProcessUtilities.StartProcess("notepad.exe"));
        }

        [MenuItem("Window/Android/ADB/ADB (Start-Server)")]
        public static async Task StartAdbServer()
        {
            await Task.Run(() => ProcessUtilities.StartAdvProcess("adb", @" start-server"));
        }

        [MenuItem("Window/Android/ADB/ADB (Kill-Server)")]
        public static async Task KillAdbServer()
        {
            await Task.Run(() => ProcessUtilities.StartAdvProcess("adb", @" kill-server"));
        }

        [MenuItem("Window/Android/Emulator/SDK Tools")]
        public static async Task OpenAndroidEmulatorFolder()
        {
            await Task.Run(() =>
                ProcessUtilities.StartAdvProcess("explorer.exe", $@"C:\Users\{Environment.UserName}\AppData\Local\Android\Sdk\tools\"));
        }
        
        [MenuItem("Window/Android/Emulator/Pixel_3")]
        public static async Task OpenAndroidEmulator()
        {
            await Task.Run(() => ProcessUtilities.StartAdvProcess("emulator", @"-avd Pixel_3_API_30"));
        }

        [MenuItem("Window/Python/Python Shell")]
        public static async Task OpenPythonShell()
        {
            await Task.Run(() => ProcessUtilities.StartProcess("python", true));
        }

        [MenuItem("Window/Python/IDLE")]
        public static async Task OpenPythonIdle()
        {
            await Task.Run(() => ProcessUtilities.StartAdvProcess("python", @"-m idlelib", true));
        }

        #endregion
    }
}
#endif