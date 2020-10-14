using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private int currentRow = 0;

    // Tile types:
    // 1 - Strong oponent tile / Oponent tile,
    // 2 - Shop tile,
    // 3 - Fountain tile
    public List<int> tileTypes = new List<int>
    {
        2,
        2,      // Shops
        2,

        3,      // Fountains
        3,

        1,1,1,1,0,0,0,0,0,0,0,0     // Oponents (1 - Strong oponent, 0 - Mid Oponent)
    };

    [HideInInspector]
    public int CurrentRow
    {
        get
        {
            return currentRow;
        }
        set
        {
            if (value < RowController.singleton.GetRowCount())
            {
                currentRow = value;
            }
            else
            {
                Debug.LogError("Trying to assign value to 'currentRow' higher that 'rows' length!");
            }
        }
    }

    private void Awake()
    {   
        singleton = this;
    }
}
