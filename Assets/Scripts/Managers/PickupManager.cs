using Assets.Scripts.Utilities;

using UnityEngine;

using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
	public class PickupManager : MonoBehaviour
	{
		public GameObject PickupPrefab;
		public GameObject PickupParent;

		[Range(10, 500)]
		public int MinPickups;

		[Range(10, 500)]
		public int MaxPickups;

		public int PositionRange;

		[HideInInspector]
		public int NumberOfPickups;

		// Use this for initialization
		private void Start ()
		{
			EnsurePickupCounts();
			NumberOfPickups = Random.Range(MinPickups, MaxPickups + 1);

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

		private void EnsurePickupCounts()
		{
			var minPickups = Mathf.Min(MinPickups, MaxPickups);
			var maxPickups = Mathf.Max(MinPickups, MaxPickups);

			MinPickups = minPickups;
			MaxPickups = maxPickups;
		}
	}
}
