using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StandardFieldFactory : AbstractFactory
{
    protected RectTransform _battlefield;
	protected FieldController[,] _fields;
	public FieldController[,] Fields { get { return _fields; } }

    public override void Build()
    {
		// initialization of building process
		base.Build();
		_battlefield = GameController.Instance.Battlefield;
		int rows = GameController.Instance.GameSettings.FieldSettings.Rows;
		int columns = GameController.Instance.GameSettings.FieldSettings.Columns;
		_fields = new FieldController[rows,columns];

		//building process below
		//add layout to the field and set alignments corresponding to the settings
		GridLayoutGroup layout = _battlefield.gameObject.AddComponent<GridLayoutGroup>();
		layout.cellSize = new Vector2(_battlefield.rect.width / _gameSettings.FieldSettings.Columns,
									  _battlefield.rect.height / _gameSettings.FieldSettings.Rows);
		layout.childAlignment = TextAnchor.MiddleCenter;

        //creation process below. from left to right, row after row
        for (int i = 0; i < _gameSettings.FieldSettings.Rows; i++)
        {
            for (int j = 0; j < _gameSettings.FieldSettings.Columns; j++)
            {
                //instantiate the field and set the settings of the field
                GameObject @object = Instantiate(_gameSettings.FieldSettings.FieldPrefab, _battlefield.transform);
				FieldController field = @object.AddComponent<FieldController>();
				field.Row = (uint)i;
				field.Column = (uint)j;
				_fields[i, j] = field;
            }
        }
    }
}
