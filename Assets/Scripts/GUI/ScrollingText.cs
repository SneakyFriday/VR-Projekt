using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{

    [SerializeField] [TextArea] public string[] itemInfo;
    [SerializeField] private float scrollSpeed = 0.01f;
    [SerializeField] private TMP_Text itemInfoText;
    private int currentItemIndex = 0;

    public void ActivateText()
    {
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        for (int i = 0; i < itemInfo[currentItemIndex].Length; i++)
        {
            itemInfoText.text = itemInfo[currentItemIndex].Substring(0, i);
            yield return new WaitForSeconds(scrollSpeed);
        }
    }
}
