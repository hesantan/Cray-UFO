using System;

using Assets.Scripts.Utilities;

using UnityEngine;

using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
	public class PickupManager : MonoBehaviour
	{
		public GameObject PickupPrefab;
		public GameObject PickupParent;
		public int MinPickups;
		public int MaxPickups;
		public int PositionRange;

		[HideInInspector]
		public int NumberOfPickups;

		private const int MinimunPickups = 10;
		private const int MaximunPickups = 1000;

		// Use this for initialization
		private void Start ()
		{
			var minimumPickups = Math.Max(MinimunPickups, MinPickups);
			var maximunPickups = Math.Min(MaximunPickups, MaxPickups) + 1;

			NumberOfPickups = Random.Range(minimumPickups, maximunPickups);

			PlaceRandomPickups();
		}
	
		// Update is called once per frame
		private void Update () {
	
		}

		private void PlaceRandomPickups()
		{
			for (var i = 0; i < NumberOfPickups; i++)
			{
				var pickupPrefab = Instantiate(
					PickupPrefab,
					Randomizer.GetRandomPosition(PositionRange, true, true, false),
					Randomizer.GetRandomRotation(true, true, false)
				) as GameObject;

				if (pickupPrefab != null)
				{
					pickupPrefab.transform.SetParent(PickupParent.transform);
				}
			}
		}
	}
}
