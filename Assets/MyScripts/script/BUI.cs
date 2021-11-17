using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BUI : MonoBehaviour
{

    public GunController thegunController;
    public Gun CurrnetGun;
    public GameObject go_BulletHUD;
    public Text[] text_Bullet;
   
    // Update is called once per frame
    void Update()
    {
        CheckBullet();
        
    }
    void CheckBullet()
    {
        CurrnetGun = thegunController.GetGun();
        text_Bullet[0].text = CurrnetGun.currentBulletCount.ToString();
        text_Bullet[1].text = CurrnetGun.reloadBulletCount.ToString();
        text_Bullet[2].text = CurrnetGun.carryBulletCount.ToString();
    }
}
