using UnityEngine;

public class Oponent : MonoBehaviour
{
    public int PowerPoints;

    private System.Random RNG; // Random Number Generator - System class

    private void Awake()
    {
        RNG = new System.Random();

        int currentPowerPoints = gameObject.GetComponent<TypeHolder>().GetTileType() == TileType.Oponent
            ? RNG.Next(0, 100)
            : RNG.Next(100, 200);

        PowerPoints = currentPowerPoints;
    }
}
