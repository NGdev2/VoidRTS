using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapResearch
{
	public class MapResearchUtils : MonoBehaviour
	{
		static public Vector3Int GetTilemapMousePos(ref Tilemap map)
		{
			var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var mapMousePos = map.WorldToCell(mousePos);
			mapMousePos.z = 0;
			return (mapMousePos);
		}
	}
}
