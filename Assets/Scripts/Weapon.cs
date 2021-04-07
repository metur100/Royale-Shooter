using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Gun[] loadout;
    public Transform weaponParent;

    private GameObject currentWeapon;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Equip(0);
        if (Input.GetMouseButton(1)) Aim();
    }

    private void Aim()
    {
        throw new NotImplementedException();
    }

    void Equip(int p_ind)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        GameObject t_newWeapon = Instantiate(loadout[p_ind].prefab, weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;
        t_newWeapon.transform.localPosition = Vector3.zero;
        t_newWeapon.transform.localEulerAngles = Vector3.zero;

        currentWeapon = t_newWeapon;
    }
}
