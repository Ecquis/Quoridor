using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (!isAvailableToSet()) { return; }
        wallView.SetColor("hover");
    }

    void OnMouseExit()
    {
        if (!isAvailableToSet()) { return; }
        wallView.SetColor("transparent");
    }

    void OnMouseDown()
    {
        if (!isAvailableToSet()) { return; }

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
        Debug.Log(this.x + " " + this.y);
        wallView.SetColor("set");
        Game.printField();


    }

    bool isAvailableToSet()
    {
        if (isSet) { return false; }

        if (Game.gameArray[x, y] == Constants.WALL_ID) { Debug.Log(1);  return false; }
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

        return true;
    }
}
