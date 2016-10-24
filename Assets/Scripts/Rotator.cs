using UnityEngine;

namespace Assets.Scripts
{
	public class Rotator : MonoBehaviour {

		/// <summary>
		/// Update is called once per frame
		/// </summary>
		private void Update () {
			transform.Rotate(new Vector3(0, 0, 45 * Time.deltaTime));
		}

	}
}