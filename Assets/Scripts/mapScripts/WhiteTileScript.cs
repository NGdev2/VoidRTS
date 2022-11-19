using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using MapResearch;

namespace MapResearch
{
	public class WhiteTileScript : MonoBehaviour
	{
		[SerializeField] private GreyTileScript greyTileScript;
		[SerializeField] private Tilemap whiteMap;
		[SerializeField]
		private List<Tile> temporaryObstacle;
		[SerializeField] private Tilemap greyMap;
		[SerializeField] private Tilemap globalMap;
		[SerializeField] private Tilemap eventMap;
		[SerializeField] private Tile greyTile;
		[SerializeField] private Tile whiteTile;
		[SerializeField] private Tile roadTile;

		private void OnMouseEnter()
		{
			var mousePosTranslated = MapResearchUtils.GetTilemapMousePos(ref whiteMap);
			var openable = Openable(mousePosTranslated);
			
			if (openable == true)
			{
				whiteMap.SetTile(mousePosTranslated, null);
				greyMap.SetTile(mousePosTranslated, greyTile);
				greyTileScript.lastTileCoordinates = mousePosTranslated;
			}
		}

		private bool Openable(Vector3Int location)
		{
			var whiteMapNeightbour = new SNeighbours();
			var globalMapNeightbour = new SNeighbours();
			var eventMapNeightbour = new SNeighbours();
			getNeighbours(ref whiteMapNeightbour, whiteMap, location);
			getNeighbours(ref globalMapNeightbour, globalMap, location);
			getNeighbours(ref eventMapNeightbour, eventMap, location);
			var whiteMapTileDict = whiteMapNeightbour.createTileDict();
			var globalMapTileDict = globalMapNeightbour.createTileDict();
			var eventMapTileDict = eventMapNeightbour.createTileDict();
			var whiteMapCoordinatesDict = whiteMapNeightbour.createCoordinateDict();
			var globalMapCoordinatesDict = globalMapNeightbour.createCoordinateDict();
			var eventMapCoordinatesDict = eventMapNeightbour.createCoordinateDict();

			foreach (KeyValuePair<string, TileBase>item in whiteMapTileDict)
			{
				// if not a white tile nearby
				// check that there are a game map
				if (whiteMap.HasTile(whiteMapCoordinatesDict[item.Key]) == false)
				{
					if (globalMap.HasTile(globalMapCoordinatesDict[item.Key]) == true && globalMapTileDict[item.Key] == roadTile)
					{
						foreach (var eventTile in temporaryObstacle)
						{
							if (eventTile == eventMapTileDict[item.Key])
							{
								return false;
							}
						}
						return true;
					}
				}
			}
			return false;
		}


		private void getNeighbours(ref SNeighbours neightbour, Tilemap map, Vector3Int location)
		{
			var horizontalOffset = 0;
			if (location.y % 2 == 0)
			{
				horizontalOffset = -1;
			}
			neightbour.centerCoordinates = location;
			neightbour.leftCoordinates = new Vector3Int(location.x - 1, location.y, location.z);
			neightbour.leftTopCoordinates = new Vector3Int(location.x + horizontalOffset, location.y + 1, location.z);
			neightbour.rightCoordinates = new Vector3Int(location.x + 1, location.y, location.z);
			neightbour.rightTopCoordinates = new Vector3Int(location.x + 1 + horizontalOffset, location.y + 1, location.z);
			neightbour.leftLowerCoordinates = new Vector3Int(location.x + horizontalOffset, location.y - 1, location.z);
			neightbour.rightLowerCoordinates = new Vector3Int(location.x + 1 + horizontalOffset, location.y - 1, location.z);

			neightbour.centerTile = map.GetTile(location);
			neightbour.leftTile = map.GetTile(neightbour.leftCoordinates);
			neightbour.leftTopTile = map.GetTile(neightbour.leftTopCoordinates);
			neightbour.rightTile = map.GetTile(neightbour.rightCoordinates);
			neightbour.rightTopTile = map.GetTile(neightbour.rightTopCoordinates);
			neightbour.leftLowerTile = map.GetTile(neightbour.leftLowerCoordinates);
			neightbour.rightLowerTile = map.GetTile(neightbour.rightLowerCoordinates);
		}
	}
}