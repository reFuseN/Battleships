using UnityEngine;

[CreateAssetMenu]
public class ShipSettingsModel : ScriptableObject
{
    [SerializeField]
    private uint _id;
    public int ID { get { return (int)_id; } }
    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }
    [SerializeField]
    private uint _fieldSize;
    public int FieldSize { get { return (int)_fieldSize; } }
	[SerializeField]
	private GameObject _shipObject;
	public GameObject ShipObject { get { return _shipObject; } }
}
