using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static List<List<GameObject>> gameObjects = new List<List<GameObject>>();
    public static int[,] gameArray;

    public GameObject wallObject;
    public GameObject cellObject;
    public GameObject player1Object;
    public GameObject player2Object;
    public GameObject fieldObject;
    public GameObject cellsParentObject;
    // Start is called before the first frame update
    void Start()
    {
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
        for (int ix = 0; ix < Constants.ARRAY_SIZE; ix ++)
        {
            string s = "";
            for (int iy = 0; iy < Constants.ARRAY_SIZE; iy++)
            {
                s = s + gameArray[ix, iy] + " ";
            }
            Debug.Log(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
