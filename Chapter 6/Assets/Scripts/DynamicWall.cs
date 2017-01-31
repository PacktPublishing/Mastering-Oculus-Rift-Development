using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DynamicWall : MonoBehaviour 
{
	[SerializeField] private GameObject wallSection;
    public bool isRaised = true;
    private int totalCost = 5;
    public int remainingCost = 5;
    [SerializeField] private Text costText;
    [SerializeField] private GameObject counterObject;
    [SerializeField] private Image healthBar;
    private int totalHealth = 10;
    private int remainingHealth = 10;

    public IEnumerator MoveSectionUp()
    {
        counterObject.SetActive(false);
        while (wallSection.transform.localPosition.y < 4.5f)
        {
            wallSection.transform.Translate(Vector3.up * 0.5f);
            yield return null;
        }

        isRaised = true;
    }

    public void DepositOrbs(int numOrbs, Team playerTeam)
    {
        remainingCost -= numOrbs;
        if (remainingCost <= 0)
        {
            remainingHealth = totalHealth;
            healthBar.fillAmount = 1;
            SetSectionTeamColor(playerTeam);
            StartCoroutine(MoveSectionUp());
        }
        UpdateText();
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Projectile")
        {
            remainingHealth--;
            if (remainingHealth <= 0)
            {
                healthBar.fillAmount = 0;
                counterObject.SetActive(true);
                remainingCost = totalCost;
                UpdateText();
                StartCoroutine(MoveSectionDown());
            }
            else
            {
                healthBar.fillAmount = (float)remainingHealth/totalHealth;
            }
        }
    }

    private void SetSectionTeamColor(Team playerTeam)
    {
        switch (playerTeam)
        {
            case Team.Red:
                wallSection.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.5f);
                break;
            case Team.Blue:
                wallSection.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0.5f);
                break;
            case Team.Yellow:
                wallSection.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0.5f);
                break;
            case Team.Green:
                wallSection.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.5f);
                break;
        }
    }

    private void UpdateText()
    {
        costText.text = remainingCost.ToString();
    }

    public IEnumerator MoveSectionDown()
    {
        while (wallSection.transform.localPosition.y > -5f)
        {
            wallSection.transform.Translate(Vector3.down*0.5f);
            yield return null;
        }

        isRaised = false;
    }
}
