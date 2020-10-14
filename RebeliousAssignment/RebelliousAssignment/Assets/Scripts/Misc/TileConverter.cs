public static class TileConverter
{
    public static TileType FromIntToType(int input)
    {
        switch (input)
        {
            case 0:
                return TileType.Oponent;
            case 1:
                return TileType.StrongOponent;
            case 2:
                return TileType.Shop;
            case 3:
                return TileType.Fountain;
            default:
                return TileType.Default;
        }
    }

    public static int FromTypeToInt(TileType input)
    {
        switch (input)
        {
            case TileType.Oponent:
                return 0;
            case TileType.StrongOponent:
                return 1;
            case TileType.Shop:
                return 2;
            case TileType.Fountain:
                return 3;
            default:
                return -1;
        }
    }
}
