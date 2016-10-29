using System;

using UnityEngine;

using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
	public class LevelManager : MonoBehaviour
	{

		public int MinSizeMultiplier;
		public int MaxSizeMultiplier;

		[HideInInspector]
		public int SizeMultiplier;

		private const int MinimunSizeMultiplier = 1;
		private const int MaximunSizeMultiplier = 10;

		private const float TitlesBlockSize = 28.6f;
		private const float WallSize = 15.1f;
		private const float CornerBlockSize = 12.1f;

		// Use this for initialization
		private void Start () {
			var minimumSizeMultiplier = Math.Max(MinimunSizeMultiplier, MinSizeMultiplier);
			var maximunSizeMultiplier = Math.Min(MaximunSizeMultiplier, MaxSizeMultiplier) + 1;

			SizeMultiplier = Random.Range(minimumSizeMultiplier, maximunSizeMultiplier);
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
