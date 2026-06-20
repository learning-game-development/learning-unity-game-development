using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DapperDino.BuildingBlocks
{
    public class TargetHandler : MonoBehaviour
    {
        [SerializeField] private GameObject wellDonePanel = null;
        [SerializeField] private GameObject tryAgainPanel = null;

        private HealthBehaviour playerHealth;
        private List<HealthBehaviour> targets = new List<HealthBehaviour>();

        private void Start()
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<HealthBehaviour>();
            targets = GetComponentsInChildren<HealthBehaviour>().ToList();

            playerHealth.OnDeath += HandlePlayerDeath;

            foreach (var target in targets)
            {
                target.OnDeath += HandleTargetDeath;
            }

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnDestroy()
        {
            if (playerHealth != null)
            {
                playerHealth.OnDeath -= HandlePlayerDeath;
            }

            foreach (var target in targets)
            {
                target.OnDeath -= HandleTargetDeath;
            }
        }

        private void HandlePlayerDeath(HealthBehaviour player)
        {
            player.OnDeath -= HandlePlayerDeath;

            tryAgainPanel.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void HandleTargetDeath(HealthBehaviour target)
        {
            target.OnDeath -= HandleTargetDeath;

            targets.Remove(target);

            if (targets.Count != 0) { return; }

#if UNITY_EDITOR
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt($"Scene_{sceneIndex}", 1);
#endif
            playerHealth.gameObject.SetActive(false);
            wellDonePanel.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void GoToNextLevel()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (SceneManager.sceneCountInBuildSettings == sceneIndex + 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(sceneIndex + 1);
            }          
#endif
        }

        public void TryAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
