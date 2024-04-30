using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
  
    
   private void FixedUpdate()
   {
       transform.position = new Vector3(player.position.x, player.position.y, -10);
   }
}
