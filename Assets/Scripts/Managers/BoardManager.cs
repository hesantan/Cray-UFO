using UnityEngine;

using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
	public class BoardManager : MonoBehaviour
	{
		[Range(1, 10)]
		public int MaxSizeMultiplier;

		public GameObject TitlesParent;
		public GameObject WallsParent;

		public GameObject WallPrefab;
		public GameObject TitlesPrefab;
		public GameObject[] CornerBlocks;

		private const float WorldSize = 28.4f;
		private const float WorldHalfSize = WorldSize / 2;

		private const float CornerBlockSize = 3.2f;
		private const float CornerBlockHalfSize = CornerBlockSize / 2;

		public static int BoardSize;
		public static float WallSize = CornerBlockSize + 0.1f;
		public static int SizeMultiplier;

		private float _boardOffset;
		private float _originOffset;
		private int _sizeMultiplier;
		private float _stepIncrement;

		private void Awake()
		{
			_sizeMultiplier = Random.Range(1, MaxSizeMultiplier + 1);

			_boardOffset = WorldSize * _sizeMultiplier + CornerBlockHalfSize - (_sizeMultiplier - 1) * CornerBlockSize;
			_stepIncrement = WorldSize - CornerBlockSize;
			_originOffset = WorldHalfSize + CornerBlockHalfSize;

			BoardSize = Mathf.RoundToInt(WorldSize * _sizeMultiplier);
			SizeMultiplier = _sizeMultiplier;
		}

		// Use this for initialization
		private void Start () {
			GenerateMap();
		}

		private void GenerateMap()
		{
			var halfBoardSize = WorldHalfSize * _sizeMultiplier + CornerBlockHalfSize;

			var originX = -halfBoardSize;
			var originY = -halfBoardSize;

			GenerateTitles(originX, originY);
			GenerateWalls(originX, originY);
			SetUpCornerBlocks(originX, originY);
		}

		private void SetUpCornerBlocks(float x, float y)
		{
			var leftOffset = x + CornerBlockHalfSize;
			var rightOffset = y + CornerBlockHalfSize;

			// Bottom Left
			CornerBlocks[0].SetActive(true);
			CornerBlocks[0].transform.position =
				new Vector2(
					leftOffset,
					rightOffset
				);

			// Bottom Right
			CornerBlocks[1].SetActive(true);
			CornerBlocks[1].transform.position =
				new Vector2(
					x + _boardOffset,
					rightOffset
				);

			// Top Left
			CornerBlocks[2].SetActive(true);
			CornerBlocks[2].transform.position =
				new Vector2(
					leftOffset,
					y + _boardOffset
				);

			// Top Right
			CornerBlocks[3].SetActive(true);
			CornerBlocks[3].transform.position =
				new Vector2(
					x + _boardOffset,
					y + _boardOffset
				);
		}

		private void GenerateWalls(float x, float y)
		{
			var currentX = x + _originOffset;
			var currentY = y + _originOffset;

			for (var index = 0; index < _sizeMultiplier; index++)
			{
				// Left Wall
				GenerateWall(
					new Vector2(
						x + CornerBlockHalfSize,
						currentY
					)
				);

				// Right Wall
				GenerateWall(
					new Vector2(
						x + _boardOffset,
						currentY
					)
				);

				// Top Wall
				GenerateWall(
					new Vector2(
						currentX,
						y + _boardOffset
					),
					Quaternion.Euler(0, 0, 90)
				);

				// Bottom Wall
				GenerateWall(
					new Vector2(
						currentX,
						y + CornerBlockHalfSize
					),
					Quaternion.Euler(0, 0, 90f)
				);

				currentX += _stepIncrement;
				currentY += _stepIncrement;
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
			const float adjustment = -0.02f;

			var currentX = x + _originOffset;

			for (var xIndex = 1; xIndex <= _sizeMultiplier; xIndex++)
			{
				var currentY = y + _originOffset;

				for (var yIndex = 1; yIndex <= _sizeMultiplier; yIndex++)
				{
					GenerateTitleBlock(new Vector2(currentX, currentY));

					currentY += _stepIncrement + adjustment;
				}

				currentX += _stepIncrement;
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
