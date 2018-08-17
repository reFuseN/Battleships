using UnityEngine;

[CreateAssetMenu]
public class GameSettingsModel : ScriptableObject
{
    [SerializeField]
    private FieldSettingsModel _fieldSettings;
    public FieldSettingsModel FieldSettings { get { return _fieldSettings; } }
    [SerializeField]
    private ShipSettingsModel[] _battleships;
    public ShipSettingsModel[] Battleships { get { return _battleships; } }
}
