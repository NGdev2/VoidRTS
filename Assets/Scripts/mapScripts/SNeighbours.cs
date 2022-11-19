using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Collections.Generic;

namespace MapResearch
{
	public struct SNeighbours
	{
		public Dictionary<string, TileBase> dictNeightbours;
		public Dictionary<string, Vector3Int> dictCoordinates;
		public TileBase centerTile;
		public TileBase leftTile;
		public TileBase leftTopTile;
		public TileBase rightTile;
		public TileBase rightTopTile;
		public TileBase leftLowerTile;
		public TileBase rightLowerTile;
		public Vector3Int centerCoordinates;
		public Vector3Int leftCoordinates;
		public Vector3Int leftTopCoordinates;
		public Vector3Int rightCoordinates;
		public Vector3Int rightTopCoordinates;
		public Vector3Int leftLowerCoordinates;
		public Vector3Int rightLowerCoordinates;


		public void printNeighbours()
		{
			if (centerTile != null)		{ Debug.Log("Center tile is " + centerTile.name); }
			if (rightTopTile != null)	{ Debug.Log("Right top tile is " + rightTopTile.name); }
			if (rightTile != null)		{ Debug.Log("Right tile is " + rightTile.name); }
			if (rightLowerTile != null)	{ Debug.Log("Right lower tile is " + rightLowerTile.name); }
			if (leftLowerTile != null)	{ Debug.Log("Left lower tile is " + leftLowerTile.name); }
			if (leftTile != null)		{ Debug.Log("Left tile is " + leftTile.name); }
			if (leftTopTile != null)	{ Debug.Log("Left top tile is " + leftTopTile.name); }
		}

		public Dictionary <string, TileBase> createTileDict()
		{
			dictNeightbours = new Dictionary<string, TileBase>()
			{
				{"Center", centerTile},
				{"Right top", rightTopTile},
				{"Right", rightTile},
				{"Right lower", rightLowerTile},
				{"Left lower", leftLowerTile},
				{"Left", leftTile},
				{"Left top", leftTopTile}
			};
			return (dictNeightbours);
		}

		public Dictionary <string, Vector3Int> createCoordinateDict()
		{
			dictCoordinates = new Dictionary<string, Vector3Int>()
			{
				{"Center", centerCoordinates},
				{"Right top", rightTopCoordinates},
				{"Right", rightCoordinates},
				{"Right lower", rightLowerCoordinates},
				{"Left lower", leftLowerCoordinates},
				{"Left", leftCoordinates},
				{"Left top", leftTopCoordinates}
			};
			return (dictCoordinates);
		}
	}
}