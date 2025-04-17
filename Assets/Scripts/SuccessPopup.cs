using UnityEngine;

public class SuccessPopup : Basepopup
{
    public Basepopup basepopup;
    public void OnStartAgainButton()
    {
        Close();
        //Messenger.Broadcast(GameEvent.RESTART_GAME);
    }
    
}
