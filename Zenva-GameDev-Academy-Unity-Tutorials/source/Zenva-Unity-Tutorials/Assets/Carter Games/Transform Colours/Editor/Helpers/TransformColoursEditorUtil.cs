using UnityEditor;
using UnityEngine;

namespace CarterGames.Assets.TransformColours.Editor
{
    /// <summary>
    /// An editor utility class for the asset.
    /// </summary>
    public static class TransformColoursEditorUtil
    {
        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Fields
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        internal static Color Green => new Color32(72, 222, 55, 255);
        internal static Color Yellow => new Color32(245, 234, 56, 255);
        internal static Color Red => new Color32(255, 150, 157, 255);
        internal static Color Blue => new Color32(151, 196, 255, 255);
        internal static Color Hidden = new Color(0, 0, 0, .3f);
        
        private static readonly string StyleSettingPerf = "CarterGames-TransformColours-Use2D";
        private static readonly string ColourPrefPrefix = "CarterGames-TransformColours-";
        
        private const string XColorPerf = "XColour";
        private const string YColorPerf = "YColour";
        private const string ZColorPerf = "ZColour";
        
        private static Texture2D cachedManagerHeaderImg;
        private static Texture2D cachedCarterGamesBannerImg;
        
        private static Color cachedXColour;
        private static Color cachedYColour;
        private static Color cachedZColour;

        public static bool HasPositionSaved;
        public static bool HasRotationSaved;
        public static bool HasScaledSaved;
        
        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Properties
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        public static Texture2D ManagerHeader
        {
            get
            {
                if (cachedManagerHeaderImg != null) return cachedManagerHeaderImg;
                cachedManagerHeaderImg = (Texture2D) GetFile<Texture2D>("TransformColoursEditorHeader");
                return cachedManagerHeaderImg;
            }
        }
        
        public static Texture2D CarterGamesBanner
        {
            get
            {
                if (cachedCarterGamesBannerImg != null) return cachedCarterGamesBannerImg;
                cachedCarterGamesBannerImg = (Texture2D) GetFile<Texture2D>("CarterGamesBanner");
                return cachedCarterGamesBannerImg;
            }
        }

        public static StyleSetting StyleSetting
        {
            get => ConvertBoolToSetting(EditorPrefs.GetBool(StyleSettingPerf));
            set => EditorPrefs.SetBool(StyleSettingPerf, ConvertSettingToBool(value));
        }

        public static Color XColour
        {
            get
            {
                if (cachedXColour.a > 0) return cachedXColour;
                cachedXColour = GetColour(XColorPerf);
                return cachedXColour;
            }
            set
            {
                cachedXColour = value;
                SetColour(value, XColorPerf);
            }
        }
        
        public static Color YColour
        {
            get
            {
                if (cachedYColour.a > 0) return cachedYColour;
                cachedYColour = GetColour(YColorPerf);
                return cachedYColour;
            }
            set
            {
                cachedYColour = value;
                SetColour(value, YColorPerf);
            }
        }
        
        public static Color ZColour
        {
            get
            {
                if (cachedZColour.a > 0) return cachedZColour;
                cachedZColour = GetColour(ZColorPerf);
                return cachedZColour;
            }
            set
            {
                cachedZColour = value;
                SetColour(value, ZColorPerf);
            }
        }

        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Methods
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        private static object GetFile<T>(string filter)
        {
            var asset = AssetDatabase.FindAssets(filter, null);
            var path = AssetDatabase.GUIDToAssetPath(asset[0]);
            return AssetDatabase.LoadAssetAtPath(path, typeof(T));
        }

        private static StyleSetting ConvertBoolToSetting(bool value)
        {
            var intValue = value ? 1 : 0;
            return (StyleSetting) intValue;
        }

        private static bool ConvertSettingToBool(StyleSetting setting)
        {
            return setting == StyleSetting.TwoD;
        }

        public static Color GetColour(string col)
        {
            if (!EditorPrefs.HasKey($"CarterGames-TransformColours-{col}-R"))
            {
                switch (col)
                {
                    case XColorPerf:
                        SetColour(Color.red, XColorPerf);
                        return Color.red;
                    case YColorPerf:
                        SetColour(Color.green, YColorPerf);
                        return Color.green;
                    case ZColorPerf:
                        SetColour(Color.blue, ZColorPerf);
                        return Color.blue;
                }
            }
            
            var _col = new Color
            {
                r = EditorPrefs.GetFloat($"CarterGames-TransformColours-{col}-R"),
                g = EditorPrefs.GetFloat($"CarterGames-TransformColours-{col}-G"),
                b = EditorPrefs.GetFloat($"CarterGames-TransformColours-{col}-B"),
                a = 1
            };
            
            return _col;
        }
        
        private static void SetColour(Color col, string toEdit)
        {
            EditorPrefs.SetFloat($"CarterGames-TransformColours-{toEdit}-R", col.r);
            EditorPrefs.SetFloat($"CarterGames-TransformColours-{toEdit}-G", col.g);
            EditorPrefs.SetFloat($"CarterGames-TransformColours-{toEdit}-B", col.b);
            cachedXColour = GetColour(XColorPerf);
            cachedYColour = GetColour(YColorPerf);
            cachedZColour = GetColour(ZColorPerf);
        }

        internal static void RefreshColoursSave()
        {
            if (GetColour(XColorPerf) != cachedXColour)
                SetColour(cachedXColour, XColorPerf);
            
            if (GetColour(YColorPerf) != cachedYColour)
                SetColour(cachedYColour, YColorPerf);
            
            if (GetColour(ZColorPerf) != cachedZColour)
                SetColour(cachedZColour, ZColorPerf);
        }

        internal static void ResetColoursToDefault()
        {
            SetColour(EditorGUIUtility.isProSkin ? AssetDefaults.Dark_X : AssetDefaults.Light_X, XColorPerf);
            SetColour(EditorGUIUtility.isProSkin ? AssetDefaults.Dark_Y : AssetDefaults.Light_Y, YColorPerf);
            SetColour(EditorGUIUtility.isProSkin ? AssetDefaults.Dark_Z : AssetDefaults.Light_Z, ZColorPerf);
        }
    }
}