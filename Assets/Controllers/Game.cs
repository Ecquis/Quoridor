using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public static GameObject player1Walls;
    public static GameObject player2Walls;
    public static GameObject whoseMove;

    public static string status;
    // Start is called before the first frame update
    void Start()
    {
        status = "game";
        currentPlayer = GameObject.Find("Player1");
        oppositePlayer = GameObject.Find("Player2");
        player1Walls = GameObject.Find("Player1Walls");
        player2Walls = GameObject.Find("Player2Walls");
        player1Walls.GetComponent<Text>().text = Constants.PLAYER1_STRING + ": " + Constants.WALLS;
        player2Walls.GetComponent<Text>().text = Constants.PLAYER2_STRING + ": " + Constants.WALLS;
        whoseMove = GameObject.Find("WhoseMove");
        whoseMove.GetComponent<Text>().text = Constants.PLAYER1_STRING;
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
        Game.whoseMove.GetComponent<Text>().text = Game.whoseMove.GetComponent<Text>().text == Constants.PLAYER1_STRING
            ? Constants.PLAYER2_STRING
            : Constants.PLAYER1_STRING;
    }

    public static void Stop() {
        status = "stop";
    }

    public static bool isGameRunning() {
        return status == "game";
    }
}
