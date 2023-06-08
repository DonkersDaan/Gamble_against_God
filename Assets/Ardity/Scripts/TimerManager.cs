using System.Collections;
using Unity.Netcode;
using UnityEngine;

//DIT SCRIPT is een eigen test geweest voor het integreren van een server-client systeem. Uiteindelijk is gekozen voor Socket.io.

// In dit script vertelt de server aan de clients dat ze een object aan-/ of uit moeten zetten.
public class TimerManager : NetworkBehaviour // Inherit van NetworkBehaviour om toegang te krijgen tot variabelen zoals "IsServer" en "IsClient".
{
    // Dit is het object dat de clients aan-/ of uit gaan zetten, je voegt het toe in de inspector.
    [SerializeField]
    private GameObject objectToToggle;

    private void Start()
    {
        // Zowel de server als de client komen in deze functie, want het script bestaat op zowel de server als de client.

        // Alleen als we de server zijn (niet de client), dan starten we de Coroutine.
        if (IsServer)
        {
            StartCoroutine(ToggleClientObjectsAfterDelay());
        }
    }

    private IEnumerator ToggleClientObjectsAfterDelay()
    {
        while (true) // Het is normaalgesproken geen goed idee om een while(true) loop te maken, maar dit zorgt er in de demo voor dat het script door blijft gaan.
        {
            yield return new WaitForSeconds(5f);

            ToggleObjectClientRpc(); // De server roept deze functie aan, omdat deze Coroutine alleen op de server is gestart.
        }
    }

    // Door gebruik te maken van [ClientRpc] kan je vanuit de server iets op alle clients uitvoeren.
    // De server stuurt het verzoek door naar alle clients, waarna de clients de code in de functie uitvoeren.
    [ClientRpc]
    public void ToggleObjectClientRpc()
    {
        // Dus als we op deze regel zijn aangekomen, zijn we op de client, die bij zichzelf het object aan-/ of uit zet.
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }

    // Je kunt ook vanuit de client iets naar de server sturen, door gebruik te maken van [ServerRpc]


    // Als het goed is kan je beide kanten op data sturen, door een parameter in de functie mee te geven. (Bijvoorbeeld "string question, string answer")

    // Niet getest of dit werkt, maar dit zou je vanuit de client aan kunnen roepen:
    [ServerRpc(RequireOwnership = false)] // RequireOwnership = false betekent dat elke client het mag aanroepen, ookal is deze niet eigenaar van dit netwerk object (dit script).
    public void SubmitQuestionServerRpc(string question, string answer)
    {
        // Dit zou op de server aan komen, waarna de server kan controleren of het antwoord op de vraag juist is.
    }
    
}