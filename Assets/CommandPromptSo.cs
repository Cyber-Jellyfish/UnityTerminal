using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Command Prompt", fileName = "CommandPrompts", order = 81)]
    public class CommandPromptSo : ScriptableObject
    {
        #region VARIABLES

        [Header("Command Prompts")]
        public List<CommandPrompt> CommandPrompts = new List<CommandPrompt>();

        #endregion
    }
}