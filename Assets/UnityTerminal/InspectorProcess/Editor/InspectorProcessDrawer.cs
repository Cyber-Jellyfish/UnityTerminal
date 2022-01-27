#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace UnityTerminal
{
    /// <summary>
    /// Work in Progress
    /// </summary>
    [CustomPropertyDrawer(typeof(InspectorProcess))]
    public class InspectorProcessDrawer : PropertyDrawer
    {
        #region VARIABLES

        #endregion

        #region UNITY METHODS

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }

        #endregion

        #region METHODS

        #endregion
    }
}
#endif