using Assets.Scripts.Managers;

using UnityEngine;

namespace Assets.Scripts.Controllers
{
	/// <summary>
	/// Controller for player actions
	/// </summary>
	public class PlayerController : MonoBehaviour
	{
		public float Speed;
		public AudioClip CollectPickupAudio;

		private Rigidbody2D _rigidbody2D;
		private AudioSource _audioSource;
		private const string CollectiablesTag = "PickUp";

		/// <summary>
		/// 
		/// </summary>
		private void Start()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_audioSource = GetComponent<AudioSource>();
		}

		/// <summary>
		/// 
		/// </summary>
		private void FixedUpdate()
		{
			var moveHorizontal = Input.GetAxis("Horizontal");
			var moveVertical = Input.GetAxis("Vertical");
			var movement = new Vector2(moveHorizontal, moveVertical);

			_rigidbody2D.AddForce(movement * Speed);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="other"></param>
		private void OnTriggerEnter2D(Component other)
		{
			if (!other.gameObject.CompareTag(CollectiablesTag))
			{
				return;
			}

			other.gameObject.SetActive(false);

			GameManager.Score++;

			_audioSource.clip = CollectPickupAudio;
			_audioSource.Play();
		}
	}
}
