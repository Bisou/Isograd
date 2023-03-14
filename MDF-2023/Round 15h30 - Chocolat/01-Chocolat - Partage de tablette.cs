using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Chocolat - Partage de tablette

Vous avez fait l'acquisition d'une magnifique tablette de chocolat, qui peut être représentée comme une grille de X carrés de long et Y carrés de large.

Dans un élan de générosité, vous décidez de partager la tablette avec vos amis. Mais est-il seulement possible de la partager en N parts égales sans devoir briser de carré de chocolat ?
Données
Entrée

Ligne 1 : trois entiers X, Y et N : la longueur de la tablette, la largeur de la tablette, et le nombre de parts. Leurs valeurs sont comprises entre 1 et 100.
Sortie

YES s'il est possible de partager la tablette en N parts égales sans briser de carré, NO si ce n'est pas possible.
Exemples

Pour l'entrée :

50 20 10

La sortie attendue est :

YES

car la tablette possède 50 * 20 = 1000 carrés au total, ce qui permet une répartition équitable de 100 carrés pour chacune des 10 personnes.

Pour l'entrée :

2 2 3

La sortie attendue est :

NO

car la tablette possède 2 * 2 = 4 carrés au total, ce qui ne permet pas de répartition équitable entre 3 personnes. 
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
            var data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var squares = data[0] * data[1];
            var portions = data[2];
            if (squares % portions == 0)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
