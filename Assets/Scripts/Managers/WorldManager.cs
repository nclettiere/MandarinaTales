using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class WorldManager : MonoBehaviour
    {
        private bool sceneLoaded;
        private int currentScene;

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void ShowGameOverScene(float delay = 0)
        {
            const string sceneName = "GameOver";
            //GameManager.GM.Nivel1Camera.gameObject.SetActive(false);
            //GameManager.GM.Nivel1EventSystem.gameObject.SetActive(false);
            StartCoroutine(LoadScene(sceneName, delay, false));
        }
        
        public void ShowNivel1(float delay = 0)
        {
            const string sceneName = "Nivel1";
            StartCoroutine(LoadScene(sceneName, delay));
        }

        private IEnumerator LoadScene(string sceneName, float delay = 0, bool additive = false)
        {
            if (delay > 0f)
                yield return new WaitForSeconds(delay);
            
            SceneManager.LoadSceneAsync(sceneName, additive ? LoadSceneMode.Additive : LoadSceneMode.Single);

            yield return new WaitUntil(() => sceneLoaded);

            sceneLoaded = false;

            GameManager.GM.SearchManagers();

            yield return null;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            sceneLoaded = true;
            currentScene = scene.buildIndex;
        }
    }
}