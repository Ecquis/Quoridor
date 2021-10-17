using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Player playerModel;
    // Start is called before the first frame update
    void Start()
    {
        playerModel = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int x, int y, bool isRandom = false)
    {
        Debug.Log(gameObject.name + " moves (" + x + " " + y + ")");
        float xv = 0.1f + 1.5f * (x / 2);
        float yv = 0.1f + 1.5f * (y / 2);
        gameObject.transform.position = new Vector3(-6.1f + xv, -6.1f + yv, 0);
        Game.gameArray[playerModel.x, playerModel.y] = Constants.FIELD_ID;
        playerModel.x = x;
        playerModel.y = y;
        Game.gameArray[x, y] = playerModel.Id;

        if (y == playerModel.WinPosition) { 
            Debug.Log(Game.currentPlayer.name + " wins!");
            Game.whoseMove.GetComponent<Text>().text =  Game.currentPlayer.name + " wins!";
            Game.Stop();
            GameObject.Find("ExitButton").transform.localScale = new Vector3(1, 1, 1);
            return; 
        }

        Game.SwitchPlayer();    
        Game.whoseMove.GetComponent<Text>().text = Game.currentPlayer.name + " turn";
        Game.printField();

        // if (Shared.mode == "bot" && !isRandom) {
        //     RandomMove(x, y);
        // }
    }

    void RandomMove(int x, int y) {
    }

    public int incWall() {
        Player playerModel = GetComponent<Player>();
        playerModel.wallsSet += 1;
        return playerModel.wallsSet;
    }
}
