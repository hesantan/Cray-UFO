using UnityEngine;

namespace Assets.Scripts.Utilities
{
	public class Rotator : MonoBehaviour
	{
		public int RotationRate;

		private void Start()
		{

		}

		/// <summary>
		/// Update is called once per frame
		/// </summary>
		private void Update () {
			transform.Rotate(new Vector3(0, 0, RotationRate * Time.deltaTime));
		}
	}
}