using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldView: MonoBehaviour
{

    public void InitField(GameObject field, GameObject cellObject, GameObject wallObject)
    {
        // generate cells
        for (int indexX = 0; indexX < Constants.FIELD_SIZE; indexX ++)
        {
            for (int indexY = 0; indexY < Constants.FIELD_SIZE; indexY ++)
            {
                float x = 0.1f + 1.5f * indexX;
                float y = 0.1f + 1.5f * indexY;
                GameObject cell = GameObject.Instantiate(cellObject, new Vector3(-6.1f + x, -6.1f + y, 0), Quaternion.identity, field.transform);
                Cell cellScript = cell.GetComponent<Cell>();
                cellScript.x = indexX * 2;
                cellScript.y = indexY * 2;
                Game.gameObjects[cellScript.x][cellScript.y] = cell;
            }
        }
        // generate walls

        for (int indexX = 0; indexX < Constants.FIELD_SIZE - 1; indexX++)
        {
            for (int indexY = 0; indexY < Constants.FIELD_SIZE - 1; indexY++)
            {
                float x = 1.25f + 1.5f * indexX;
                float y = 1.25f + 1.5f * indexY;

                GameObject wallV = GameObject.Instantiate(wallObject, new Vector3(-6.5f + x, -6.5f + y, 0), Quaternion.identity, field.transform);

                Wall wallVScript = wallV.GetComponent<Wall>();
                wallVScript.x = indexX * 2 + 1;
                wallVScript.y = indexY * 2;
                Game.gameObjects[wallVScript.x][wallVScript.y] = wallV;
                wallVScript.isVertical = true;


                GameObject wallH = GameObject.Instantiate(wallObject, new Vector3(-6.5f + x, -6.5f + y, 0), Quaternion.identity, field.transform);
                wallH.transform.Rotate(new Vector3(0, 0, 90));

                Wall wallHScript = wallH.GetComponent<Wall>();
                wallHScript.x = indexX * 2;
                wallHScript.y = indexY * 2 + 1;
                Game.gameObjects[wallHScript.x][wallHScript.y] = wallH;
                wallHScript.isVertical = false;
            }
        }
    }
}
