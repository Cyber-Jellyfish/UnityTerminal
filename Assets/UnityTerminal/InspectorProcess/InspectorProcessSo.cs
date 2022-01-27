using System.Collections.Generic;
using UnityEngine;

namespace UnityTerminal
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Inspector Process", fileName = "InspectorProcessSo", order = 81)]
    public class InspectorProcessSo : ScriptableObject
    {
        #region VARIABLES

        [Header("Important Notice")]
        [TextArea]
        public string _ =
            "This is a Work in Progress. Please use the CustomProcess Script or create your own Scripts with custom Processes";

        [Header("Custom Processes")]
        public List<InspectorProcess> Processes = new List<InspectorProcess>();

        #endregion
    }
}