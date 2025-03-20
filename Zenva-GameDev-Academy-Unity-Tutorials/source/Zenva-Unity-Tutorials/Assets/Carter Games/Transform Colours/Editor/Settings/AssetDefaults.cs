using UnityEngine;

namespace CarterGames.Assets.TransformColours.Editor
{
    /// <summary>
    /// Holds the data for the default colour values per theme.
    /// </summary>
    public static class AssetDefaults
    {
        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Fields
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        public static Color Light_X = new Color(0.92f, 0.75f, 0.75f, 1f);
        public static Color Light_Y = new Color(0.76f, 1f, 0.76f, 1f);
        public static Color Light_Z = new Color(0.71f, 0.82f, 1f, 1f);
        public static Color Dark_X = Color.red;
        public static Color Dark_Y = Color.green;
        public static Color Dark_Z = Color.blue;
    }
}