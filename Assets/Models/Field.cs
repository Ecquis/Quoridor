using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public int[,] field = new int[Constants.FIELD_SIZE, Constants.FIELD_SIZE];
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeField()
    {
        for (int i = 0; i < field.Length; i++)
        {
            for (int j = 0; j < field.Length; j++)
            {
                field[i, j] = Constants.FIELD_ID;
            }
        }

        field[8, 0] = Constants.PLAYER1_ID;
        field[8, 16] = Constants.PLAYER2_ID;
    }
}
