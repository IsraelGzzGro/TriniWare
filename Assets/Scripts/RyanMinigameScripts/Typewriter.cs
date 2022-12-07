using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour
{
  [SerializeField] private float typeWriterSpeed = 50f;
    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
       return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        float r = 0;
        int charIndex = 0;

        while(charIndex < textToType.Length)
        {
            r += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(r);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
