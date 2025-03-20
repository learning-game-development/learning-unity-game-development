using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CarterGames.Assets.TransformColours.Editor
{
    /// <summary>
    /// Handles drawing the settings window for the asset.
    /// </summary>
    public static class TransformColoursSettings
    {
        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Fields
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        private static Color defaultTextColour;

        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   SettingsProvider
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        [SettingsProvider]
        public static SettingsProvider TransformColoursSettingsProvider()
        {
            var provider = new SettingsProvider("Preferences/Carter Games/Transform Colours", SettingsScope.User)
            {
                guiHandler = (searchContext) =>
                {
                    defaultTextColour = GUI.color;

                    DrawHeader();
                    DrawInfo();
                    DrawSpacer();
                    DrawOptions();
                    DrawSpacer();
                    DrawCustomisations();
                    DrawSpacer();
                    DrawButtons();
                },
                
                keywords = new HashSet<string>(new[] { "Carter Games", "External Assets", "Tools", "Colour", "Transform", "Transform Override", "GUI" })
            };

            return provider;
        }

        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Drawer Methods
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 

        /// <summary>
        /// Draws a spacer.
        /// </summary>
        private static void DrawSpacer()
        {
            GUILayout.Space(2.5f);
        }
        

        /// <summary>
        /// Draws the header.
        /// </summary>
        private static void DrawHeader()
        {
            var managerHeader = TransformColoursEditorUtil.ManagerHeader;
            
            GUILayout.Space(5f);
                    
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
                    
            if (managerHeader != null)
            {
                if (GUILayout.Button(managerHeader, GUIStyle.none, GUILayout.MaxHeight(110)))
                {
                    GUI.FocusControl(null);
                }
            }

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
                    
            GUILayout.Space(5f);
        }
        
        
        /// <summary>
        /// Draws the asset info section.
        /// </summary>
        private static void DrawInfo()
        {
            EditorGUILayout.BeginVertical("HelpBox");
            GUILayout.Space(1.5f);
            
            EditorGUILayout.LabelField("Info", EditorStyles.boldLabel);

            EditorGUILayout.LabelField(new GUIContent("Version"), new GUIContent(AssetVersionData.AssetVersionNumber));
            EditorGUILayout.LabelField(new GUIContent("Release Date"), new GUIContent(AssetVersionData.AssetReleaseDate));

            GUILayout.Space(2.5f);
            EditorGUILayout.EndVertical();
        }
        

        /// <summary>
        /// Draws the styling options section.
        /// </summary>
        private static void DrawOptions()
        {
            EditorGUILayout.BeginVertical("HelpBox");
            GUILayout.Space(1.5f);
            
            EditorGUILayout.LabelField("Options", EditorStyles.boldLabel);

            TransformColoursEditorUtil.StyleSetting = (StyleSetting) EditorGUILayout.EnumPopup(new GUIContent("Style", "The style to use in the transform override."), TransformColoursEditorUtil.StyleSetting);

            GUILayout.Space(2.5f);
            EditorGUILayout.EndVertical();
        }

        
        /// <summary>
        /// Draws the customisation section.
        /// </summary>
        private static void DrawCustomisations()
        {
            EditorGUILayout.BeginVertical("HelpBox");
            GUILayout.Space(1.5f);
            
            EditorGUILayout.LabelField("Customise", EditorStyles.boldLabel);

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginVertical();
            GUI.color = TransformColoursEditorUtil.Red;
            TransformColoursEditorUtil.XColour = EditorGUILayout.ColorField(new GUIContent("X Color", "The colour of the X field."), TransformColoursEditorUtil.XColour, true, false, false);
            GUI.color = TransformColoursEditorUtil.Green;
            TransformColoursEditorUtil.YColour = EditorGUILayout.ColorField(new GUIContent("Y Color", "The colour of the Y field."), TransformColoursEditorUtil.YColour, true, false, false);
            GUI.color = TransformColoursEditorUtil.Blue;
            TransformColoursEditorUtil.ZColour = EditorGUILayout.ColorField(new GUIContent("Z Color", "The colour of the Z field."), TransformColoursEditorUtil.ZColour, true, false, false);
            GUI.color = defaultTextColour;
            EditorGUILayout.EndVertical();
            
            if (EditorGUI.EndChangeCheck())
            {
                TransformColoursEditorUtil.RefreshColoursSave();
            }
            
            GUILayout.Space(1.5f);

            if (GUILayout.Button("Reset"))
            {
                DialogueWindowHandler.ShowResetDialogue();
            }
            
            GUILayout.Space(2.5f);
            EditorGUILayout.EndVertical();
        }
        
        
        /// <summary>
        /// Draws the buttons section.
        /// </summary>
        private static void DrawButtons()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Asset Store", GUILayout.Height(30), GUILayout.MinWidth(100)))
                Application.OpenURL("https://assetstore.unity.com/publishers/43356");
            
            if (GUILayout.Button("GitHub", GUILayout.Height(30), GUILayout.MinWidth(100)))
                Application.OpenURL("https://github.com/CarterGames/TransformColours");

            if (GUILayout.Button("Documentation", GUILayout.Height(30), GUILayout.MinWidth(100)))
                Application.OpenURL("https://carter.games/transformcolours/");

            if (GUILayout.Button("Change Log", GUILayout.Height(30), GUILayout.MinWidth(100)))
                Application.OpenURL("https://carter.games/transformcolours/changelog");

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Email", GUILayout.Height(30), GUILayout.MinWidth(100)))
                Application.OpenURL("mailto:hello@carter.games?subject=I need help with the Transform Colours asset.");

            if (GUILayout.Button("Discord", GUILayout.Height(30), GUILayout.MinWidth(100)))
                Application.OpenURL("https://carter.games/discord");

            if (GUILayout.Button("Report Issues", GUILayout.Height(30), GUILayout.MinWidth(100)))
                Application.OpenURL("https://carter.games/report");

            EditorGUILayout.EndHorizontal();

            var carterGamesBanner = TransformColoursEditorUtil.CarterGamesBanner;

            if (carterGamesBanner != null)
            {
                GUI.contentColor = new Color(1, 1, 1, .75f);

                if (GUILayout.Button(carterGamesBanner, GUILayout.MaxHeight(40)))
                    Application.OpenURL("https://carter.games/");

                GUI.contentColor = defaultTextColour;
            }
            else
            {
                if (GUILayout.Button("Carter Games", GUILayout.MaxHeight(40)))
                    Application.OpenURL("https://carter.games/");
            }
        }
    }
}