using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	/// <summary>
	/// Adding this allows us to access members of the UI namespace including Text.
	/// </summary>
	public class CompletePlayerController : MonoBehaviour {

		public float Speed;				//Floating point variable to store the player's movement speed.
		public Text CountText;			//Store a reference to the UI Text component which will display the number of pickups collected.
		public Text WinText;			//Store a reference to the UI Text component which will display the 'You win' message.

		private Rigidbody2D _rb2D;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
		private int _count;             //Integer to store the number of pickups collected so far.

		/// <summary>
		/// Use this for initialization
		/// </summary>
		private void Start()
		{
			//Get and store a reference to the Rigidbody2D component so that we can access it.
			_rb2D = GetComponent<Rigidbody2D> ();

			//Initialize count to zero.
			_count = 0;

			//Initialize winText to a blank string since we haven't won yet at beginning.
			WinText.text = "";

			//Call our SetCountText function which will update the text with the current value for count.
			SetCountText ();
		}

		/// <summary>
		/// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
		/// </summary>
		private void FixedUpdate()
		{
			//Store the current horizontal input in the float moveHorizontal.
			var moveHorizontal = Input.GetAxis ("Horizontal");

			//Store the current vertical input in the float moveVertical.
			var moveVertical = Input.GetAxis ("Vertical");

			//Use the two store floats to create a new Vector2 variable movement.
			var movement = new Vector2 (moveHorizontal, moveVertical);

			//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
			_rb2D.AddForce (movement * Speed);
		}

		/// <summary>
		/// OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
		/// </summary>
		/// <param name="other">The other component currently colliding with this one</param>
		private void OnTriggerEnter2D(Component other)
		{
			//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
			if (!other.gameObject.CompareTag("PickUp"))
			{
				return;
			}

			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);

			//Add one to the current value of our count variable.
			_count = _count + 1;

			//Update the currently displayed count by calling the SetCountText function.
			SetCountText ();
		}

		/// <summary>
		/// This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
		/// </summary>
		private void SetCountText()
		{
			//Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
			CountText.text = "Count: " + _count;

			//Check if we've collected all 12 pickups. If we have...
			if (_count >= 12)
			{
				//... then set the text property of our winText object to "You win!"
				WinText.text = "You win!";
			}
		}
	}
}
