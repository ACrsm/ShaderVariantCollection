using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShaderVariantCollectorWindow : EditorWindow
{
	private bool _isToCollectShaderVariants = false;

	private ShaderVariantCollectorSetting _shaderVariantCollectorSetting;

	[MenuItem("Tools/Shader变体收集器", false, 200)]
	public static void OpenWindow()
	{
		ShaderVariantCollectorWindow window = GetWindow<ShaderVariantCollectorWindow>("Shader变体收集工具", true);
		CenterOnMainWin(window);
		window.Show();
		window.Init();
	}

	public static void CenterOnMainWin(EditorWindow window)
	{
		Rect main = EditorGUIUtility.GetMainWindowPosition();
		Rect pos = window.position;
		float centerWidth = (main.width - pos.width) * 0.5f;
		float centerHeight = (main.height - pos.height) * 0.5f;
		pos.x = main.x + centerWidth;
		pos.y = main.y + centerHeight;
		window.position = pos;
	}

	public void Init()
    {
		_shaderVariantCollectorSetting = AssetDatabase.LoadAssetAtPath<ShaderVariantCollectorSetting>("Assets/Editor/ShaderVariantCollector/ShaderVariantCollectorSetting.asset");
		if (_shaderVariantCollectorSetting == null)
        {
			Debug.LogError("未能找到Shadoer变体收集器的配置文件: Assets/Editor/ShaderVariantCollector/ShaderVariantCollectorSetting.asset");
        }
	}

	private void OnGUI()
    {
		if (_shaderVariantCollectorSetting == null)
        {
			return;
        }

		DrawContent();

		if (_isToCollectShaderVariants)
        {
			_isToCollectShaderVariants = false;
			CollectShaderVariants();
		}
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
					_isToCollectShaderVariants = true;
				}
			}
			GUILayout.EndVertical();

			GUILayout.FlexibleSpace();
		}
		GUILayout.EndHorizontal();
	}

    private void CollectShaderVariants()
    {
		if (_shaderVariantCollectorSetting == null)
        {
			return;
        }

        string savePath = _shaderVariantCollectorSetting.SavePath;
        int processCapacity = _shaderVariantCollectorSetting.Capacity;
		List<string> collectMatPathList = _shaderVariantCollectorSetting.MaterialPathList;

		ShaderVariantCollector.Run(savePath, processCapacity, collectMatPathList, null);
    }
}