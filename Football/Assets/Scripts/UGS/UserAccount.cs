using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using Unity.Services.CloudSave;
using UnityEngine.UI;
using TMPro;
using Unity.Services.Authentication.PlayerAccounts;

namespace FootBall
{
    public class UserAccount : MonoBehaviour
    {

        [SerializeField]
        private TMP_Text NameText;
        [SerializeField]
        private TMP_Text LastnameText;

       


        private async void OnEnable()
        {
            await UnityServices.InitializeAsync();

            if (AuthenticationService.Instance.AccessToken != null)
            {
                LoadUserInfo();
            }
            
        }

      

        private async void LoadUserInfo()
        {
            NameText.text = await RetrieveSpecificData<string>("Name");
            LastnameText.text = await RetrieveSpecificData<string>("Lastname");            
        }


        private async Task<T> RetrieveSpecificData<T>(string key)
        {
            try
            {
                var results = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { key });

                if (results.TryGetValue(key, out var item))
                {
                    return item.Value.GetAs<T>();
                }
                else
                {
                    Debug.Log($"There is no such key as {key}!");
                }
            }
            catch (CloudSaveValidationException e)
            {
                Debug.LogError(e);
            }
            catch (CloudSaveRateLimitedException e)
            {
                Debug.LogError(e);
            }
            catch (CloudSaveException e)
            {
                Debug.LogError(e);
            }
            return default;
        }



        public void LogOut()
        {                        
            AuthenticationService.Instance.SignOut();
        }


    }
}

