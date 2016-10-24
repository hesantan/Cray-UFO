﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	/// <summary>
	/// Controller for player actions
	/// </summary>
	public class PlayerController : MonoBehaviour
	{
		public float Speed;
		public Text CountText;
		public Text WinText;

		private Rigidbody2D _rigidbody2D;
		private int _count;

		/// <summary>
		/// 
		/// </summary>
		private void Start()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_count = 0;
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
			if (!other.gameObject.CompareTag("PickUp"))
			{
				return;
			}

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

			if (_count >= 12)
			{
				WinText.text = "You win!";
			}
		}
	}
}
