using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetter : MonoBehaviour
{

    private delegate void PlayerReset();

    private PlayerReset playerResetter;

    [SerializeField] int fallThreshold;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < fallThreshold)
        {
            playerResetter.Invoke();
        }
    }
}
