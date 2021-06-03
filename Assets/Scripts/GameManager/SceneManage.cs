using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine("LoadNextSceneAsync", 1);
    }

    public IEnumerator LoadNextSceneAsync(int index)
    {

        //yield return new WaitForSeconds(.1f);
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.allowSceneActivation = false;

        while (async.progress < .9f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        async.allowSceneActivation = true;

        yield return null;

        
    }
}
