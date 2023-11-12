using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{


    //Private:

    
    //Public:
    public Sprite[] images;

    public void SetImage(int index)
    {
        index--;

        if (index > images.Length - 1)
            return;

        gameObject.GetComponent<Image>().sprite = images[index];
    }
}
