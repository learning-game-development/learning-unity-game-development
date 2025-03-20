using UnityEditor;

namespace CarterGames.Assets.TransformColours.Editor
{
    /// <summary>
    /// Handles all dialogue boxes in the asset.
    /// </summary>
    public static class DialogueWindowHandler
    {
        /// <summary>
        /// Displays a dialogue popup for the user trying to reset the colours use on the transform component.
        /// </summary>
        public static void ShowResetDialogue()
        {
            if (EditorUtility.DisplayDialog("Reset Colours?",
                "Are you sure you want to reset the colours back to their default values?", "Yes", "No"))
            {
                TransformColoursEditorUtil.ResetColoursToDefault();
            }
        }
    }
}