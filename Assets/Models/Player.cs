using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyValuePair<int, int> location;
    public int Id;
    private int OpositeId;
    public int WinPosition;
    private int[,] field;
    private readonly Dictionary<KeyValuePair<int, int>, int> _winWays = new Dictionary<KeyValuePair<int, int>, int>();

    public Player(KeyValuePair<int, int> location, int id, int winPosition, int[,] field)
    {
        this.location = location;
        Id = id;
        OpositeId = Id == Constants.PLAYER1_ID ? Constants.PLAYER2_ID : Constants.PLAYER1_ID;
        WinPosition = winPosition;
        this.field = field;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int step = 0;
    
    public bool HaveWinWay()
    {
        step = 0;
        MarkField(location.Key, location.Value);
        return _winWays.Any(field => field.Key.Value == OpositeId);
    }

    public void MarkField(int x, int y)
    {
        if ((0 <= x && x < Constants.ARRAY_SIZE) && (0 <= y && y < Constants.ARRAY_SIZE))
        {
            if (field[x, y] == Constants.FIELD_ID)
            {
                var isXInField = x % 2 == 0;
                var isYInField = y % 2 == 0;
            
                if (isXInField && isYInField)
                {
                    if (_winWays.ContainsKey(new KeyValuePair<int, int>(x, y)))
                    {
                        _winWays.Add(new KeyValuePair<int, int>(x, y), step);
                        step++;
                    }
                    MarkField(x + 1, y);
                    MarkField(x - 1, y);
                    MarkField(x, y + 1);
                    MarkField(x, y - 1);
                } else if (isXInField)
                {
                    MarkField(x, y + 1);
                    MarkField(x, y - 1);
                } else if (isYInField)
                {
                    MarkField(x + 1, y);
                    MarkField(x - 1, y);
                }
            
            } else if (field[x, y] == OpositeId)
            {
                MarkField(x + 2, y);
                MarkField(x - 2, y);
                MarkField(x, y + 2);
                MarkField(x, y - 2);
                MarkField(x + 2, y + 2);
                MarkField(x - 2, y - 2);
                MarkField(x - 2, y + 2);
                MarkField(x + 2, y - 2);
            }
        }
        
        
    }
}
