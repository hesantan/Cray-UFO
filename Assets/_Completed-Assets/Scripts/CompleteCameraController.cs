using UnityEngine;

namespace Assets.Scripts
{
	public class CompleteCameraController : MonoBehaviour
	{
		/// <summary>
		/// Public variable to store a reference to the player game object
		/// </summary>
		public GameObject Player;

		/// <summary>
		/// Private variable to store the offset distance between the player and camera
		/// </summary>
		private Vector3 _offset;

		/// <summary>
		/// Use this for initialization
		/// </summary>
		private void Start()
		{
			// Calculate and store the offset value by getting the distance between the player's position and camera's position.
			_offset = transform.position - Player.transform.position;
		}

		/// <summary>
		/// LateUpdate is called after Update each frame
		/// </summary>
		private void LateUpdate()
		{
			// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
			transform.position = Player.transform.position + _offset;
		}
	}
}
