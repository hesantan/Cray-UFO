using UnityEngine;

namespace Assets.Scripts.Controllers
{
	public class CameraController : MonoBehaviour {

		public GameObject Player;
		private Vector3 _offset;

		/// <summary>
		/// Use this for initialization
		/// </summary>
		private void Start ()
		{
			_offset = transform.position - Player.transform.position;
		}

		/// <summary>
		/// Update is called once per frame
		/// </summary>
		private void Update ()
		{
			
		}

		/// <summary>
		/// Update is called once per frame after Update
		/// </summary>
		private void LateUpdate()
		{
			transform.position = Player.transform.position + _offset;
		}
	}
}
