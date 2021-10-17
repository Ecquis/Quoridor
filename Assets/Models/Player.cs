using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int x, y;
    public int wallsSet;
    public const int wallsMax = 10;
    public int Id;
    private int OpositeId;
    public int WinPosition;
    private int[,] field;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private int steps = 0;

    public bool HaveWinWay()
    {
        field = new int[Constants.ARRAY_SIZE, Constants.ARRAY_SIZE];
        steps = 0;
        checkCell(x, y);
        string s = "";
        for (int ix = 0; ix < Constants.ARRAY_SIZE; ix ++) {
            for (int iy = 0; iy < Constants.ARRAY_SIZE; iy ++) {
                s += field[ix, iy] + " ";
            }
            s = s + "\n";
        }
        Debug.Log(s);
        for (int i = 0; i < Constants.ARRAY_SIZE; i ++) {
            if (field[i, WinPosition] == 1) { 
                return true;
            }
        }
        return false;
    }

    void checkCell(int x, int y) {
        if (!((0 <= x && x < Constants.ARRAY_SIZE) && (0 <= y && y < Constants.ARRAY_SIZE))) { return; }
        if (field[x, y] != 0) { return; }
        if (Game.gameArray[x, y] == Constants.WALL_ID) {
            field[x, y] = -1;
        } else {
            field[x, y] = 1;
            if (Game.gameArray[Game.limit(x + 1), y] != Constants.WALL_ID) {
                checkCell(x + 1, y);
            }
            if (Game.gameArray[Game.limit(x - 1), y] != Constants.WALL_ID) {
                checkCell(x - 1, y);
            }
            if (Game.gameArray[x, Game.limit(y + 1)] != Constants.WALL_ID) {
                checkCell(x, y + 1);
            }
            if (Game.gameArray[x, Game.limit(y - 1)] != Constants.WALL_ID) {
                checkCell(x, y - 1);
            }
        }
    }

    // bool fieldHasUnprocessedCells() {
    //     for (int ix = 0; ix < Constants.ARRAY_SIZE; ix += 2) {
    //         for (int iy = 0; iy < Constants.ARRAY_SIZE; iy += 2) {
    //             if (field[ix, iy] == Constants.FIELD_ID) {
    //                 return true;
    //             }
    //         }
    //     }
    //     return false;
    // }

    // public void MarkField(int x, int y, int loop)
    // {
    //     loop += 1;
    //     if (loop > 100) {
    //         Application.Quit();
    //     }
    //     Debug.Log(x + " " + y);
    //     if ((0 <= x && x < Constants.ARRAY_SIZE) && (0 <= y && y < Constants.ARRAY_SIZE))
    //     {
    //         var isXInField = x % 2 == 0;
    //         var isYInField = y % 2 == 0;
    //         Debug.Log(isXInField + " " + isYInField);
    //         if (isXInField && isYInField)
    //         {
    //             if (_winWays.ContainsKey(new KeyValuePair<int, int>(x, y)))
    //             {
    //                 _winWays.Add(new KeyValuePair<int, int>(x, y), step);
    //                 step++;
    //             }
    //             MarkField(x + 1, y, loop);
    //             MarkField(x - 1, y, loop);
    //             MarkField(x, y + 1, loop);
    //             MarkField(x, y - 1, loop);
    //         }
    //         else if (isXInField)
    //         {
    //             MarkField(x, y + 1, loop);
    //             MarkField(x, y - 1, loop);
    //         }
    //         else if (isYInField)
    //         {
    //             MarkField(x + 1, y, loop);
    //             MarkField(x - 1, y, loop);
    //         }
    //     }
    // }
}
