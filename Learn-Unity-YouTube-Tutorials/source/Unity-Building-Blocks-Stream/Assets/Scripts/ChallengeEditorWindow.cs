#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DapperDino.BuildingBlocks
{
    public class ChallengeEditorWindow : EditorWindow
    {
        private int challengeIndex;
        private string challengeTitle;
        private string challengeText;

        public void Init(int challengeIndex, string challengeTitle, string challengeText)
        {
            this.challengeIndex = challengeIndex;
            this.challengeTitle = challengeTitle;
            this.challengeText = challengeText;
        }

        private void OnGUI()
        {
            var titleTextLabelStyle = new GUIStyle(GUI.skin.label)
            {
                alignment = TextAnchor.UpperCenter,
                wordWrap = true,
                fontSize = 30,
                fontStyle = FontStyle.Bold
            };
            EditorGUILayout.LabelField($"Challenge {challengeIndex}: {challengeTitle}\n", titleTextLabelStyle);

            var challengeTextLabelStyle = new GUIStyle(GUI.skin.label)
            {
                alignment = TextAnchor.UpperCenter,
                wordWrap = true,
                fontSize = 20
            };
            EditorGUILayout.LabelField($"For this challenge you will learn how to:\n\n{challengeText}", challengeTextLabelStyle);
        }
    }
}
#endif
