// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;
using Normal.Realtime;

[RealtimeModel]
public partial class PlayerModel
{
  [RealtimeProperty(1, true, true)]
  private string _playerName;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class PlayerModel : RealtimeModel {
    public string playerName {
        get {
            return _playerNameProperty.value;
        }
        set {
            if (_playerNameProperty.value == value) return;
            _playerNameProperty.value = value;
            InvalidateReliableLength();
            FirePlayerNameDidChange(value);
        }
    }

    public delegate void PropertyChangedHandler<in T>(PlayerModel model, T value);
    public event PropertyChangedHandler<string> playerNameDidChange;

    public enum PropertyID : uint {
        PlayerName = 1,
    }

    #region Properties

    private ReliableProperty<string> _playerNameProperty;

    #endregion

    public PlayerModel() : base(null) {
        _playerNameProperty = new ReliableProperty<string>(1, _playerName);
    }

    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _playerNameProperty.UnsubscribeCallback();
    }

    private void FirePlayerNameDidChange(string value) {
        try {
            playerNameDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }

    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _playerNameProperty.WriteLength(context);
        return length;
    }

    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _playerNameProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }

    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.PlayerName: {
                    changed = _playerNameProperty.Read(stream, context);
                    if (changed) FirePlayerNameDidChange(playerName);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }

    private void UpdateBackingFields() {
        _playerName = playerName;
    }

}
/* ----- End Normal Autogenerated Code ----- */
