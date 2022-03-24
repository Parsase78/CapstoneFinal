using Normal.Realtime;
using TMPro;

public class AvatarAttributesSync : RealtimeComponent<PlayerModel>
{
  public TextMeshProUGUI playerNameText;

  private string playerName1;

  private static string[] adjectives = new string[] { "Magical", "Cool", "Nice", "Funny", "Fancy", "Glorious", "Weird", "Awesome" };

  private static string[] nouns = new string[] { "Girl", "Guy", "Dad", "Dude", "Child", "Steve" };

  private bool _isSelf;

  public string PlayerName => model.playerName;

  private void Start()
  {
    if (GetComponent<RealtimeAvatar>().isOwnedLocallyInHierarchy)
    {
      _isSelf = true;

      // Generate a funny random name
      playerName1 = adjectives[UnityEngine.Random.Range(0, adjectives.Length)] + " " + nouns[UnityEngine.Random.Range(0, nouns.Length)];

      // Assign the nickname to the model which will automatically be sent to the server and broadcast to other clients
      model.playerName = playerName1;

      // We don't need to see our own nickname
      playerNameText.enabled = false;
    }
  }

  protected override void OnRealtimeModelReplaced(PlayerModel previousModel, PlayerModel currentModel)
  {
    if (previousModel != null)
    {
      // Unregister from events
      previousModel.playerNameDidChange -= PlayerNameChanged;
    }

    if (currentModel != null)
    {
      if (currentModel.isFreshModel)
      {
        currentModel.playerName = "";
      }

      UpdatePlayerName();

      currentModel.playerNameDidChange += PlayerNameChanged;
    }
  }

  private void PlayerNameChanged(PlayerModel model, string playerName)
  {
    UpdatePlayerName();
  }

  private void UpdatePlayerName()
  {
    // Update the UI
    playerNameText.text = model.playerName;
  }
}
