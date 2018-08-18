using System.Collections;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
	[SerializeField]
	private GameSettingsModel _gameSettings;
	public GameSettingsModel GameSettings { get { return _gameSettings; } }
	
	[SerializeField]
	private StandardFieldFactory _fieldFactory;

	[SerializeField]
	protected RectTransform _battlefield;
	public RectTransform Battlefield { get { return _battlefield; } }

	private Vector2 _singleFieldSize;
	public Vector2 SingleFieldSize { get { return _singleFieldSize; } }

	[SerializeField]
	private StandardShipChoosingFactory _shipChoosingFactory;

	[SerializeField]
	protected RectTransform _shipChoosingField;
	public RectTransform ShipChoosingField { get { return _shipChoosingField; } }

	public ShipController SelectedShip;

	protected virtual void Start()
	{
		if (_gameSettings == null)
			Debug.LogError("No game settings reference set in GameController!");

		_singleFieldSize = new Vector2(_battlefield.rect.width / _gameSettings.FieldSettings.Columns,
									  _battlefield.rect.height / _gameSettings.FieldSettings.Rows);
		_fieldFactory.Build();
		foreach (FieldController field in _fieldFactory.Fields)
		{
			field.SetBehaviour(new ShipPlacementFieldBehaviour());
		}

		_shipChoosingFactory.Build();
	}
}
