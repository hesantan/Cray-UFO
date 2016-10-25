using UnityEngine;

namespace Assets.Scripts
{
	public class Rotator : MonoBehaviour
	{
		private void Start()
		{
			PlaceRandom();
			gameObject.SetActive(true);
		}

		/// <summary>
		/// Update is called once per frame
		/// </summary>
		private void Update () {
			transform.Rotate(new Vector3(0, 0, 45 * Time.deltaTime));
		}

		private void PlaceRandom()
		{
			transform.localPosition = new Vector3(Random.Range(-11, 11), Random.Range(-11, 11), 0);
		}
	}
}