using Assets.Scripts.Utilities;

using UnityEngine;

namespace Assets.Scripts.Managers
{
	public class PickupManager : MonoBehaviour
	{
		public GameObject PickupPrefab;
		public GameObject PickupParent;
		public int NumberOfPickups;
		public int PositionRange;

		//private GameObject[] _pickups;

		// Use this for initialization
		private void Start ()
		{
			//_pickups = new GameObject[NumberOfPickups];

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
	
		// Update is called once per frame
		private void Update () {
	
		}
	}
}
