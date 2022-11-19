using UnityEngine;
using UnityEngine.Tilemaps;
using System;

namespace MapResearch
{
	public class MapController : MonoBehaviour
	{
		[SerializeField] private Tile exit;
		[SerializeField] private Tile road;
		[SerializeField] private Tile obstacle;
		[SerializeField] private Tile item;
		[SerializeField] private Tile enemy;
		[SerializeField] private Tile secret;
		[SerializeField] private Tilemap globalMap;
		[SerializeField] private GameObject exitMenu;

		private void OnMouseDown()
		{
			var mousePosTranslated = MapResearchUtils.GetTilemapMousePos(ref globalMap);
			var currentTile = globalMap.GetTile(mousePosTranslated);
			if (currentTile == exit)
			{
				exitMenu.SetActive(true);
			}
			else if (currentTile == item)
			{
				Debug.Log("Item pick up");
				globalMap.SetTile(mousePosTranslated, null);
				globalMap.SetTile(mousePosTranslated, road);
			}
		}
	}
}
