using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CustomStringEvent : UnityEvent <string> {}

public class EventManager : MonoBehaviour {

	private Dictionary <string, CustomStringEvent> eventDictionary;

	private static EventManager eventManager;

	void Awake() {
		//DontDestroyOnLoad(this.gameObject);
	}
			
	public static EventManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

				if (!eventManager)
				{
					Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init (); 
				}
			}

			return eventManager;
		}
	}

	void Init ()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, CustomStringEvent>();
		}
	}

	public static void StartListening (string eventName, UnityAction<string> listener)
	{
		//UnityEvent thisEvent = null;
		CustomStringEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		} 
		else
		{
			thisEvent = new CustomStringEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}

	public static void StopListening (string eventName, UnityAction<string> listener)
	{
		if (eventManager == null) return;
		CustomStringEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent (string eventName, string value = null)
	{
		CustomStringEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke (value);
		}
	}


		
}


