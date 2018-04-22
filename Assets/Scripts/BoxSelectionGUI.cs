using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelectionGUI : MonoBehaviour {

	static Texture2D boxTexture;
	public static Texture2D WhiteTexture
	{
		get
		{
			if(!boxTexture)
			{
				boxTexture = new Texture2D(1, 1);
				boxTexture.SetPixel(0, 0, Color.white);
				boxTexture.Apply();
			}
			return boxTexture;
		}
	}

	public static void DrawBox(Rect rect, Color color)
	{
		GUI.color = color;
		GUI.DrawTexture(rect, WhiteTexture);
		GUI.color = Color.white;
	}

	public static void DrawScreenRectBorder(Rect rect, float thickness, Color color)
	{
		BoxSelectionGUI.DrawBox(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
		BoxSelectionGUI.DrawBox(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
		BoxSelectionGUI.DrawBox(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
		BoxSelectionGUI.DrawBox(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
	}

	public static Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
	{
		screenPosition1.y = Screen.height - screenPosition1.y;
		screenPosition2.y = Screen.height - screenPosition2.y;

		Vector3 topLeft = Vector3.Min(screenPosition1, screenPosition2);
		Vector3 bottomRight = Vector3.Max(screenPosition1, screenPosition2);

		return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
	}

	public static Bounds GetViewportBounds(Camera cam, Vector3 screenPosition1, Vector3 screenPosition2)
	{
		Vector3 v1 = Camera.main.ScreenToViewportPoint(screenPosition1);
		Vector3 v2 = Camera.main.ScreenToViewportPoint(screenPosition2);

		Vector3 min = Vector3.Min(v1, v2);
		Vector3 max = Vector3.Max(v1, v2);

		min.z = cam.nearClipPlane;
		max.z = cam.farClipPlane;

		Bounds bounds = new Bounds();
		bounds.SetMinMax(min, max);
		return bounds;
	}
}
