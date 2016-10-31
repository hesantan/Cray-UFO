using UnityEngine;
using UnityEngine.UI;

namespace Assets.TutorialInfo.Scripts
{
	// Hi! This script presents the overlay info for our tutorial content, linking you back to the relevant page.
	public class TutorialInfo : MonoBehaviour
	{
		// allow user to choose whether to show this menu 
		public bool ShowAtStart = true;

		// location that Visit Tutorial button sends the user
		public string Url;

		// store the GameObject which renders the overlay info
		public GameObject Overlay;

		// store a reference to the audio listener in the scene, allowing for muting of the scene during the overlay
		public AudioListener MainListener;

		// store a reference to the UI toggle which allows users to switch it off for future plays
		public Toggle ShowAtStartToggle;

		// string to store Prefs Key with name of preference for showing the overlay info
		public static string ShowAtStartPrefsKey = "showLaunchScreen";

		private AudioSource _audioSource;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();

			// Check player prefs for show at start preference
			if (PlayerPrefs.HasKey(ShowAtStartPrefsKey))
			{
				ShowAtStart = PlayerPrefs.GetInt(ShowAtStartPrefsKey) == 1;
			}

			// set UI toggle to match the existing UI preference
			ShowAtStartToggle.isOn = ShowAtStart;

			// show the overlay info or continue to play the game
			if (ShowAtStart) 
			{
				ShowLaunchScreen();
			}
			else 
			{
				StartGame();
			}

		}

		// show overlay info, pausing game time, disabling the audio listener 
		// and enabling the overlay info parent game object
		public void ShowLaunchScreen()
		{
			Time.timeScale = 0f;
			MainListener.enabled = false;
			Overlay.SetActive (true);
		}

		// open the stored URL for this content in a web browser
		public void LaunchProjectSite()
		{
			Application.OpenURL(Url);
		}

		// continue to play, by ensuring the preference is set correctly, the overlay is not active, 
		// and that the audio listener is enabled, and time scale is 1 (normal)
		public void StartGame()
		{
			Overlay.SetActive(false);
			MainListener.enabled = true;
			Time.timeScale = 1f;
			_audioSource.Play();
		}

		// set the boolean storing show at start status to equal the UI toggle's status
		public void ToggleShowAtLaunch()
		{
			ShowAtStart = ShowAtStartToggle.isOn;
			PlayerPrefs.SetInt(ShowAtStartPrefsKey, ShowAtStart ? 1 : 0);
		}
	}
}
