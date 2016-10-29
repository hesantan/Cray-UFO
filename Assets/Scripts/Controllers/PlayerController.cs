using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
	/// <summary>
	/// Controller for player actions
	/// </summary>
	public class PlayerController : MonoBehaviour
	{
		public float Speed;
		public Text CountText;
		public Text WinText;
		public AudioClip CollectPickupAudio;
		public AudioClip SuccessAudio;

		private Rigidbody2D _rigidbody2D;
		private AudioSource _audioSource;
		private int _count;
		private const string CollectiablesTag = "PickUp";
		private int _totalNumberOfCollectibles;

		/// <summary>
		/// 
		/// </summary>
		private void Start()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_audioSource = GetComponent<AudioSource>();
			_totalNumberOfCollectibles = GameObject.FindGameObjectsWithTag(CollectiablesTag).Length;

			WinText.text = "";
			SetCountText();
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

			_audioSource.clip = CollectPickupAudio;
			_audioSource.Play();
			other.gameObject.SetActive(false);
			_count++;
			SetCountText();
		}

		/// <summary>
		/// 
		/// </summary>
		private void SetCountText()
		{
			CountText.text = "Count: " + _count;

			if (_count < _totalNumberOfCollectibles)
			{
				return;
			}

			_audioSource.clip = SuccessAudio;
			_audioSource.Play();
			WinText.text = "You win!";
		}
	}
}
