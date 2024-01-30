#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Meme))]
public class MemeEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Meme meme = (Meme)target;

		if (meme.Sprite != null)
		{
			GUILayout.Label("Sprite Preview:", EditorStyles.boldLabel);
			Rect previewRect = EditorGUILayout.GetControlRect(false, 200);
			EditorGUI.DrawTextureTransparent(previewRect, meme.Sprite.texture);
		}
	}
}
#endif