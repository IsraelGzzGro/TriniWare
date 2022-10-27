using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _texty;
    public string[] stringArray;
    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;
    int i = 0;
    
    void Start()
    {
        EndCheck();
    }

    void EndCheck() 
    {
        if(i <= stringArray.Length -1) 
        {
            _texty.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible() 
    {
        _texty.ForceMeshUpdate();
        int totalVisibleCharacters = _texty.textInfo.characterCount;
        int counter = 0;

        while(true) 
        {
            int visibleCount = counter % (totalVisibleCharacters +1);
            _texty.maxVisibleCharacters = visibleCount;

            if(visibleCount >= totalVisibleCharacters) 
            {
                i += 1;
                Invoke("EndCheck", timeBtwnWords);
                break;
            }

            counter += 1;
            yield return new WaitForSeconds(timeBtwnChars);
        }
    }

}
