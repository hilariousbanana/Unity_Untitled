﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoSingleton<HUDManager>
{
    [SerializeField]
    private GunController gunCtrl;
    private Weapon curWeapon;

    [SerializeField]
    private GameObject WeaponHUD;

    [SerializeField]
    private Text[] text_Bullet;

    [SerializeField]
    private Text PlayerHP;
    private PlayerController player;

    public GameObject RespawnBar;

    //[SerializeField]
    //private Image img_Weapon;
    [SerializeField]
    private Animator Anim;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        CheckBullet();
        CheckPlayerHP();
    }

    private void CheckBullet()
    {
        curWeapon = gunCtrl.GetWeapon();
        Anim.SetTrigger(curWeapon.WeaponType);
        //img_Weapon.sprite = curWeapon.WeaponImage;
        text_Bullet[0].text = curWeapon.CurBulletCount.ToString();
        text_Bullet[1].text = curWeapon.MaxBulletCount.ToString();
        text_Bullet[2].text = curWeapon.ReloadCount.ToString();
        text_Bullet[3].text = curWeapon.WeaponType;
    }

    private void CheckPlayerHP()
    {
        PlayerHP.text = player.GetPlayerHP().ToString();
    }
}
