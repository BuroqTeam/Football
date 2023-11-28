using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using Unity.Services.CloudSave;
using UnityEngine.UI;
using TMPro;
using System;

namespace FootBall
{
    public class Login : MonoBehaviour
    {
        public GameObject LoginObject;
        public GameObject MenuObject;

        public TMP_InputField UserNameField;
        public TMP_InputField PasswordField;

        private Button _profileButton;

        private async void Awake()
        {
            _profileButton = GetComponent<Button>();
            _profileButton.onClick.AddListener(TaskOnClick);

            try
            {
                await UnityServices.InitializeAsync();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

      


        void TaskOnClick()
        {
            SignIn();
        }

        public async void SignIn()
        {
            string userName = UserNameField.text;
            string password = PasswordField.text;
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                await SignInWithUsernamePasswordAsync(userName, password);
              
            }
            else
            {
                Debug.Log("You have not filled out");
            }
        }



        async Task SignInWithUsernamePasswordAsync(string username, string password)
        {
            try
            {
                await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
                Debug.Log("SignIn is successful.");
                LoginObject.SetActive(false);
                MenuObject.SetActive(true);
                UserNameField.text = "";
                PasswordField.text = "";

            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
        }

    }

}

