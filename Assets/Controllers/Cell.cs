using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int x, y;
    CellView cellView;
    // Start is called before the first frame update
    void Start()
    {
        cellView = GetComponent<CellView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (!isAvailableToStep() || !Game.isGameRunning()) { return; }
        cellView.SetColor("hover");

    }

    void OnMouseExit()
    {
        cellView.SetColor("regular");
    }

    void OnMouseDown()
    {
        if (!isAvailableToStep() || !Game.isGameRunning()) { return; }
        Game.currentPlayer.GetComponent<PlayerController>().Move(x, y);
        Player oppositePlayer = Game.oppositePlayer.GetComponent<Player>();
    }

    static int l(int x) {
        return Game.limit(x);
    }
    bool isAvailableToStep()
    {
        if (Game.gameArray[x, y] != Constants.FIELD_ID) { return false; }
        int playerId = Game.currentPlayer.GetComponent<Player>().Id;
        int oppositePlayerId = Game.oppositePlayer.GetComponent<Player>().Id;

        // if there are no walls on n, e, s, w
        if (Game.gameArray[l(x - 2), y] == playerId && Game.gameArray[l(x - 1), y] != Constants.WALL_ID) { return true; }
        if (Game.gameArray[l(x + 2), y] == playerId && Game.gameArray[l(x + 1), y] != Constants.WALL_ID) { return true; }
        if (Game.gameArray[x, l(y - 2)] == playerId && Game.gameArray[x, l(y - 1)] != Constants.WALL_ID) { return true; }
        if (Game.gameArray[x, l(y + 2)] == playerId && Game.gameArray[x, l(y + 1)] != Constants.WALL_ID) { return true; }

        

        // if there is a player and no walls
        if (Game.gameArray[l(x - 2), y] == oppositePlayerId && Game.gameArray[l(x - 1), y] != Constants.WALL_ID) {
            if (Game.gameArray[l(x - 2), l(y - 1)] != Constants.WALL_ID && Game.gameArray[l(x - 2), l(y - 2)] == playerId) { return true; }
            if (Game.gameArray[l(x - 2), l(y + 1)] != Constants.WALL_ID && Game.gameArray[l(x - 2), l(y + 2)] == playerId) { return true; }
            if (Game.gameArray[l(x - 3), y] != Constants.WALL_ID && Game.gameArray[l(x - 4), y] == playerId) { return true; }
        }

        if (Game.gameArray[l(x + 2), y] == oppositePlayerId && Game.gameArray[l(x + 1), y] != Constants.WALL_ID) {
            if (Game.gameArray[l(x + 2), l(y - 1)] != Constants.WALL_ID && Game.gameArray[l(x + 2), l(y - 2)] == playerId) { return true; }
            if (Game.gameArray[l(x + 2), l(y + 1)] != Constants.WALL_ID && Game.gameArray[l(x + 2), l(y + 2)] == playerId) { return true; }
            if (Game.gameArray[l(x + 3), y] != Constants.WALL_ID && Game.gameArray[l(x + 4), y] == playerId) { return true; }
        }

        if (Game.gameArray[x, l(y - 2)] == oppositePlayerId && Game.gameArray[x, l(y - 1)] != Constants.WALL_ID) {
            if (Game.gameArray[l(x - 1), l(y - 2)] != Constants.WALL_ID && Game.gameArray[l(x - 2), l(y - 2)] == playerId) { return true; }
            if (Game.gameArray[l(x + 1), l(y - 2)] != Constants.WALL_ID && Game.gameArray[l(x + 2), l(y - 2)] == playerId) { return true; }
            if (Game.gameArray[x, l(y - 3)] != Constants.WALL_ID && Game.gameArray[x, l(y - 4)] == playerId) { return true; }
        }

        if (Game.gameArray[x, l(y + 2)] == oppositePlayerId && Game.gameArray[x, l(y + 1)] != Constants.WALL_ID) {
            if (Game.gameArray[l(x - 1), l(y + 2)] != Constants.WALL_ID && Game.gameArray[l(x - 2), l(y + 2)] == playerId) { return true; }
            if (Game.gameArray[l(x + 1), l(y + 2)] != Constants.WALL_ID && Game.gameArray[l(x + 2), l(y + 2)] == playerId) { return true; }
            if (Game.gameArray[x, l(y + 3)] != Constants.WALL_ID && Game.gameArray[x, l(y + 4)] == playerId) { return true; }
        }

        return false;
    }

}
