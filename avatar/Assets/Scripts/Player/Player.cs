// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Player : RealtimeComponent<PlayerModel>
{
  public string playerName;
  private PlayerModel _model;

  private PlayerModel model
  {
    set
    {
      if (_model != null)
      {
     // Unregister from events
        _model.playerNameDidChange -= PlayerNameChanged;
      }

      _model = value;
      if (_model != null)
      {
    //update
        UpdatePlayerName();
     //register
        _model.playerNameDidChange += PlayerNameChanged;
      }
    }
  }
  private void PlayerNameChanged(PlayerModel model, string value)
  {
    UpdatePlayerName();
  }
  private void UpdatePlayerName()
  {
    // Update the player name
    playerName = _model.playerName;
  }

  public void SetPlayerName(string _name)
  {
    // Update the UI
    _model.playerName = _name;
  }
}
