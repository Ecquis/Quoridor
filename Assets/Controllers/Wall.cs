using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    public int x, y;
    public bool isVertical;
    bool isSet;

    WallView wallView;
    // Start is called before the first frame update
    void Start()
    {
        wallView = GetComponent<WallView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (!isAvailableToSet() || !Game.isGameRunning()) { return; }
        wallView.SetColor("hover");
    }

    void OnMouseExit()
    {
        if (!isAvailableToSet() || !Game.isGameRunning()) { return; }
        wallView.SetColor("transparent");
    }

    void OnMouseDown()
    {
        if (!isAvailableToSet() || !Game.isGameRunning()) { return; }

        Game.gameArray[x, y] = Constants.WALL_ID;
        if (isVertical)
        {
            Game.gameArray[x, y + 1] = Constants.WALL_ID;
            Game.gameArray[x, y + 2] = Constants.WALL_ID;
        }
        else
        {
            Game.gameArray[x + 1, y] = Constants.WALL_ID;
            Game.gameArray[x + 2, y] = Constants.WALL_ID;
        }
        isSet = true;
        wallView.SetColor("set");
        Game.printField();

        Player currentPlayerModel = Game.currentPlayer.GetComponent<Player>();
        if (currentPlayerModel.Id == Constants.PLAYER1_ID)
        {
            Game.player1Walls.GetComponent<Text>().text = Constants.PLAYER1_STRING + ": " + currentPlayerModel.wallsSet;
        }
        else
        {
            Game.player2Walls.GetComponent<Text>().text = Constants.PLAYER2_STRING + ": " + currentPlayerModel.wallsSet;
        }
        
        PlayerController currentPlayerController = Game.currentPlayer.GetComponent<PlayerController>();
        int walls = currentPlayerController.incWall();
        
        if (currentPlayerModel.Id == Constants.PLAYER1_ID)
        {
            Game.player1Walls.GetComponent<Text>().text = Constants.PLAYER1_STRING + ": " + ( 10 - walls );
        }
        else
        {
            Game.player2Walls.GetComponent<Text>().text = Constants.PLAYER2_STRING + ": " + ( 10 - walls );
        }
        
        Debug.Log(Game.currentPlayer.name + " sets wall #" + walls);
        Game.SwitchPlayer();
    }

    bool isAvailableToSet()
    {

        if (isSet) { return false; }

        if (Game.gameArray[x, y] == Constants.WALL_ID) { return false; }
        if (this.isVertical)
        {
            if (Game.gameArray[x, y + 1] == Constants.WALL_ID) { return false; }
            if (Game.gameArray[x + 1, y + 1] == Constants.WALL_ID && Game.gameArray[x - 1, y + 1] == Constants.WALL_ID) { return false; }
            if (Game.gameArray[x, y + 2] == Constants.WALL_ID) { return false; }
        } else
        {
            if (Game.gameArray[x + 1, y] == Constants.WALL_ID) { return false; }
            if (Game.gameArray[x + 1, y + 1] == Constants.WALL_ID && Game.gameArray[x + 1, y - 1] == Constants.WALL_ID) { return false; }
            if (Game.gameArray[x + 2, y] == Constants.WALL_ID) { return false; }
        }

        Player currentPlayerModel = Game.currentPlayer.GetComponent<Player>();
        if (currentPlayerModel.wallsSet >= Player.wallsMax) { return false; }

        return true;
    }
}
