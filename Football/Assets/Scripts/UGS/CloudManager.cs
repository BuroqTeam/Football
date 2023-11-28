using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.CloudSave;


namespace FootBall
{
    public static class CloudManager
    {


        public static async Task<T> LoadSpecificData<T>(string key)
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


        public static async Task SaveSpecificData<T>(string key, T value)
        {
            try
            {
                Dictionary<string, object> oneElement = new Dictionary<string, object>();

                oneElement.Add(key, value);

                // Saving the data without write lock validation by passing the data as an object instead of a SaveItem
                Dictionary<string, string> result = await CloudSaveService.Instance.Data.Player.SaveAsync(oneElement);

                Debug.Log($"Successfully saved {key}:{value} with updated write lock {result[key]}");
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
        }

    }

}

