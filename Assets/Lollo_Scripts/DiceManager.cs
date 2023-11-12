using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    //Private:
    private byte[] score;
    private byte heroesCount = 4;
    private DiceController[] dices;

    //Public:
    public GameObject dicePrefab;
    public Transform[] positions;

    private void Awake()
    {

        //heroesCount = LevelManager.GetHeroesCount();

        dices = new DiceController[heroesCount];

        for (int i = 0; i < heroesCount; i++)
        {
            GameObject newDice = Instantiate(dicePrefab, positions[i].position, Quaternion.identity);
            newDice.transform.SetParent(this.transform);
            dices[i] = newDice.GetComponent<DiceController>();
        }
    }

    public void Roll()
    {

        //Random Generation
        score = new byte[heroesCount];

        for(int i = 0; i < heroesCount; i++)
        {
            score[i] = (byte) Random.Range(0,7);    
        }


        //UI Animation
        UIRoll();
    }

    private void UIRoll()
    {
        if (score.Length == 0)
            return;

        for(int i = 0;i < score.Length;i++) {
            dices[i].SetImage(score[i]);
            Debug.Log(score[i]);   
        }
    }
}
