using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider slider;
    AsyncOperation async;

    public void LoadSceneEx(int load)
    {
        StartCoroutine(LoadingScreen(load));
    }

    IEnumerator LoadingScreen(int stage)
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(stage);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 50f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
