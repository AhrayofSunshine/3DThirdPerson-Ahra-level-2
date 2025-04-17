using UnityEngine;

public class Basepopup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    virtual public void Open()
    {
        if (!IsActive())
        {
            this.gameObject.SetActive(true);
        } else
        {
            Debug.LogError(this + ".Open() – trying to open a popup");
        }
           
    }

    // Update is called once per frame
    virtual public void Close()
    {
        //gameObject.SetActive(false);
        if (IsActive())
        {
            this.gameObject.SetActive(false);
            //Messenger.Broadcast(GameEvent.POPUP_CLOSED);
        }
        else
        {
            Debug.LogError(this + ".Close() – trying to close a popup that is active!");
        }
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
