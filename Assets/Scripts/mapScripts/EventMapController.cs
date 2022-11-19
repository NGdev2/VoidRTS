using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapResearch
{
	public class EventMapController : MonoBehaviour
	{
		[SerializeField] private Tile item;
		[SerializeField] private Tile enemy;
		[SerializeField] private Tilemap map;

		void OnMouseDown() {
			var mousePosTranslated = MapResearchUtils.GetTilemapMousePos(ref map);
			var currentTile = map.GetTile(mousePosTranslated);
			if (currentTile == enemy)
			{
				/*TODO:
				* starts fight scene
				*/
				Debug.Log("defeat an enemy");
			}
		}
	}
}
