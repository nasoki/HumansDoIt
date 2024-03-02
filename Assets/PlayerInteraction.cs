using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform rayOrigin;
    public float playerReach = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRaycast();
    }
    void PlayerRaycast()
    {
        Ray ray = new Ray(rayOrigin.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.CompareTag("Artifact"))
            {
                //hit.collider.GetComponent<Outline>().enabled = true;
                Debug.Log("gj bud");
            }
        }
        Debug.DrawRay(rayOrigin.position, Camera.main.transform.forward, Color.red);
    }
}
