using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class TypeGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] rowTiles;

    private bool hasShop = false;
    private bool hasFountain = false;

    private System.Random RNG; // Random Number Generator - System class

    private void Awake()
    {
        RNG = new System.Random();

        GenerateTileTypes();
    }

    public void GenerateTileTypes()
    {
        foreach (GameObject tile in rowTiles)
        {
            List<int> tileSelection = GameManager.singleton.tileTypes;

            if (hasShop)
            {
                tileSelection = tileSelection.Where(x => x != TileConverter.FromTypeToInt(TileType.Shop)).ToList();
            }

            if (hasFountain)
            {
                tileSelection = tileSelection.Where(x => x != TileConverter.FromTypeToInt(TileType.Fountain)).ToList();
            }

            TileType currentTile = GetRandomTypeFromSelection(tileSelection);
            
            tile.GetComponent<TypeHolder>().ChangeType(currentTile);
        }
    }

    private TileType GetRandomTypeFromSelection(List<int> tileSelection)
    {
        int currentIndex = RNG.Next(0, tileSelection.Count);
        int currentTileInt = tileSelection[currentIndex];

        GameManager.singleton.tileTypes.Remove(currentTileInt);
        TileType currentTile = TileConverter.FromIntToType(currentTileInt);

        if (currentTile == TileType.Shop)
        {
            hasShop = true;
        }
        else if (currentTile == TileType.Fountain)
        {
            hasFountain = true;
        }

        return currentTile;
    }
}
