using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum WeaponType
{
    Hammer = 0,
    Arrow = 1,
    Axe_0 = 2,
    Axe_1 = 3,
    Boomerang = 4,
    Candy_0 = 5,
    Candy_1 = 6,
    Candy_2 = 7,
    Candy_4 = 8,
    Knife = 9,
    Uzi = 10,
    Z = 11,
}

[Serializable]
public class WeaponData
{
    public WeaponType weaponType;
    public Weapon weapon;
    public Bullet bullet;
}
