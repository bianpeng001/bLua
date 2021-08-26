using UnityEditor;
using UnityEditor.Rendering.Universal;
using UnityEngine;

namespace bLua.Render
{
    [CustomEditor(typeof(StudyRendererData), true)]
    public class StudyRendererDataEditor : ScriptableRendererDataEditor
    {
        private SerializedProperty showShadowMap;
        private GUIContent showShadowMapLabel = new GUIContent("showShadowMap");

        private void OnEnable()
        {
            showShadowMap = serializedObject.FindProperty("showShadowMap");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(showShadowMap, showShadowMapLabel);

            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}
