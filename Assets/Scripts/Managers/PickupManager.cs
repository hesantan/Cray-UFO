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
		public int MaxPickups;

		[HideInInspector]
		public int NumberOfPickups;

		private int _positionRange;

		// Use this for initialization
		private void Start ()
		{
			_positionRange = GetPositionRange();

			NumberOfPickups = 
				Random.Range(
					10 * BoardManager.SizeMultiplier, 
					(MaxPickups + 1) * BoardManager.SizeMultiplier
				);

			PlaceRandomPickups();
		}

		private void PlaceRandomPickups()
		{
			for (var i = 0; i < NumberOfPickups; i++)
			{
				var pickupPrefab = Instantiate(
					PickupPrefab,
					Randomizer.GetRandomPosition(_positionRange, true, true, false),
					Randomizer.GetRandomRotation(false, false)
				) as GameObject;

				if (pickupPrefab != null)
				{
					pickupPrefab.transform.SetParent(PickupParent.transform);
				}
			}
		}

		private static int GetPositionRange()
		{
			return BoardManager.BoardSize / 2 - 2;
		}
	}
}
