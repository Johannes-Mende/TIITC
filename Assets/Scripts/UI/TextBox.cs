using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    public GameObject textBox;
    public TextMeshProUGUI textBox_txt;
    public float timeBetweenLetters;

    [TextArea]
    public string textToWrite;

    int textIndex;

    public IEnumerator WriteTextLetters(string text)
    {
        textIndex = 0;
        textBox.SetActive(true);
        while (textIndex < text.Length)
        {
            string writeText = text.Substring(0, textIndex) + "<color=#00000000>" + text.Substring(textIndex) + "</color>";
            textBox_txt.text = writeText;
            textIndex++;
            yield return new WaitForSeconds(timeBetweenLetters);
        }

        yield return new WaitForSeconds(5f);
        textBox.SetActive(false);
        
        yield return null;
    }

    
}
