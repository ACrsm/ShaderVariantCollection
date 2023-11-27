using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShaderVariantCollectorWindow : EditorWindow
{
	[MenuItem("Tools/Shader变体收集器", false, 100)]
	public static void OpenWindow()
	{
		ShaderVariantCollectorWindow window = GetWindow<ShaderVariantCollectorWindow>("Shader变体收集工具", true);
		window.minSize = new Vector2(800, 600);
	}

    private void OnGUI()
    {
		DrawContent();
    }

	private void DrawContent()
	{
		GUILayout.BeginHorizontal();
		{
			GUILayout.FlexibleSpace();

			GUILayout.BeginVertical();
			{
				if (GUILayout.Button("一键收集Shader变体"))
				{
					CollectButton_clicked();
				}
			}
			GUILayout.EndVertical();

			GUILayout.FlexibleSpace();
		}
		GUILayout.EndHorizontal();
	}

    private void CollectButton_clicked()
    {
        string savePath = "Assets/ShaderVariants.shadervariants";
        int processCapacity = 1000;
        ShaderVariantCollector.Run(savePath, processCapacity, null);
    }
}