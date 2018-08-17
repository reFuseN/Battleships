using UnityEngine;

[CreateAssetMenu]
public class FieldSettingsModel : ScriptableObject
{
    [SerializeField]
    private uint _rows;
    public int Rows { get { return (int)_rows; } }
    [SerializeField]
    private uint _columns;
    public int Columns { get { return (int)_columns; } }
    [SerializeField]
    private GameObject _fieldPrefab;
    public GameObject FieldPrefab { get { return _fieldPrefab; } }
}
