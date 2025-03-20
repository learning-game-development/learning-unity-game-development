using UnityEngine;
using UnityEditor;

namespace CarterGames.Assets.TransformColours.Editor
{
    /// <summary>
    /// Handles the override for the transform component.
    /// </summary>
    [CanEditMultipleObjects, CustomEditor(typeof(Transform))]
    public class TransformColours : UnityEditor.Editor
    {
        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Fields
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        private Transform transformComponent;
        
        // Bool values for if something has changed
        private bool posChange;
        private bool rotChange;
        private bool scaleChange;

        // Vector3 Values for initial ( Position / Rotation / Scale ) Values
        private Vector3 initPos;
        private Vector3 initRot;
        private Vector3 initScale;
        
        private SerializedProperty posX;
        private SerializedProperty posY;
        private SerializedProperty posZ;
        
        private SerializedProperty scaleX;
        private SerializedProperty scaleY;
        private SerializedProperty scaleZ;
        
#if UNITY_2021_2_OR_NEWER
        private SerializedProperty scaleConstrain;
#endif
        
        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Menu Items
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 

        /// <summary>
        /// Shows the Menu item that changes between 2D&3D view on the inspector
        /// </summary>
        [MenuItem("Tools/Carter Games/Transform Colours/Switch 2D-3D View", priority = 1)]
        public static void ToggleTwoD()
        {
            if (EditorPrefs.GetBool("CarterGames-TransformColours-Use2D"))
                EditorPrefs.SetBool("CarterGames-TransformColours-Use2D", false);
            else
                EditorPrefs.SetBool("CarterGames-TransformColours-Use2D", true);

            var _temp = new TransformColours();
            _temp.UpdateInspector();
        }
        
        
        /// <summary>
        /// Shows the Menu item that lets the user access the settings
        /// </summary>
        [MenuItem("Tools/Carter Games/Transform Colours/Edit Settings", priority = 0)]
        public static void EditSettings()
        {
            SettingsService.OpenUserPreferences("Preferences/Carter Games/Transform Colours");
        }

        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Unity Methods
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        private void OnEnable()
        {
            if (target == null) return;
            
            posX = serializedObject.FindProperty("m_LocalPosition.x");
            posY = serializedObject.FindProperty("m_LocalPosition.y");
            posZ = serializedObject.FindProperty("m_LocalPosition.z");
            
            scaleX = serializedObject.FindProperty("m_LocalScale.x");
            scaleY = serializedObject.FindProperty("m_LocalScale.y");
            scaleZ = serializedObject.FindProperty("m_LocalScale.z");
            
#if UNITY_2021_2_OR_NEWER
            scaleConstrain = serializedObject.FindProperty("m_ConstrainProportionsScale");
#endif
        }


        /// <summary>
        /// Overrides the default inspector with the one made in this script...
        /// </summary>
        public override void OnInspectorGUI()
        {
            transformComponent = targets[0] as Transform;          // Assigns the T component to the T Variable
            
            posChange = false;              // Setting the Position change to be false ready for a fresh check
            rotChange = false;              // Setting the Rotation change to be false ready for a fresh check
            scaleChange = false;            // Setting the Scale change to be false ready for a fresh check

            initPos = transformComponent.localPosition;      // Setting the Initial Position of the Transform to what the current local position is
            initRot = transformComponent.localEulerAngles;   // Setting the Initial Rotation of the Transform to what the current local rotation is
            initScale = transformComponent.localScale;       // Setting the Initial Scale of the Transform to what the current local scale is
            
            PositionInspector();
            RotationInspector();
            ScaleInspector();

            ApplyChanges();
        }
        
        
        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Section Methods
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        /// <summary>
        /// Defines the position elements in the inspector.
        /// </summary>
        private void PositionInspector()
        {
            // Position Label - Adjusts to whether or not the inspector is in wide mode
            if (EditorGUIUtility.wideMode)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Position", GUILayout.MinWidth(90), GUILayout.ExpandHeight(false));
            }
            else
                GUILayout.Label("Position", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));

            // Only in 2021.2 or newer - Adjusts the layout to make it all match with the scale constrain in 2021.2...
#if UNITY_2021_2_OR_NEWER
            if (GUILayout.Button(GUIContent.none, GUIStyle.none, GUILayout.Width(17.5f))){}
#endif

