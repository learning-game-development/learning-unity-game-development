#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DapperDino.BuildingBlocks
{
    [ExecuteInEditMode]
    public class Challenge : MonoBehaviour
    {
        [SerializeField] private int challengeIndex = -1;
        [SerializeField] private string challengeTitle = string.Empty;
        [SerializeField] private string challengeText = string.Empty;

        private void OnEnable()
        {
            EditorApplication.playModeStateChanged += HandleModeStateChange;
        }

        private void OnDisable()
        {
            EditorApplication.playModeStateChanged -= HandleModeStateChange;
        }

        private void Start()
        {
            if (!Application.isPlaying)
            {
                var challengeWindow = EditorWindow.GetWindow<ChallengeEditorWindow>();
                challengeWindow.Init(challengeIndex, challengeTitle, challengeText);
                challengeWindow.Show();
                return;
            }
        }

        private void HandleModeStateChange(PlayModeStateChange obj)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            switch (obj)
            {
                case PlayModeStateChange.EnteredPlayMode:
                    PlayerPrefs.SetInt($"Scene_{sceneIndex}", 0);
                    break;

                case PlayModeStateChange.EnteredEditMode:
                    if (SceneManager.sceneCountInBuildSettings == sceneIndex + 1) { break; }
                    if (!PlayerPrefs.HasKey($"Scene_{sceneIndex}")) { break; }
                    if (PlayerPrefs.GetInt($"Scene_{sceneIndex}") != 1) { break; }

                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                    EditorSceneManager.OpenScene($"Assets/Scenes/Scene_{sceneIndex + 1}.unity");
                    break;
            }
        }
    }
}
#endif
