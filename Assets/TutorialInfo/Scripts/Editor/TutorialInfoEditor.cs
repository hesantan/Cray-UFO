using UnityEditor;

using UnityEngine;

namespace Assets.TutorialInfo.Scripts.Editor
{
	[CustomEditor(typeof(TutorialInfo))]
	public class TutorialInfoEditor : UnityEditor.Editor 
	{
		/// <summary>
		/// 
		/// </summary>
		private void OnEnable()
		{
			if (PlayerPrefs.HasKey(TutorialInfo.ShowAtStartPrefsKey))
			{
				((TutorialInfo)target).ShowAtStart = PlayerPrefs.GetInt(TutorialInfo.ShowAtStartPrefsKey) == 1;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override void OnInspectorGUI()
		{
			EditorGUI.BeginChangeCheck ();

			base.OnInspectorGUI ();

			if (EditorGUI.EndChangeCheck ()) 
			{
				PlayerPrefs.SetInt(TutorialInfo.ShowAtStartPrefsKey, ((TutorialInfo)target).ShowAtStart ? 1 : 0);
			}
		}
	}
}
