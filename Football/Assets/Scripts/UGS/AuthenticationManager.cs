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

namespace FootBall
{
    public class AuthenticationManager : MonoBehaviour
    {

        
        public TMP_InputField NameField;
        public TMP_InputField LastnameField;
        public TMP_InputField UserNameField;
        public TMP_InputField PasswordField;

        public TMP_InputField SignUpUserNameField;
        public TMP_InputField SignUpPasswordField;

        async void Awake()
        {
            try
            {
                await UnityServices.InitializeAsync();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }



        public async void SignUpWithUserName()
        {
            string userName = SignUpUserNameField.text;
            string password = SignUpPasswordField.text;
            string name = NameField.text;
            string lastname = LastnameField.text;           
            if (!string.IsNullOrWhiteSpace(userName) && 
                !string.IsNullOrWhiteSpace(password) && 
                !string.IsNullOrWhiteSpace(name) && 
                !string.IsNullOrWhiteSpace(lastname))
            {
                await SignUpWithUsernamePassword(userName, password);
                var nameData = new Dictionary<string, object> { { "Name",  name} };
                var lastnameData = new Dictionary<string, object> { { "Lastname", lastname } };
                await CloudSaveService.Instance.Data.Player.SaveAsync(nameData);
                await CloudSaveService.Instance.Data.Player.SaveAsync(lastnameData);
            }
            else
            {
                Debug.Log("You have not filled 4 input fields");
            }
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


        private async Task SignUpWithUsernamePassword(string username, string password)
        {
            try
            {
                await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
                Debug.Log("SignUp is successful.");
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

        async Task SignInWithUsernamePasswordAsync(string username, string password)
        {
            try
            {
                await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
                Debug.Log("SignIn is successful.");

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

