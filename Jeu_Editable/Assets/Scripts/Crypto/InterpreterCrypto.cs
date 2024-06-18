using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class InterpreterCrypto : MonoBehaviour
{

      Dictionary<string, string> colors = new Dictionary<string, string>()
    {
        { "black", "#021b21" },
        { "gray", "#555d71" },
        { "red", "#ff5879" },
        { "yellow", "#f2f1b9" },
        { "blue", "#9ed9d8" },
        { "purple", "#d926ff" },
        { "orange", "#ef5847" }
    };

    List<string> response = new List<string>();
    public List<string> Interpret(string userInput)
    {
        response.Clear();
        string[] args = userInput.Split();

        if (args.Length == 0)
        {
            response.Add("Commande non reconnue. Entrer help pour avoir la liste des commandes.");
            return response;
        }

        if( args[0] == "help")
        {
            ListEntry("help","pour avoir la liste des commandes disponile");
            ListEntry("ls","afficher l'historique des mail'");
            ListEntry("dl + [filename]","télécharger le mail ");

        }

        if ( args[0] == "ls")
        {
            response.Add("Historique des mails: 24_05_2024, 25_05_2024, 30_04_2024, 02_06_2024");
            return response;
        }

        
        if (args[0] == "dl") {
            if (args.Length >= 2) {
                if (args[1] == "24_05_2024")
                {
                    string url = "https://github.com/b8remy/projet_E4_jeu_cyber/blob/Second/Fichiers/st%C3%A9ganographie_champ_de_force.zip";
                    DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                    DownloadManager.DownloadURLfrom(url);

                    response.Add("Opération réussie");
                    return response;    
                }
                else if (args[1] == "25_05_2024")
                {
                    string url = "https://github.com/b8remy/projet_E4_jeu_cyber/blob/Second/Fichiers/indice_steganographie_champ_de_force.zip";
                    DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                    DownloadManager.DownloadURLfrom(url);

                    response.Add("Opération réussie");
                    return response;
                }

                else if (args[1] == "30_04_2024")
                {
                    string url = "https://github.com/b8remy/projet_E4_jeu_cyber/blob/Second/Fichiers/indice_steganographie_champ_de_force.zip";
                    DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                    DownloadManager.DownloadURLfrom(url);

                    response.Add("Opération réussie");
                    return response;
                }

                else if (args[1] == "02_06_2024")
                {
                    string url = "https://github.com/b8remy/projet_E4_jeu_cyber/blob/Second/Fichiers/indice_steganographie_champ_de_force.zip";
                    DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                    DownloadManager.DownloadURLfrom(url);

                    response.Add("Opération réussie");
                    return response;
                }
                else
                {
                    response.Add("Fichier inexistant.");
                    return response;

                }
            }
            else
            {
                response.Add("Commande incomplète.");
                return response;
            }
        
    
        }
        else {
            
                response.Add("Commande non reconnue. Entrer help pour avoir la liste des commandes.");
                return response;
            }

    }

    public string ColorString(string s,string color)
    {
        string leftTag = "<color=" + color + ">";
        string rightTag = "</color>";
        return leftTag + s + rightTag;

    }

    void ListEntry(string a, string b)
    {
        response.Add(ColorString(a, colors["orange"]) + ":" + ColorString(b, colors["yellow"]));

    }

    void LoadTitle(string path, string color, int spacing)
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, path);
        if (File.Exists(fullPath))
        {
            StreamReader file = new StreamReader(fullPath);


            for(int i = 0; i<spacing; i++)
            {
                response.Add("");

            }
            while(!file.EndOfStream)
            {
                response.Add(ColorString(file.ReadLine(), colors[color]));

            }
            for(int i = 0; i<spacing; i++)
            {
                response.Add("");
            }
            file.Close();
        }
        else
        {
            Debug.LogError("File not found: " + fullPath); // Debug
            response.Add("File not found: " + path);
        }
    }
}

