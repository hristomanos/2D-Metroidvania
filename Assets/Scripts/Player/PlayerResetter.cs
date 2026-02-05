using UnityEngine;

namespace Player
{
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
}
