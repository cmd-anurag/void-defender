using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoUI;
    private int ammo = 10;

    void OnEnable() {
        SpaceshipControllerScript.OnSpaceShipShoot += SubtractBullet;
        SpaceshipControllerScript.OnSpaceShipStartReload += StartReloadBullet;
        SpaceshipControllerScript.OnSpaceShipEndReload += EndReloadBullet;
    }

    void OnDisable() {
        SpaceshipControllerScript.OnSpaceShipShoot -= SubtractBullet;
        SpaceshipControllerScript.OnSpaceShipStartReload -= StartReloadBullet;
        SpaceshipControllerScript.OnSpaceShipEndReload -= EndReloadBullet;
    }
    

    private void SubtractBullet() {
        ammo--;
        ammoUI.text = ammo.ToString() + " / 10";
    }
    private void StartReloadBullet() {
       ammoUI.text = "Reloading...";
    }
    private void EndReloadBullet() {
        ammo = 10;
        ammoUI.text = ammo.ToString() + " / 10";
    }
}
