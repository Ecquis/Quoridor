using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallView : MonoBehaviour
{
    static float b = 255f;
    static Color wallTransparentColor = new Color(50f / b, 91f / b, 123f / b, 5f / b);
    static Color wallHoverColor = new Color(50f / b, 91f / b, 123f / b, 100f / b);
    static Color wallColor = new Color(50f / b, 91f / b, 123f / b, 255f / b);

    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        SetColor("transparent");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(string colorStr)
    {
        Debug.Log(rend);
        switch (colorStr)
        {
            case "transparent":
                rend.color = wallTransparentColor;
                break;
            case "hover":
                rend.color = wallHoverColor;
                break;
            case "set":
                rend.color = wallColor;
                break;
        }
        
    }
}
