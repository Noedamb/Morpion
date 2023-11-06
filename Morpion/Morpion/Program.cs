using System;

namespace Morpion
{
    class Program
    {
        // Créez une matrice pour stocker les coups
        public static int[,] grille = new int[3, 3];

        // Fonction pour afficher le Morpion
        public static void AfficherMorpion()
        {
            for (var row = 0; row < grille.GetLength(0); row++)
            {
                Console.Write("\n|====|====|====|\n"); // Affichage de la ligne de haut 
                Console.Write("|");
                // Deuxième dimension (colonnes)
                for (var col = 0; col < grille.GetLength(1); col++)
                {
                    if (grille[row, col] == 1)
                        Console.Write(" X  "); // Affiche 'X' si le joueur 1 a joué ici
                    else if (grille[row, col] == 2)
                        Console.Write(" O  "); // Affiche 'O' si le joueur 2 a joué ici
                    else
                        Console.Write(" -- "); // Affiche un espace si la case est vide
                    Console.Write("|");
                }
            }
            Console.Write("\n|====|====|====|\n"); // Affichage de la ligne de bas
        }

         /* Fonction permettant de changer dans le tableau qu'elle est le joueur qui à jouer
	        Bien vérifier que le joueur ne sortpas du tableau et que la position n'est pas déjà jouée */
        public static bool AJouer(int j, int k, int joueur)
        {
            if (j < 0 || j >= grille.GetLength(0) || k < 0 || k >= grille.GetLength(1)) // Vérifie si la position est validé
            {
                Console.WriteLine("Position invalide."); // alors la position est invalide
                return false;
            }
            if (grille[j, k] != 10) // Vérifie si la case est déjà occupée
            {
                Console.WriteLine("Position est déjà occupée."); // alors la position est occupée 
                return false;
            }
            grille[j, k] = joueur; // l'un des 2 joueur effectue le coup dans la grille
            return true;
        }

        // Fonction pour vérifier si un joueur a gagné
        public static bool Gagner(int l, int c, int joueur)
        {
            // Vérifie la ligne si le joueur a complété 3 cases horizontalement
            for (int j = 0; j < grille.GetLength(0); j++)
            {
                if (grille[j, c] != joueur)
                    break;
                if (j == grille.GetLength(0) - 1)
                    return true;
            }

            // Vérifie la colonne si le joueur a complété 3 cases verticalement
            for (int k = 0; k < grille.GetLength(1); k++)
            {
                if (grille[l, k] != joueur)
                    break;
                if (k == grille.GetLength(1) - 1)
                    return true;
            }

            // Vérifie les deux diagonales si le joueur a complété 3 cases en diagonale et diagonale à l'opposé 
            if (l == c || l + c == grille.GetLength(0) - 1)
            {
                bool diagonal1 = true;
                bool diagonal2 = true;
                for (int i = 0; i < grille.GetLength(0); i++)
                {
                    if (grille[i, i] != joueur)
                        diagonal1 = false;
                    if (grille[i, grille.GetLength(0) - 1 - i] != joueur)
                        diagonal2 = false;
                }

                if (diagonal1 || diagonal2)
                    return true;
            }

            return false;
        }
  		// Programme principal
        static void Main(string[] args)
        {
        	//--- Déclarations et initialisations --
            int LigneDébut = Console.CursorTop;     // par rapport au sommet de la fenêtre
            int ColonneDébut = Console.CursorLeft; // par rapport au sommet de la fenêtre

           int essais = 0;    // compteur d'essais
	        int joueur = 1 ;   // 1 pour la premier joueur, 2 pour le second
	        int l, c = 0;      // numéro de ligne et de colonne
            int j, k = 0;      // Parcourir le tableau en 2 dimensions
            bool gagner = false; // Permet de vérifier si un joueur à gagné 
            bool bonnePosition = false; // Permet de vérifier si la position souhaité est disponible

            Console.WriteLine("Bienvenue dans la partie Morpion");
            Console.WriteLine("Le joueur 1 joue avec un [X] et le joueur 2 joue avec un [O]");

            //--- initialisation de la grille ---
            // On met chaque valeur du tableau à 10
            for (j = 0; j < grille.GetLength(0); j++)
            {
                for (k = 0; k < grille.GetLength(1); k++)
                {
                    grille[j, k] = 10; // Utilise 10 pour représenter une case vide
                }
            }

            while (!gagner && essais != 9)
            {
                AfficherMorpion();

                try
                {
                    Console.WriteLine("Joueur " + joueur + ", c'est à votre tour.");
                    Console.WriteLine("Ligne   =    ");
                    Console.WriteLine("Colonne =    ");
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 11);
                    l = int.Parse(Console.ReadLine()) - 1;
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 12);
                    c = int.Parse(Console.ReadLine()) - 1;

                    bonnePosition = AJouer(l, c, joueur);
                    if (!bonnePosition)
                    {
                        continue;
                    }

                    essais++;

                    gagner = Gagner(l, c, joueur);

                    if (gagner)
                    {
                        AfficherMorpion();
                        Console.WriteLine("Joueur " + joueur + " a gagné !");
                        break;
                    }
                    else if (essais == 9)
                    {
                        AfficherMorpion();
                        Console.WriteLine("Match nul !");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                if (joueur == 1)
                {
                    joueur = 2;
                }
                else
                {
                    joueur = 1;
                }

                Console.Clear();
            }

            Console.ReadKey();
        }
    }
}
