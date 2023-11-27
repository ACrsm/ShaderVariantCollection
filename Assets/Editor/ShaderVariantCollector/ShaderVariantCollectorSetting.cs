using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ShaderVariantCollectorSetting", menuName = "ShaderVariantCollectorSetting", order = 1)]
public class ShaderVariantCollectorSetting : ScriptableObject
{
	private const string DefaultSavePath = "Assets/MyShaderVariants.shadervariants";

	public string SavePath = DefaultSavePath;

	public int Capacity = 1000;
}