            // Making the Position Vector3 Boxes in their colours 
            EditorGUIUtility.labelWidth = 15;
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();

            // Position X - Red
            GUI.backgroundColor = TransformColoursEditorUtil.XColour;
            EditorGUILayout.PropertyField(posX, new GUIContent("X"));
            GUI.backgroundColor = Color.white;

            // Position Y - Green
            GUI.backgroundColor = TransformColoursEditorUtil.YColour;
            EditorGUILayout.PropertyField(posY, new GUIContent("Y"));
            GUI.backgroundColor = Color.white;


            if (TransformColoursEditorUtil.StyleSetting == StyleSetting.ThreeD)
            {
                // Position Z - Blue
                GUI.backgroundColor = TransformColoursEditorUtil.Hidden;
                EditorGUILayout.PropertyField(posZ, new GUIContent("Z"));
                GUI.backgroundColor = Color.white;
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                // Position Z - Blue
                GUI.backgroundColor = TransformColoursEditorUtil.ZColour;
                var posZ = serializedObject.FindProperty("m_LocalPosition.z");
                EditorGUILayout.PropertyField(posZ, new GUIContent("Z"));
                GUI.backgroundColor = Color.white;
                EditorGUILayout.EndHorizontal();
            }

            // Runs if a edit was made to one of the fields above
            if (EditorGUI.EndChangeCheck())
                posChange = true;

            // Adjusts the editor Hoz grouping so the label shows above the boxes if the inspector is not in wide mode
            if (EditorGUIUtility.wideMode)
                EditorGUILayout.EndHorizontal();
        }

        
        /// <summary>
        /// Defines the rotation elements in the inspector.
        /// </summary>
        private void RotationInspector()
        {
            // Rotation Label - Adjusts to whether or not the inspector is in wide mode
            if (EditorGUIUtility.wideMode)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Rotation", GUILayout.MinWidth(90), GUILayout.ExpandHeight(false));
            }
            else
                GUILayout.Label("Rotation", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));


            // Only in 2021.2 or newer - Adjusts the layout to make it all match with the scale constrain in 2021.2...
#if UNITY_2021_2_OR_NEWER
            if (GUILayout.Button(GUIContent.none, GUIStyle.none, GUILayout.Width(17.5f))){}
#endif
            
            
            // Making the  RotationVector3 Boxes in their colours 
            EditorGUIUtility.labelWidth = 15;
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            
            

            // Hotfix 2 - try to stop the 90/270 issue
            var _newRot = TransformUtils.GetInspectorRotation(transformComponent);

            if (TransformColoursEditorUtil.StyleSetting == StyleSetting.ThreeD)
            {
                // Rotation X - Red
                GUI.backgroundColor = TransformColoursEditorUtil.Hidden;
                _newRot.x = EditorGUILayout.FloatField(new GUIContent("X"), _newRot.x, GUILayout.Width(70), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));

                // Rotation Y - Green
                _newRot.y = EditorGUILayout.FloatField(new GUIContent("Y"), _newRot.y, GUILayout.Width(70), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));
                GUI.backgroundColor = Color.white;

                // Rotation Z - Blue
                GUI.backgroundColor = TransformColoursEditorUtil.ZColour;
                _newRot.z = EditorGUILayout.FloatField(new GUIContent("Z"), _newRot.z, GUILayout.Width(70), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));
                GUI.backgroundColor = Color.white;
            }
            else
            {
                // Rotation X - Red
                GUI.backgroundColor = TransformColoursEditorUtil.XColour;
                _newRot.x = EditorGUILayout.FloatField(new GUIContent("X"), _newRot.x, GUILayout.Width(70), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));
                GUI.backgroundColor = Color.white;

                // Rotation Y - Green
                GUI.backgroundColor = TransformColoursEditorUtil.YColour;
                _newRot.y = EditorGUILayout.FloatField(new GUIContent("Y"), _newRot.y, GUILayout.Width(70), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));
                GUI.backgroundColor = Color.white;

                // Rotation Z - Blue
                GUI.backgroundColor = TransformColoursEditorUtil.ZColour;
                _newRot.z = EditorGUILayout.FloatField(new GUIContent("Z"), _newRot.z, GUILayout.Width(70), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));
                GUI.backgroundColor = Color.white;
            }


            EditorGUILayout.EndHorizontal();

            // Hotfix 2 - try to stop the 90/270 issue
            TransformUtils.SetInspectorRotation(transformComponent, _newRot);
            
            // Runs if a edit was made to one of the fields above
            if (EditorGUI.EndChangeCheck())
                rotChange = true;

            // Adjusts the editor Hoz grouping so the label shows above the boxes if the inspector is not in wide mode
            if (EditorGUIUtility.wideMode)
                EditorGUILayout.EndHorizontal();
        }

        
        /// <summary>
        /// Defines the scale elements in the inspector.
        /// </summary>
        private void ScaleInspector()
        {
            // Scale Label - Adjusts to whether or not the inspector is in wide mode
            if (EditorGUIUtility.wideMode)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Scale", GUILayout.MinWidth(90), GUILayout.ExpandHeight(false));
            }
            else
                GUILayout.Label("Scale", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));


            // Scale Constrain (Only in 2021.2 or newer)
