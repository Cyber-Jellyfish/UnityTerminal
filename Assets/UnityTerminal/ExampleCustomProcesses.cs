#if UNITY_EDITOR
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace UnityTerminal
{
    /// <summary>
    /// Example of Custom Processes that you can create and Execute within the Unity Editor using the MenuItem Attribute.<br/>
    ///<br/>
    /// For simple processes use the ProcessUtilities.StartProcess(Filename, (optional) runAsAdmin)<br/>
    /// <br/>
    /// For advanced processes use the ProcessUtilities.StartAdvProcess(Filename, (optional) arguments, (optional) hideWindow, (optional) runAsAdmin)<br/>
    ///<br/>
    /// For your own custom processes use the System.Diagnostic Process. 
    ///<br/>
    /// </summary>
    public static class ExampleCustomProcesses
    {
        #region METHODS

        [MenuItem("Window/Example/Notepad")]
        public static async Task Notepad_StartProcess()
        {
            await Task.Run(() => ProcessUtilities.StartProcess("notepad.exe"));
        }
        
        [MenuItem("Window/Example/Echo Advanced")]
        public static async Task Echo_StartAdvProcess()
        {
            await Task.Run(() => ProcessUtilities.StartAdvProcess("cmd.exe", "/k echo hello, world"));
        }

        [MenuItem("Window/Example/Custom Echo Advanced")]
        public static async Task Echo_CustomProcess()
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

        #endregion
    }
}
#endif