using UnityEngine;
using Photon.Pun;

public class PlayerVisibility : MonoBehaviour
{
    // Reference to the Renderer component of the character model
    public Renderer[] characterRenderers;

    // Start is called before the first frame update
    void Start()
    {
        // Check if this GameObject belongs to the local player
        if (GetComponent<PhotonView>().IsMine)
        {
            // Disable rendering of the character model for the local player
            foreach (Renderer renderer in characterRenderers)
            {
                renderer.enabled = false;
            }
        }
        else
        {
            // Ensure rendering is enabled for other players
            foreach (Renderer renderer in characterRenderers)
            {
                renderer.enabled = true;
            }
        }
    }
}
