using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Pizza - Livraison optimale

Sacré chemin parcouru depuis l'ouverture de votre première pizzeria ! Vos recettes ont eu tellement de succès que la ville se les arrachait et vous avez rapidement dû ouvrir d'autres établissements pour servir une demande en perpétuelle croissance.

Afin d'optimiser les livraisons et réduire les kilomètres parcourus par vos livreurs, vous souhaitez mettre en place une allocation intelligente des commandes. Vous devez donc assigner chaque commande à la pizzeria la plus proche.

Quelle sera la distance totale parcourue par vos livreurs pour livrer toutes les pizzas ?

On considère que les rues de la ville forment un quadrillage aux coordonnées entières, la distance entre deux points sera donc calculée avec la distance de Manhattan. Toutes les commandes sont livrées individuellement, et chaque livreur retourne à sa pizzeria d'origine après chaque livraison.

On rappelle que la distance de Manhattan entre (x, y) et (x', y') est |x - x'| + |y - y'|
Données
Entrée

Ligne 1 : deux entiers N et M, respectivement le nombre de pizzerias et le nombre de commandes à traiter.

N lignes suivantes : deux entiers x et y correspondant aux coordonnées d'une pizzeria sur la grille.

M lignes suivantes : deux entiers x et y correspondant aux coordonnées d'une commande sur la grille.

Il y aura au maximum 100 pizzerias et 100 commandes. Les coordonnées sont comprises entre 0 et 1 000 000.
Sortie

La distance totale parcourue par vos livreurs pour livrer les commandes.
Exemple

Pour l'entrée :

3 4
12 15
28 14
55 49
16 18
50 22
29 11
5 44

Le trajet total parcouru est :

154

La première commande en (16, 18) sera affectée à la pizzeria (12, 15) qui se situe à une distance de 7. Le livreur parcourt donc 14 unités de distance aller-retour pour la livraison.

La seconde comande est affectée à la pizzeria (28,14) pour une distance totale de 60.

La troisième comande est affectée à la pizzeria (28,14) pour une distance totale de 8.

La dernière comande est affectée à la pizzeria (12, 15) pour une distance totale de 72.

La distance totale parcourue sera donc de 14 + 60 + 8 + 72 = 154. 

 * Read input from Console
 * Use: Console.WriteLine to output your result to STDOUT.
 * Use: Console.Error.WriteLine to output debugging information to STDERR;
 *       
 * ***/

namespace CSharpContestProject
{
    class Program
    {
        static void Main(string[] args)
        {   
            var data = Console.ReadLine().Split(' ');
            var n = int.Parse(data[0]);
            var m = int.Parse(data[1]);
            var pizzerias = new List<(int X, int Y)>();
            while(n-->0) {
                data = Console.ReadLine().Split(' ');
                pizzerias.Add((int.Parse(data[0]), int.Parse(data[1])));
            }
            var totalDistance = 0;
            while (m-->0) {
                data = Console.ReadLine().Split(' ');
                var distance = pizzerias.Min(pizzeria => Math.Abs(int.Parse(data[0]) - pizzeria.X) + Math.Abs(int.Parse(data[1]) - pizzeria.Y));
                totalDistance += 2 * distance;
            }

            Console.WriteLine(totalDistance);
        }
    }
}
