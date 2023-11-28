using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;

namespace FootBall
{
    public class TestCloudManager : MonoBehaviour
    {


        // Start is called before the first frame update
        async void Start()
        {
            // Initialize Unity Services to use Cloud Save methods
            await UnityServices.InitializeAsync();


            #region Saving and Loading integer values
            // Save integer value
            await CloudManager.SaveSpecificData("PlayerScore", 5);
            // Load integer value
            int playerScore = await CloudManager.LoadSpecificData<int>("PlayerScore");
            #endregion


            #region Saving and Loading string values
            // Save integer value
            await CloudManager.SaveSpecificData("PlayerName", "Jorj");

            // Load integer value
            string playerName = await CloudManager.LoadSpecificData<string>("PlayerName");
            #endregion


        }


    }

}


