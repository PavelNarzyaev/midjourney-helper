using Newtonsoft.Json;
using UnityEngine;

public class PlayerPrefsModel
{
    private const string key = "save";

    public StateModel currentState;

    public PlayerPrefsModel()
    {
        Load();
    }

    private void Load()
    {
        var stateJson = PlayerPrefs.GetString(key);
        currentState = JsonConvert.DeserializeObject<StateModel>(stateJson) ?? new StateModel();
    }

    public void Save()
    {
        var stateJson = JsonConvert.SerializeObject(currentState);
        PlayerPrefs.SetString(key, stateJson);
    }
}
