using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    //Private:
    private byte[] score;
    private byte heroesCount = 4;
    private DiceController[] dice;
    private byte diceSelectedIndex;

    //Public:
    public GameObject dicePrefab;
    public Transform[] positions;
    public DiceState currentState = DiceState.Null;

    private void Awake()
    {

        //heroesCount = LevelManager.GetHeroesCount();

        dice = new DiceController[heroesCount];

        for (byte i = 0; i < heroesCount; i++)
        {
            GameObject newDice = Instantiate(dicePrefab, positions[i].position, Quaternion.identity);
            newDice.transform.SetParent(this.transform);
            dice[i] = newDice.GetComponent<DiceController>();
            dice[i].Initialize(i);
        }

        currentState = DiceState.Unrolled;
    }

    public void Roll()
    {

        if (currentState != DiceState.Unrolled)
            return;

        //Random Generation
        score = new byte[heroesCount];

        for(int i = 0; i < heroesCount; i++)
        {
            score[i] = (byte) Random.Range(0,7);    
        }

        //UI Animation
        for (int i = 0; i < score.Length; i++)
        {
            dice[i].SetImage(score[i]);
            dice[i].SetAvailable();
            Debug.Log(score[i]);
        }

        currentState = DiceState.Rolled;
    }


    public void DiceSelection(byte diceID)
    {
        for(int i = 0;i < dice.Length; i++)
        {
            if(i == diceID)
            {
                dice[i].SetSelected();
                diceSelectedIndex = diceID;
            } else
            {
                dice[i].SetAvailable();
            }
        }
    }

    public enum DiceState
    {
        Null,
        Unrolled,
        Rolled,
        Selected,
    }

}

