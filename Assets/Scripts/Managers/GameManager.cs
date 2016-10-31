using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
	public class GameManager : MonoBehaviour
	{
		[HideInInspector]
		public static int Score;

		public Text ScoreText;
		public Text WinText;
		public AudioClip SuccessAudio;
		public PickupManager PickupManager;

		private AudioSource _audioSource;

		private bool _gameWon;

		// Use this for initialization
		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();

			Score = 0;

			WinText.text = "";
			UpdateScore();
		}


		// Update is called once per frame
		private void Update()
		{
			UpdateScore();
			CheckWin();
		}

		/// <summary>
		/// 
		/// </summary>
		private void UpdateScore()
		{
			ScoreText.text = "Score: " + Score;
		}

		private void CheckWin()
		{
			if (_gameWon || (Score < PickupManager.NumberOfPickups))
			{
				return;
			}

			WinText.text = "You win!";

			_gameWon = true;
			_audioSource.PlayOneShot(SuccessAudio, .75f);
		}
	}
}
