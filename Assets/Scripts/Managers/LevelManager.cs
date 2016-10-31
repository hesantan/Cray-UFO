using UnityEngine;

using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
	public class LevelManager : MonoBehaviour
	{
		[Range(1,10)]
		public int MinSizeMultiplier;

		[Range(1, 10)]
		public int MaxSizeMultiplier;

		[HideInInspector]
		public int SizeMultiplier;

		private const float TitlesBlockSize = 28.6f;
		private const float WallSize = 15.1f;
		private const float CornerBlockSize = 12.1f;

		// Use this for initialization
		private void Start () {
			SizeMultiplier = Random.Range(MinSizeMultiplier, MaxSizeMultiplier + 1);
		}

		// Update is called once per frame
		private void Update () {
	
		}

		private void GenerateTitles()
		{
			
		}

		private void GenerateWalls()
		{
			
		}

		private void GenerateCornerBlocks()
		{
			
		}

		private void AddWallColliders()
		{
			
		}
	}
}
