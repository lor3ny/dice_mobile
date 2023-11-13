using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    //Private:

    
    //Public:
    public Sprite[] images;
    private Button diceButton;


    public void Initialize()
    {
        //diceButton.onClick.AddListener(empty);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
    }


    public void empty()
    {
        return;
    }

    public void SetImage(int index)
    {
        index--;

        if (index > images.Length - 1)
            return;

        gameObject.GetComponent<Image>().sprite = images[index];
    }
}
