using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
	[SerializeField]
	private GameSettingsModel _gameSettings;
	public GameSettingsModel GameSettings { get { return _gameSettings; } }
	[SerializeField]
	private RectTransform _battlefield;
	public RectTransform Battlefield { get { return _battlefield; } }
	private Vector2 _singleFieldSize;
	public Vector2 SingleFieldSize { get { return _singleFieldSize; } }
	[SerializeField]
	private RectTransform _shipChoosingField;
	public RectTransform ShipChoosingField { get { return _shipChoosingField; } }

	protected override void Awake()
	{
		base.Awake();
		if (_battlefield != null)
		{
			_singleFieldSize = new Vector2(_battlefield.rect.width / _gameSettings.FieldSettings.Columns,
										   _battlefield.rect.height / _gameSettings.FieldSettings.Rows);
		}
		else
		{
			Debug.LogError("No battlefield reference set in GameController!");
		}

		if (_gameSettings == null)
		{
			Debug.LogError("No game settings reference set in GameController!");
		}
		if (_shipChoosingField == null)
		{
			Debug.LogError("No ship choosing field reference set in GameController!");
		}
	}
}