#if UNITY_2021_2_OR_NEWER
            EditorGUILayout.PropertyField(scaleConstrain, GUIContent.none, GUILayout.Width(17.5f));
#endif
            
            // Making the Position Vector3 Boxes in their colours 
            EditorGUIUtility.labelWidth = 15;
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();

            // Scale X - Red
            GUI.backgroundColor = TransformColoursEditorUtil.XColour;
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(scaleX, new GUIContent("X"));
            if (EditorGUI.EndChangeCheck())
            {
#if UNITY_2021_2_OR_NEWER
                if (scaleConstrain.boolValue)
                {
                    scaleY.floatValue = scaleX.floatValue;
                    scaleZ.floatValue = scaleX.floatValue;
                    scaleChange = true;
                }
#endif
            }
            GUI.backgroundColor = Color.white;

            // Scale Y - Green
            GUI.backgroundColor = TransformColoursEditorUtil.YColour;
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(scaleY, new GUIContent("Y"));
            if (EditorGUI.EndChangeCheck())
            {
#if UNITY_2021_2_OR_NEWER
                if (scaleConstrain.boolValue)
                {
                    scaleX.floatValue = scaleY.floatValue;
                    scaleZ.floatValue = scaleY.floatValue;
                    scaleChange = true;
                }
#endif
            }
            GUI.backgroundColor = Color.white;


            if (TransformColoursEditorUtil.StyleSetting == StyleSetting.ThreeD)
            {
                // Scale Z - Blue
                GUI.backgroundColor = TransformColoursEditorUtil.Hidden;
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(scaleZ, new GUIContent("Z"));
                if (EditorGUI.EndChangeCheck())
                {
#if UNITY_2021_2_OR_NEWER
                    if (scaleConstrain.boolValue)
                    {
                        scaleX.floatValue = scaleZ.floatValue;
                        scaleY.floatValue = scaleZ.floatValue;
                        scaleChange = true;
                    }
#endif
                }
                GUI.backgroundColor = Color.white;
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                // Scale Z - Blue
                GUI.backgroundColor = TransformColoursEditorUtil.ZColour;
                var scaleZ = serializedObject.FindProperty("m_LocalScale.z");
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(scaleZ, new GUIContent("Z"));
                if (EditorGUI.EndChangeCheck())
                {
#if UNITY_2021_2_OR_NEWER
                    if (scaleConstrain.boolValue)
                    {
                        scaleX.floatValue = scaleZ.floatValue;
                        scaleY.floatValue = scaleZ.floatValue;
                        scaleChange = true;
                    }
#endif
                }
                GUI.backgroundColor = Color.white;
                EditorGUILayout.EndHorizontal();
            }

            // Runs if a edit was made to one of the fields above
            if (EditorGUI.EndChangeCheck())
                scaleChange = true;

            // Adjusts the editor Hoz grouping so the label shows above the boxes if the inspector is not in wide mode
            if (EditorGUIUtility.wideMode)
                EditorGUILayout.EndHorizontal();
        }

        
        /* —————————————————————————————————————————————————————————————————————————————————————————————————————————————
        |   Utility Methods
        ————————————————————————————————————————————————————————————————————————————————————————————————————————————— */ 
        
        
        /// <summary>
        /// Updates the inspector when called.
        /// </summary>
        private void UpdateInspector()
        {
            Repaint();
        }

        
        /// <summary>
        /// Does the colour change for each box as well as detects changes in each ( Position / Rotation / Scale ) - ( X / Y / Z ) 
        /// </summary>
        private void ApplyChanges()
        {
            // Gets all objects currently selected in the editor
            var _selectedTransforms = Selection.GetTransforms(SelectionMode.Editable);

            // If there is at-least 1 object selected
            if (_selectedTransforms.Length > 1)
            {
                // Go through them all and adjust their values where they have been changed
                foreach (var _t1 in _selectedTransforms)
                {
                    if (posChange)
                        _t1.localPosition = ApplyPositionWhatChange(_t1.localPosition, initPos, transformComponent.localPosition);
                    
                    if (rotChange)
                        _t1.localEulerAngles = ApplyRotationWhatChange(_t1.localEulerAngles, initRot, transformComponent.localEulerAngles);
                    
                    if (scaleChange)
                        _t1.localScale = ApplyScaleWhatChange(_t1.localScale, initScale, transformComponent.localScale);
                }
            }

            // Apply the changes and update the editor (also fixed animation recording problems.... 1.1.3....)
            Undo.RecordObjects(this.targets, "Transform Colours - Transform Changed");
            serializedObject.ApplyModifiedProperties();
        }

        
        /// <summary>
        /// Updates the position for what values were changed...
        /// </summary>
        /// <param name="toApply">What value is been changed</param>
        /// <param name="init">What the value was before it was changed</param>
        /// <param name="change">What the value is been changed too</param>
        /// <returns></returns>
        private Vector3 ApplyPositionWhatChange(Vector3 toApply, Vector3 init, Vector3 change)
        {
            if (!Mathf.Approximately(init.x, change.x))
                toApply.x = transformComponent.localPosition.x;

            if (!Mathf.Approximately(init.y, change.y))
                toApply.y = transformComponent.localPosition.y;

            if (!Mathf.Approximately(init.z, change.z))
                toApply.z = transformComponent.localPosition.z;

            Undo.RecordObjects(this.targets, "Transform Colours - Position Change");

            return toApply;
        }
        

        /// <summary>
        /// Updates the rotation for what values were changed...
        /// </summary>
        /// <param name="toApply">What value is been changed</param>
        /// <param name="init">What the value was before it was changed</param>
        /// <param name="change">What the value is been changed too</param>
        /// <returns></returns>
        private Vector3 ApplyRotationWhatChange(Vector3 toApply, Vector3 init, Vector3 change)
        {
            var _localEulerAngles = transformComponent.localEulerAngles;
            
            toApply.x = !Mathf.Approximately(init.x, change.x) 
                ? _localEulerAngles.x 
                : init.x;

            toApply.y = !Mathf.Approximately(init.y, change.y) 
                ? _localEulerAngles.y 
                : init.y;

            toApply.z = !Mathf.Approximately(init.z, change.z) 
                ? _localEulerAngles.z 
                : init.z;

            Undo.RecordObjects(this.targets, "Transform Colours - Rotation Change");

            return toApply;
        }

        
        /// <summary>
        /// Updates the scale for what values were changed...
        /// </summary>
        /// <param name="toApply">What value is been changed</param>
        /// <param name="init">What the value was before it was changed</param>
        /// <param name="change">What the value is been changed too</param>
        /// <returns></returns>
        private Vector3 ApplyScaleWhatChange(Vector3 toApply, Vector3 init, Vector3 change)
        {
            if (!Mathf.Approximately(init.x, change.x))
                toApply.x = transformComponent.localScale.x;

            if (!Mathf.Approximately(init.y, change.y))
                    toApply.y = transformComponent.localScale.y;

            if (!Mathf.Approximately(init.z, change.z))
                toApply.z = transformComponent.localScale.z;

            Undo.RecordObjects(this.targets, "Transform Colours - Scale Change");

            return toApply;
        }
    }
}