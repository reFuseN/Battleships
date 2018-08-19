using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
	[SerializeField]
	private GameSettingsModel _gameSettings;
	public GameSettingsModel GameSettings { get { return _gameSettings; } }
	
	[SerializeField]
	private StandardFieldFactory _fieldFactory;
	public StandardFieldFactory FieldFactory { get { return _fieldFactory; } }

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
		// iterate through 2D array of the fields
		for (int i = 0; i < _fieldFactory.Fields.GetLength(0); i++)
		{
			for (int j = 0; j < _fieldFactory.Fields.GetLength(1); j++)
			{
				FieldController field = _fieldFactory.Fields[i, j];
				field.SetBehaviour(new ShipPlacementFieldBehaviour(field, _fieldFactory.Fields, field.Row, field.Column));
			}
		}

		_shipChoosingFactory.Build();
	}

	public void SetSelectedShipAlignmentVertical()
	{
		if (SelectedShip != null)
			SelectedShip.Alignment = ALIGNMENT_AXIS.VERTICAL;
	}

	public void SetSelectedShipAlignmentHorizontal()
	{
		if (SelectedShip != null)
			SelectedShip.Alignment = ALIGNMENT_AXIS.HORIZONTAL;
	}
}
