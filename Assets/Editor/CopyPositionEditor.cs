using UnityEngine;
using UnityEditor;

// Adds MenuItems to Unity Editor for copy/paste selected transform's position
public class CopyPositionEditor : ScriptableObject {

    static Vector3 cachedPosition;

    [MenuItem("Edit/Copy Transform Position %#c")]
    static void CopyPosition() {
        if (Selection.activeTransform != null) {
            cachedPosition = Selection.activeTransform.position;
            EditorGUIUtility.systemCopyBuffer = cachedPosition.x + ", " +
                                                cachedPosition.y + ", " +
                                                cachedPosition.z;
        }
    }

    [MenuItem("Edit/Paste Transform Position %#v")]
    static void PastePosition() {
        if (Selection.activeTransform != null) {
            Undo.RecordObject(Selection.activeTransform, "Paste Transform Position");
            Selection.activeTransform.position = new Vector3(cachedPosition.x,
                                                             cachedPosition.y,
                                                             cachedPosition.z);
        }
    }

}