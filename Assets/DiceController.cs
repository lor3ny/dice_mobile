using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{


    //Private:
    private enum State { Selected, Unrolled, Available }
    private Button diceButton;
    private State state;
    private DiceManager manager;
    private byte ID;

    //Public:
    public Sprite[] images;

    public void Initialize(byte IDvalue)
    {
        this.state = State.Unrolled;
        this.manager = GetComponentInParent<DiceManager>();
        this.ID = IDvalue;

    }
   
    public void OnPointerClick(PointerEventData eventData)
    {
        if (state != State.Available)
            return;

        manager.DiceSelection(ID);
        gameObject.GetComponent<Image>().color = Color.green;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (state != State.Available)
            return;

        gameObject.GetComponent<Image>().color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (state != State.Available)
            return;

        gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
    }

    public void SetImage(int index)
    {
        index--;

        if (index > images.Length - 1)
            return;

        gameObject.GetComponent<Image>().sprite = images[index];
    }


    public void SetSelected()
    {
        this.state = State.Selected;
        gameObject.GetComponent<Image>().color = Color.green;
    }

    public void SetAvailable()
    {
        this.state = State.Available;
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

}
