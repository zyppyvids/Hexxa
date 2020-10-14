using UnityEngine;

public class TypeHolder : MonoBehaviour
{
    // Serialized only to be made available to the inspector for debugging purposes
    [SerializeField] TileType currentType;

    public TileType GetTileType()
    {
        return currentType;
    }

    public void ChangeType(TileType newType)
    {
        currentType = newType;
        TypeController.singleton.OnChangeTileType(gameObject, newType);
    }
}
