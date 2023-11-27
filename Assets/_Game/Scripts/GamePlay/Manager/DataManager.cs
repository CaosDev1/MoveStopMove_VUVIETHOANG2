using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public WeaponDataSO weaponDataSO;

    public WeaponData GetWeaponData(WeaponType weaponType)
    {
        List<WeaponData> weaponDatas = weaponDataSO.listWeaponData;
        for (int i = 0; i < weaponDatas.Count; i++)
        {
            if(weaponType == weaponDatas[i].weaponType)
            {
                return weaponDatas[i];
            }
        }
        return null;
    }
}
