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
    public class Profile : MonoBehaviour
    {
        [SerializeField]
        private GameObject _login;
        [SerializeField]
        private GameObject _userAccount;



        private Button _profileButton;

        private void Awake()
        {
            _profileButton = GetComponent<Button>();
            _profileButton.onClick.AddListener(TaskOnClick);
        }


        void TaskOnClick()
        {            
            if (AuthenticationService.Instance.AccessToken != null)
            {
                _userAccount.SetActive(true);
            }
            else
            {
                _login.SetActive(true);
            }
        }

       


    }

}

