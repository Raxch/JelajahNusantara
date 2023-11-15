using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public static Action OnGetItem;
    private bool interacted = false;
    public PlayerData playerData;

    private void Start()
    {
        SkillCheckController.OnSkillCheckResults += GetSkillCheckResult;
    }

    private void OnDisable()
    {
        SkillCheckController.OnSkillCheckResults -= GetSkillCheckResult;
    }

    public void Interact()
    {
        interacted = true;
        if (interacted)
        {
            OnGetItem?.Invoke();
        }
    }

    private void GetSkillCheckResult(bool result)
    {
        if (result && interacted)
        {
            playerData.IsHoldingKey = true;
            gameObject.SetActive(false);
        }
    }
}
