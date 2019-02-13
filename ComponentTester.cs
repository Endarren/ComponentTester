//<author>Nicholas Irwin</author>
//<company> nonPareil Institute</company>
//<copyright file ="ComponentTester.cs" All Rights Reserved
//</copyright>
//<date>1/24/2018</date>

namespace npScripts.Utilities
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;
#if UNITY_EDITOR
	using UnityEditor;
#endif


	/// <summary>
	/// This class is used to test specific methods on demand.
	/// </summary>
	public class ComponentTester : MonoBehaviour
	{
		#region Fields

		/// <summary>
		/// The event for the tests.
		/// </summary>
		[SerializeField]
		private TesterButtonEvent m_onTest = new TesterButtonEvent();

		#endregion

		#region Methods

		/// <summary>
		/// The DoInvoke
		/// </summary>
		public void DoInvoke()
		{
			m_onTest.Invoke();
		}

		#endregion

		/// <summary>
		/// An implementation of UnityEvent
		/// </summary>
		[Serializable]
		public class TesterButtonEvent : UnityEvent
		{
		}
	}
#if UNITY_EDITOR

	[CustomEditor(typeof(ComponentTester))]
	public class ComponentTesterInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_onTest"));
			EditorGUI.BeginDisabledGroup(!Application.isPlaying);

			if (GUILayout.Button("Perform Methods"))
			{
				((ComponentTester)target).DoInvoke();
			}
			EditorGUI.EndDisabledGroup();
			serializedObject.ApplyModifiedProperties();
		}
	}
#endif
}
