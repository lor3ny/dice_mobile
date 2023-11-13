using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    //Private:
    private byte[] score;
    private byte heroesCount = 4;
    private DiceController[] dice;

    //Public:
    public GameObject dicePrefab;
    public Transform[] positions;

    public DiceState currentState = DiceState.Null;

    private void Awake()
    {

        //heroesCount = LevelManager.GetHeroesCount();

        dice = new DiceController[heroesCount];

        for (int i = 0; i < heroesCount; i++)
        {
            GameObject newDice = Instantiate(dicePrefab, positions[i].position, Quaternion.identity);
            newDice.transform.SetParent(this.transform);
            dice[i] = newDice.GetComponent<DiceController>();
            dice[i].Initialize();
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
        UIRoll();

        currentState = DiceState.Rolled;
    }


    private void DiceSelection()
    {
        for(int i = 0;i < dice.Length; i++)
        {
            //dice[i].SetSelectable();
        }
    }



    private void UIRoll()
    {
        if (score.Length == 0)
            return;

        for(int i = 0;i < score.Length;i++) {
            dice[i].SetImage(score[i]);
            Debug.Log(score[i]);   
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

