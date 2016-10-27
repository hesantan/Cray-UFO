using UnityEngine;

namespace Assets.Scripts.Utilities
{
	public class Randomizer : MonoBehaviour
	{
		public bool RandomStart = false;
		public bool RandomRotation = false;

		public int PositionRange;

		// Use this for initialization
		private void Start () {

			gameObject.SetActive(true);

			if (RandomStart)
			{
				PlaceRandom();
			}

			if (RandomRotation)
			{
				RotateRandom();
			}
		}

		// Update is called once per frame
		private void Update () {
	
		}

		private void PlaceRandom()
		{
			transform.localPosition = GetRandomPosition(PositionRange, true, true, false);
		}

		private void RotateRandom()
		{
			transform.localRotation = GetRandomRotation(true, false, false);
		}

		public static Vector3 GetRandomPosition(float range, bool moveX = true, bool moveY = true, bool moveZ = true)
		{
			var pointX = moveX ? Random.Range(range * -1, range) : 0f;
			var pointY = moveY ? Random.Range(range * -1, range) : 0f;
			var pointZ = moveZ ? Random.Range(range * -1, range) : 0f;

			return new Vector3(pointX, pointY, pointZ);
		}

		public static Quaternion GetRandomRotation(bool rotateX = true, bool rotateY = true, bool rotateZ = true)
		{
			var randomX = rotateX ? Random.rotation.x : 0f;
			var randomY = rotateY ? Random.rotation.y : 0f;
			var randomZ = rotateZ ? Random.rotation.z : 0f;

			return Quaternion.Euler(randomX, randomY, randomZ);
		}
	}
}
