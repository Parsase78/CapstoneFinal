using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class AvatarAttributesModel
{
  [RealtimeProperty(1, true, true)]
  private string _nickname;
}
