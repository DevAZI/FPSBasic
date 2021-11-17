using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCCollision : MonoBehaviour
{
    public GameObject heat;
   
    public int healthValue = 10;


   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.AddCount(-1);          
            GameController.instance.MinusHealth(healthValue);
            ContactPoint contact = collision.contacts[0];   // 총알과의 충돌지점 
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);   // 충돌지점의 방향
            Instantiate(heat, contact.point, rotation); // 충돌후 폭파(instantiateExplosion) 오브젝트 생성
            
            Destroy(gameObject);
           if (GameController.instance.health == 0) GameController.instance.GameOver();
        }
        else return;      // Floor 혹은 다른 물체와의 충돌 무시
    }
}
