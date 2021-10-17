using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    static float b = 255f;
    static Color cellColor = new Color(239f / b, 238f / b, 238f / b, 255f / b);
    static Color cellHoverColor = new Color(139f / b, 138f / b, 138f / b, 255f / b);

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public void SetColor(string colorStr)
    {
        switch (colorStr)
        {
            case "regular":
                rend.color = cellColor;
                break;
            case "hover":
                rend.color = cellHoverColor;
                break;
        }
    }
}
