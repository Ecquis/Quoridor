using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int x, y;
    bool isSet;
    bool isAvailable;

    WallView wallView;
    // Start is called before the first frame update
    void Start()
    {
        wallView = GetComponent<WallView>();
        isAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (isSet || !isAvailable) { return; }
        wallView.SetColor("hover");
    }

    void OnMouseExit()
    {
        if (isSet || !isAvailable) { return; }
        wallView.SetColor("transparent");
    }

    void OnMouseDown()
    {
        if (isSet) { return; }
        isSet = true;
        wallView.SetColor("set");
    }

    public void setAvailable(bool isAvailable)
    {
        this.isAvailable = isAvailable;
    }

    public bool getAvailable()
    {
        return isAvailable;
    }
}
