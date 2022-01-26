using System;
using UnityEngine;

namespace UnityTerminal
{
    [Serializable]
    public class CommandPrompt
    {
        #region VARIABLES

        [Header("Command")]
        public string PromptName = string.Empty;
        public string Filename = string.Empty;
        public string Arguments = string.Empty;

        [Header("Command Properties")]
        public bool RunAsAdmin = false;
        public bool HideWindow = true;

        #endregion
    }
}