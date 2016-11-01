using UnityEngine;

using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
	public class BoardManager : MonoBehaviour
	{
		[Range(1,10)]
		public int MinSizeMultiplier;

		[Range(1, 10)]
		public int MaxSizeMultiplier;

		//[HideInInspector]
		public int SizeMultiplier;

		public GameObject TitlesParent;
		public GameObject WallsParent;

		public GameObject WallPrefab;
		public GameObject TitlesPrefab;
		public GameObject[] CornerBlocks;

		private const float WorldSize = 28.4f;
		private const float HalfWorldSize = WorldSize / 2;

		private const float CornerBlockSize = 3.3f;
		private const float CornerBlockHalfSize = CornerBlockSize / 2;

		// Use this for initialization
		private void Start () {

			if (SizeMultiplier == 0)
			{
				SizeMultiplier = Random.Range(MinSizeMultiplier, MaxSizeMultiplier + 1);
			}

			GenerateMap();
		}

		// Update is called once per frame
		private void Update () {
			
		}

		private void GenerateMap()
		{
			const float halfLevelSize = CornerBlockSize + WorldSize;

			var originX = SizeMultiplier == 1 ? 0f : -halfLevelSize;
			var originY = SizeMultiplier == 1 ? 0f :- halfLevelSize;
			
			GenerateTitles(originX, originY);
			GenerateWalls(originX, originY);
			SetUpCornerBlocks(originX, originY);
		}

		private void SetUpCornerBlocks(float x, float y)
		{
			var origin = new Vector2(x, y);
			var levelSize = WorldSize * SizeMultiplier;

			// Bottom Left
			CornerBlocks[0].transform.position =
				new Vector2(
					origin.x + CornerBlockSize,
					origin.y + CornerBlockHalfSize
				);

			// Bottom Right
			CornerBlocks[1].transform.position =
				new Vector2(
					origin.x + levelSize,
					origin.y + CornerBlockHalfSize
				);

			// Top Left
			CornerBlocks[2].transform.position =
				new Vector2(
					origin.x + CornerBlockSize,
					origin.y + levelSize - CornerBlockHalfSize
				);

			// Top Right
			CornerBlocks[3].transform.position =
				new Vector2(
					origin.x + levelSize,
					origin.y + levelSize - CornerBlockHalfSize
				);
		}

		private void GenerateWalls(float x, float y)
		{
			x += CornerBlockSize;

			var boardSize = SizeMultiplier * WorldSize;

			for (var index = 1; index <= SizeMultiplier; index++)
			{
				var blockCenter = WorldSize * index - HalfWorldSize;

				if (index > 1)
				{
					blockCenter += -CornerBlockSize * index;
				}

				// Left Wall
				GenerateWall(new Vector2(x, y + blockCenter + CornerBlockHalfSize));

				// Right Wall
				GenerateWall(new Vector2(x + boardSize - CornerBlockSize * SizeMultiplier, y + blockCenter + CornerBlockHalfSize));

				// Top Wall
				GenerateWall(new Vector2(x + blockCenter, y + boardSize - CornerBlockHalfSize - (SizeMultiplier - 1) * CornerBlockSize), Quaternion.Euler(0, 0, 90));

				// Bottom Wall
				GenerateWall(new Vector2(x + blockCenter, y + CornerBlockHalfSize), Quaternion.Euler(0, 0, 90));
			}
		}

		private void GenerateWall(Vector2 position)
		{
			Instantiate(WallPrefab, WallsParent, position, Quaternion.identity);
		}

		private void GenerateWall(Vector2 position, Quaternion rotation)
		{
			Instantiate(WallPrefab, WallsParent, position, rotation);
		}

		private void GenerateTitles(float x, float y)
		{
			x += CornerBlockSize;
			y += CornerBlockSize;

			for (var xIndex = 1; xIndex <= SizeMultiplier; xIndex++)
			{
				var blockXCenter = WorldSize * xIndex - HalfWorldSize;

				if (xIndex > 1)
				{
					blockXCenter += -CornerBlockSize * xIndex;
				}

				for (var yIndex = 1; yIndex <= SizeMultiplier; yIndex++)
				{
					var blockYCenter = WorldSize * yIndex - HalfWorldSize;

					if (yIndex > 1)
					{
						blockYCenter -= CornerBlockSize * yIndex;
					}

					GenerateTitleBlock(
						new Vector2(
							x + blockXCenter,
							y + blockYCenter - CornerBlockHalfSize
						)
					);
				}

			}
		}

		private void GenerateTitleBlock(Vector2 position)
		{
			Instantiate(TitlesPrefab, TitlesParent, position, Quaternion.identity);
		}

		private static void Instantiate(Object type, GameObject parent, Vector2 position, Quaternion rotation)
		{
			var gameObjectInstance = Instantiate(type, position, rotation) as GameObject;

			if (gameObjectInstance != null)
			{
				gameObjectInstance.transform.SetParent(parent.transform);
			}
		}
	}
}
