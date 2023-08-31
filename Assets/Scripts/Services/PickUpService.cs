using System;
using Arkanoid.Game.PickUps;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Services
{
    public class PickUpService : SingletonMonoBehaviour<PickUpService>
    {
        #region Variables

        [Range(0, 100)]
        [SerializeField] private int _pickUpDropChance = 50;
        [SerializeField] private PickUpSpawnData[] _pickUps;

        #endregion

        #region Unity lifecycle

        private void OnValidate()
        {
            if (_pickUps == null)
            {
                return;
            }

            foreach (PickUpSpawnData pickSpawnData in _pickUps)
            {
                pickSpawnData.OnValidate();
            }
        }

        #endregion

        #region Public methods

        public void CreatePickUp(Vector3 position)
        {
            if (_pickUps == null || _pickUps.Length == 0)
            {
                return;
            }

            int chance = Random.Range(0, 101);
            if (_pickUpDropChance >= chance)
            {
                InstantiateRandomPickUp(position);
            }
        }

        #endregion

        #region Private methods

        private void InstantiateRandomPickUp(Vector3 position)
        {
            int weightSum = 0;
            foreach (PickUpSpawnData spawnData in _pickUps)
            {
                weightSum += spawnData.SpawnWeight;
            }

            int randomWeight = Random.Range(0, weightSum + 1);
            int selectedWeight = 0;

            for (int i = 0; i < _pickUps.Length; i++)
            {
                PickUpSpawnData spawnData = _pickUps[i];
                selectedWeight += spawnData.SpawnWeight;

                if (selectedWeight >= randomWeight)
                {
                    Instantiate(spawnData.PickUpPrefab, position, Quaternion.identity);

                    return;
                }
            }
        }

        #endregion

        #region Local data

        [Serializable]
        private class PickUpSpawnData
        {
            #region Variables

            [HideInInspector]
            public string Name;
            public PickUp PickUpPrefab;
            public int SpawnWeight;

            #endregion

            #region Public methods

            public void OnValidate()
            {
                if (PickUpPrefab == null)
                {
                    Name = "Empty";
                }
                else
                {
                    Name = $"{PickUpPrefab.name}:{SpawnWeight}";
                }
            }

            #endregion
        }

        #endregion
    }
}