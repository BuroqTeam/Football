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
    public class NewAccount : MonoBehaviour
    {
        public TMP_InputField NameField;
        public TMP_InputField LastnameField;       
        public TMP_InputField SignUpUserNameField;
        public TMP_InputField SignUpPasswordField;

        public GameObject Menu;
        public GameObject CreateAccount;

        private Button _signUpButton;


        private async void Awake()
        {
            _signUpButton = GetComponent<Button>();
            _signUpButton.onClick.AddListener(TaskOnClick);

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
            SignUpWithUserName();
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
             
            }
            else
            {
                Debug.Log("You have not filled 4 input fields");
            }
        }

        private async Task SignUpWithUsernamePassword(string username, string password)
        {
            try
            {
                await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
                Debug.Log("SignUp is successful.");

                string name = NameField.text;
                string lastname = LastnameField.text;
                var nameData = new Dictionary<string, object> { { "Name", name } };
                var lastnameData = new Dictionary<string, object> { { "Lastname", lastname } };
                await CloudSaveService.Instance.Data.Player.SaveAsync(nameData);
                await CloudSaveService.Instance.Data.Player.SaveAsync(lastnameData);

                Menu.SetActive(true);
                CreateAccount.SetActive(false);

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

