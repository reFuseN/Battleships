using UnityEngine;
using UnityEngine.UI;

public class StandardFieldFactory : AbstractFactory
{
    protected RectTransform _battlefield;

	protected override void Start()
	{
		_battlefield = GameController.Instance.Battlefield;
		base.Start();
	}

    protected override void Build()
    {
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
                Instantiate(_gameSettings.FieldSettings.FieldPrefab, _battlefield.transform);
            }
        }
    }
}
