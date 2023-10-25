using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Threading.Tasks;
using Unity.RemoteConfig;
using Unity.Services.RemoteConfig;
using System;
using TMPro;
public class RemoteConfig : MonoBehaviour
{
    int bootsPrice = 0;
    int totalGold = 0;
    int totalIron = 0;
    int totalIrium = 0;
    int shieldPrice = 0;
    int swordPrice = 0;

    [SerializeField] TMP_Text goldText;
    public struct UserAttributes
    {

    }

    public struct AppAttributes
    {

    }
    private void Awake()
    {       
        //RemoteConfigService.Instance.FetchConfigs<UserAttributes, AppAttributes>(new UserAttributes(), new AppAttributes());
    }

}
