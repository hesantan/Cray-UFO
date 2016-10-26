using UnityEngine;

namespace Assets.Scripts
{
	public class Randomizer : MonoBehaviour
	{
		public bool RandomStart = true;
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
			transform.localPosition =
				new Vector3(
					Random.Range(PositionRange * -1, PositionRange),
					Random.Range(PositionRange * -1, PositionRange),
					0
					);
		}

		private void RotateRandom()
		{
			transform.localRotation = Quaternion.Euler(Random.rotation.x, Random.rotation.y, 0f);
		}
	}
}
