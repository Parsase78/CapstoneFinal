// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;

public class UpdateLocalPlayer : MonoBehaviour
{
    private string _localPlayerName;
    private RealtimeAvatarManager _realtimeAvatarManager;
    private Realtime _realtime;

    private void Awake()
    {
        _realtime = GetComponent<Realtime>();
        _realtimeAvatarManager = GetComponent<RealtimeAvatarManager>();

    }

    public void SaveLocalPlayerName(TextMeshProUGUI nameField)
    {
        _localPlayerName = nameField.text;
        if(_realtime.connected)
        {
            TransferLocalPlayerInfoToModel();
        }
    }

    public void TransferLocalPlayerInfoToModel()
    {
      
    }
}
