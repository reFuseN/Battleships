using UnityEngine;

/// <summary>
/// Child class for easy implementation of singletons
/// </summary>
/// <typeparam name="T">Type is the class you want to make a singleton.</typeparam>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
	public static T Instance { get; private set; }

	/// <summary>
	/// Destroys duplicate instances and their game object and sets new instance
	/// </summary>
	protected virtual void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Duplicate instance of " + name);
			Destroy(this.gameObject);
		}
		Instance = (T)this;
	}

	/// <summary>
	/// prevents the singleton from being accessed on OnDestroy
	/// </summary>
	void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}

