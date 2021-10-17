using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static List<List<GameObject>> gameObjects = new List<List<GameObject>>();
    public static int[,] gameArray;
    public static int limit(int num)
    {
        return Mathf.Max(Mathf.Min(num, Constants.ARRAY_SIZE - 1), 0);
    }

    public GameObject wallObject;
    public GameObject cellObject;
    public GameObject fieldObject;
    public GameObject cellsParentObject;

    public static GameObject currentPlayer;
    public static GameObject oppositePlayer;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = GameObject.Find("Player1");
        oppositePlayer = GameObject.Find("Player2");
        gameArray = new int[Constants.ARRAY_SIZE, Constants.ARRAY_SIZE];
        for (int ix = 0; ix < Constants.ARRAY_SIZE; ix++)
        {
            gameObjects.Add(new List<GameObject>());
            for (int iy = 0; iy < Constants.ARRAY_SIZE; iy++)
            {
                gameObjects[ix].Add(null);
            }
        }

        FieldView fieldView = new FieldView();
        fieldView.InitField(cellsParentObject, cellObject, wallObject);
        gameArray[8, 16] = Constants.PLAYER1_ID;
        gameArray[8, 0] = Constants.PLAYER2_ID;
        printField();

        Player currentPlayerModel = currentPlayer.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void printField()
    {
        string s = "";
        for (int ix = Constants.ARRAY_SIZE - 1; ix >= 0; ix --)
        {
            for (int iy = 0; iy < Constants.ARRAY_SIZE; iy++)
            {
                string symbol = " ";
                switch (Game.gameArray[iy, ix])
                {
                    case 0: symbol = "o"; break;
                    case 1: symbol = "a"; break;
                    case 4: symbol = "b"; break;
                    case 2: symbol = "p"; break;
                    case 3: symbol = "q"; break;
                }
                s = s + symbol + " ";
                //s = s + "(" + ix + "," + iy + "," + symbol + ") ";
            }
            s = s + "\n";
        }
        Debug.Log(s);
    }

    public static void SwitchPlayer() {
        GameObject temp = currentPlayer;
        currentPlayer = oppositePlayer;
        oppositePlayer = temp;
    }
}
