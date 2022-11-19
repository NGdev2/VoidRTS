using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapResearch
{
	public class GreyTileScript : MonoBehaviour
	{
		[HideInInspector] public Vector3Int lastTileCoordinates;
		[SerializeField] private Tilemap whiteMap;
		[SerializeField] private Tile whiteTile;
		[SerializeField] private Tilemap greyMap;
		private bool painted = true;

		public void recolorTile()
		{
			if (lastTileCoordinates == null || painted == false)
			{
				painted = true;
				return;
			}
			greyMap.SetTile(lastTileCoordinates, null);
			whiteMap.SetTile(lastTileCoordinates, whiteTile);
		}

		void OnMouseExit()
		{
			recolorTile();
		}

		private void OnMouseDown()
		{
			var mousePosTranslated = MapResearchUtils.GetTilemapMousePos(ref whiteMap);
			greyMap.SetTile(mousePosTranslated, null);
			painted = false;
		}
	}
}
