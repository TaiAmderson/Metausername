using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MetaUsername : MonoBehaviourPunCallbacks
{
    [Header("Manual Username Options")]
    public List<GameObject> nameTextObjects;
    public bool useManualNames;

    [Header("Manual Player Prefab")]
    public GameObject playerPrefab;

    private void Start()
    {
        if (PhotonNetwork.LocalPlayer != null && playerPrefab != null)
        {
            if (useManualNames)
            {
                SetPhotonUsernameFromTextObjects();
            }
            else
            {
                SetPhotonUsernameAutomatically();
            }

            PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity, 0);
        }
    }

    private void SetPhotonUsernameFromTextObjects()
    {
        if (nameTextObjects.Count > 0)
        {
            foreach (var textObject in nameTextObjects)
            {
                Text textComponent = textObject.GetComponent<Text>();
                if (textComponent != null)
                {
                    PhotonNetwork.LocalPlayer.NickName = textComponent.text;
                    break;
                }
            }
        }
    }

    private void SetPhotonUsernameAutomatically()
    {
        PhotonNetwork.LocalPlayer.NickName = "Player" + Random.Range(1, 1000);
    }
}
