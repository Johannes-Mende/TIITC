using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public GameObject title;
    public GameObject[] buttons;

    private void Start()
    {
        StartCoroutine("FadeInTitle");
    }

    public void StartGame()
    {
        GameObject.Find("SceneManager").GetComponent<SceneManage>().StartCoroutine("LoadNextSceneAsync", 2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void DisplayOptions()
    {
        print("OpenOptions");
    }


    IEnumerator FadeInTitle()
    {
        yield return new WaitForSeconds(2f);

        float cv = 0;

        while (cv < 1)
        {
            cv += .05f;
            title.GetComponent<Image>().color = new Color(255f, 255f, 255f, cv);

            
            yield return null;
        }


        yield return new WaitForSeconds(2f);

        for (int i = 0; i < buttons.Length; i++)
        {
            yield return new WaitForSeconds(.2f);
            StartCoroutine("FadeInButton", buttons[i]);
        }
        
    }

    IEnumerator FadeInButton(GameObject button)
    {
        float cv = 0;

        while (cv < 1)
        {
            cv += .05f;
            button.GetComponent<Image>().color = new Color(255f, 255f, 255f, cv);
            yield return null;
        }
    }


}
