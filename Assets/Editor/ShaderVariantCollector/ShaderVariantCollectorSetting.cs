using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ShaderVariantCollectorSetting", menuName = "ShaderVariantCollectorSetting", order = 1)]
public class ShaderVariantCollectorSetting : ScriptableObject
{
	private const string DefaultSavePath = "Assets/MyShaderVariants.shadervariants";

	[Tooltip("Shader变体收集文件保存的路径")]
	public string SavePath = DefaultSavePath;

	[Tooltip("单次处理材质球的最大个数， 超过这个分两次处理。")]
	public int Capacity = 1000;

	[Tooltip("待收集的材质球列表")]
	public List<string> MaterialPathList;
}