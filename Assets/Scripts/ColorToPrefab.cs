
using UnityEngine;

[CreateAssetMenu(menuName = "ColorToPrefab")]
public class ColorToPrefab : ScriptableObject
{
    public string prefabName;
    public Color color;
    public GameObject prefab;
}
