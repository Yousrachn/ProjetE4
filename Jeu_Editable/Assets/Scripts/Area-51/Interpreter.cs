using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Interpreter : MonoBehaviour
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

    List<String> response = new List<string>();

    List<String> logs = new List<string> 
    { 
        "-rw-r--r-- 1 root      root   1024  Apr 02 13:28  pancarte_alien.log", 
        "-rw-r--r-- 1 root      root   2048  Apr 02 15:45  chiffrement_cesar.log", 
        "-rw-r--r-- 1 root      root   2048  Apr 02 16:13  stégano_ascenseur.log",
        "-rw-r--r-- 1 root      root   4096  Apr 02 16:37  brute_force.log",
    };
    

    public bool isConnected = false;

    public bool logsDeleted = false;


    public Health player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    
    public List<String> Interpret(string userInput) {

        response.Clear();

        string[] args = userInput.Split();

        


        
        if (SceneController.instance.originScene == "Level_0") {
            if (args[0] == "help") {
                ListEntry("help", "return a list of commands");
                ListEntry("ls", "Get the list of all the files");
                ListEntry("dl", "Download a file");
                return response;
            }

            if (args[0] == "dl") {


                if (args.Length >= 2) {
                    if (args[1] == "pancarte_alien.gif") {
                        string url = "https://github.com/b8remy/projet_E4_jeu_cyber/raw/Second/Fichiers/Pancarte_alien.gif";
                        DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                        DownloadManager.DownloadURLfrom(url);

                        response.Add("Opération réussie");
                        return response;
                    }else {
                        response.Add("Le fichier spécifié n'éxiste pas");
                        return response;

                    }
                } else {
                    response.Add("Veuillez spécifier un fichier");
                    return response;
                }
                
                
            }

            if (args[0] == "ls") {
                response.Add("      pancarte_alien.gif");
                return response;
            }



            else {
                UnknownCommand();

                return response;
            }

        
        }

        if (SceneController.instance.originScene == "Level_1") {

            if (!isConnected) {
                if (args[0] == "help") {
                    ListEntry("help", "return a list of commands");
                    ListEntry("ls", "List the files in the current folder");
                    ListEntry("connect [PC ID]", "Connect to a distant computer");
                    ListEntry("dl [Filename]", "Download a file");



                    return response;
                }

                if (args[0] == "connect") {

                    if (args.Length >= 2) {
                        if (args[1] == "337374") {
                            isConnected = true;
                            response.Add("Successfully connected !");
                            return response;
                        } else {
                            response.Add("Connection failed");
                            return response;
                        }
                    } else {
                        response.Add("Please provide a computer ID");
                            return response;
                    }
                    
                } else if (args[0] == "dl") {
                    if (args.Length >= 2) {
                        if (args[1] == "MesFichiers.zip") {
                            string url = "https://github.com/b8remy/projet_E4_jeu_cyber/raw/Second/Fichiers/challenge_brute_force.zip";
                            DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                            DownloadManager.DownloadURLfrom(url);

                            response.Add("Opération réussie");
                            return response;
                        } else {
                            response.Add("Le fichier spécifié n'éxiste pas");
                            return response;
                        }

                    } else {
                        response.Add("Veuillez spécifier un fichier");
                        return response;
                    }

                } else if (args[0] == "ls") {
                    response.Add("      MesFichiers.zip");
                    return response;
                }
                    
                



                else {
                    UnknownCommand();

                    return response;
                }

            } 
            
            
            else {
                if (args[0] == "help") {
                    ListEntry("help", "return a list of commands");
                    ListEntry("ls", "List the files in the current folder");
                    ListEntry("disconnect", "Disconnect from the distant computer");


                    return response;
                } 

                if (args[0] == "disconnect") {
                    isConnected = false;
                    response.Add("Successfully disconnected");
                    return response;
                } 

                if (args[0] == "ls") {
                    response.Add("      cesar.txt"); 

                    return response;
                }

                if (args[0] == "dl") {
                    if (args.Length >= 2) {
                        if (args[1] == "cesar.txt") {
                            string url = "https://raw.githubusercontent.com/b8remy/projet_E4_jeu_cyber/Second/Fichiers/Cesar.txt";
                            DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                            DownloadManager.DownloadURLfrom(url);

                            response.Add("Opération réussie");
                            return response;
                        } else {
                            response.Add("Le fichier spécifié n'éxiste pas");
                            return response;
                        }

                    } else {
                        response.Add("Veuillez spécifier un fichier");
                        return response;
                    }
                }

                else {
                    UnknownCommand();

                    return response;
                }
                
            }
            

        
        }



         if (SceneController.instance.originScene == "Level_3") {

            
                if (args[0] == "help") {
                    ListEntry("help", "return a list of commands");
                    ListEntry("ls", "List the files in the current folder");
                    ListEntry("ls -al", "List the logs");
                    ListEntry("rm [Logs Name]", "Remove selected logs");
                    ListEntry("dl [Filename]", "Download a file");

                    return response;
                }

                if (args[0] == "dl") {
                    if (args.Length >= 2) {
                    if (args[1] == "QVZT-91R.zip")
                    {
                        string url = "https://github.com/b8remy/projet_E4_jeu_cyber/blob/Second/Fichiers/st%C3%A9ganographie_champ_de_force.zip";
                        DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                        DownloadManager.DownloadURLfrom(url);

                        response.Add("Opération réussie");
                        return response;
                    }
                    else if (args[1] == "Docs-champ-de-force")
                    {
                        string url = "https://github.com/b8remy/projet_E4_jeu_cyber/blob/Second/Fichiers/indice_steganographie_champ_de_force.zip";
                        DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                        DownloadManager.DownloadURLfrom(url);

                        response.Add("Opération réussie");
                        return response;

                    }
                    else
                    {
                        response.Add("Le fichier spécifié n'existe pas");
                        return response;
                    }

                    } else {
                        response.Add("Veuillez spécifier un fichier");
                        return response;
                    }

                } else if (args[0] == "ls") {
                    if (args.Length == 1) {
                        response.Add("      QVZT-91R.zip");
                        response.Add("      Docs-champ-de-force.zip");
                    return response;
                    } else if (args[1] == "-al") {
                        response.Add("Total " + logs.Count);
                        foreach (string log in logs) {
                            response.Add(log);
                        }
                        return response;
                    } else {
                        UnknownCommand();
                        return response;
                    }
                    
                } else if (args[0] == "rm") {
                    if (args.Length > 1) {
                        string logToRemove = args[1];
                        foreach (string log in logs) {
                            string[] logParts = log.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string lastWord = logParts[logParts.Length - 1]; // Récupère le dernier mot de la chaîne
                            if (lastWord == logToRemove) {
                                logs.Remove(log);
                                response.Add("Log \"" + logToRemove + "\" supprimé avec succès.");
                                if (logs.Count == 0) {
                                    // Tous les logs ont été supprimés
                                    logsDeleted = true;
                                }
                                break; // Sort de la boucle une fois que le log a été supprimé
                            }
                        }
                        if (response.Count > 0) {
                            return response;
                        } else {
                            response.Add("Erreur : Log \"" + logToRemove + "\" non trouvé.");
                            return response;
                        }
                        
                    } else {
                        response.Add("Usage : rm [Log Name]");
                        return response;
                    }
                }
                    
                



                else {
                    UnknownCommand();

                    return response;
                }

            
            
            
            
            

        
        }


        else {

            return response;
        }

    }


    public string ColorString(string s, string color) {
        string leftTag = "<color=" + color + ">";
        string rightTag = "</color>";

        return leftTag + s + rightTag;
    }

    void ListEntry(string a, string b) {
        response.Add(ColorString(a, colors["orange"]) + ": " + ColorString(b, colors["yellow"]));
    }

    void UnknownCommand () {
        response.Add("Command not recognized. Type \"help\" for a list of commands.");
    }

    public List<String> LoadTitle(string path, string color, int spacing) {

        List<String> title = new List<string>();


        

        try {
            StreamReader file = new StreamReader(Path.Combine(Application.streamingAssetsPath, path));

            for (int i=0; i<spacing; i++) {
                title.Add("");
            }

            while(!file.EndOfStream) {
                title.Add(ColorString(file.ReadLine(), colors[color]));
            }

            for (int i=0; i<spacing; i++) {
                title.Add("");
            }

            file.Close();
        } catch (Exception e) {
            Debug.LogError("Error loading title: " + e.Message);
        }

        return title;
    }

    public List<String> LoadSubtitle(string color, int spacing) {

        List<String> subtitle = new List<string>();

        for (int i=0; i<spacing; i++) {
            subtitle.Add("");
        }

        subtitle.Add("Accès autorisé. Système d'exploitation en cours d'initialisation.");
        subtitle.Add("Chargement des protocoles sécurisés en cours...");
        

        subtitle.Add("");
        subtitle.Add("---------------------------");
        subtitle.Add("");

        subtitle.Add("Système Opérationnel en Ligne");

        subtitle.Add("");
        subtitle.Add("---------------------------");
        subtitle.Add("");

        subtitle.Add(ColorString("Accès hautement restreint.", "red"));
        subtitle.Add("Toute tentative d'accès non autorisée sera détectée et traitée conformément aux protocoles de sécurité en vigueur.");
        
        subtitle.Add("");
        subtitle.Add("Pour toute assistance technique, contacter l'administration de la base.");


        subtitle.Add("");
        subtitle.Add("Accès autorisé aux utilisateurs du département H34C uniquement.");
        subtitle.Add("Toute diffusion d'informations classifiées est strictement interdite.");

        subtitle.Add("");
        subtitle.Add("Pour obtenir la liste complète des commandes disponibles, utilisez la commande 'help'");

        for (int i=0; i<spacing; i++) {
            subtitle.Add("");
        }

        return subtitle;
                

        // List<String> coloredSubtitle = new List<string>();

        // for (int i=0; i<spacing; i++) {
        //     coloredSubtitle.Add("");
        // }

        // foreach (string subtitleLine in subtitle) {
        //     coloredSubtitle.Add(ColorString(subtitleLine, colors[color]));
        // }

        // for (int i=0; i<spacing; i++) {
        //     coloredSubtitle.Add("");
        // }
     

        // return coloredSubtitle;
    }
}
