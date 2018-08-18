using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StandardFieldFactory : AbstractFactory
{
    protected RectTransform _battlefield;
	protected List<FieldController> _fields = new List<FieldController>();
	public FieldController[] Fields { get { return _fields.ToArray(); } }

    public override void Build()
    {
		// initialization of building process
		base.Build();
		_battlefield = GameController.Instance.Battlefield;

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
				field.Row = (uint)i + 1;
				field.Column = (uint)j + 1;
				_fields.Add(field);
            }
        }
    }
}
