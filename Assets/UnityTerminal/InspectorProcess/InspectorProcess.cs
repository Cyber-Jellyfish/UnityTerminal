using System;
using UnityEngine;

namespace UnityTerminal
{
    [Serializable]
    public class InspectorProcess
    {
        #region VARIABLES

        [Header("Command")]
        public string ProcessName = string.Empty;
        public string Filename = string.Empty;
        public string Arguments = string.Empty;

        [Header("Command Properties")]
        public bool RunAsAdmin = false;
        public bool HideWindow = true;

        #endregion
    }
}