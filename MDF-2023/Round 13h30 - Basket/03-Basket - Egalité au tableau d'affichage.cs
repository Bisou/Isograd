using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Basket - Egalité au tableau d'affichage

Après avoir fini de cultiver votre jardin, vous retournez au terrain de basket et voyez une foule rassemblée autour du panneau de score. Celui-ci affiche un nombre à trois chiffres.

On vous raconte une légende locale qui prétend que le jour où la somme des deux premiers chiffres sera égale au troisième chiffre, une ère de prospérité commencera pour le jardin.

Chaque chiffre est représenté par sept segments, qui peuvent être allumés ou éteints (comme dans l'image). Vous devez effectuer une seule fois l'opération suivante : vous devez éteindre un (et un seul) segment actuellement allumé, ou allumer exactement un segment éteint.

Pouvez-vous donner les nombres affichés par le tableau après cette opération, qui font que le 3e chiffre est égal à la somme des deux premiers, ou dire que c'est impossible ? Si plusieurs solutions sont valides, n'importe laquelle sera acceptée.
Données
Entrée

Ligne 1 : trois nombres compris entre 0 et 9, séparés par une espace.
Sortie

Ligne 1 : "Impossible" si aucune solution n'existe, ou trois nombres compris entre 0 et 9 séparés par une espace, si vous avez trouvé une solution valide. Ces trois nombres doivent pouvoir être obtenus à partir des trois nombres d'entrée à partir d'une seule opération (décrite plus haut), et être tels que le troisième nombre est la somme des deux premiers.
Exemple

Pour l'entrée :

3 4 1

Une réponse est :

3 4 7

Transformation 341 into 347

En effet, on allume un segment dans le 1 pour le changer en 7. La solution est valide, puisque 3+4=7.

Pour l'entrée :

1 9 6

Une réponse est :

1 5 6

Ici, on éteint un segment du 9 pour le changer en 5.

Pour l'entrée :

2 4 6

Une réponse est :

Impossible

Il n'y a aucune manière d'afficher trois nombres correspondants aux contraintes en effectuant une seule opération. Notez bien que même si 2+4=6 est initialement correct, on doit effectuer un changement, et aucun changement ne convient 
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
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var digits = new [] { 
                new []{1,1,1,0,1,1,1}, //0
                new []{0,0,1,0,0,1,0}, //1
                new []{1,0,1,1,1,0,1}, //2
                new []{1,0,1,1,0,1,1}, //3
                new []{0,1,1,1,0,1,0}, //4
                new []{1,1,0,1,0,1,1}, //5
                new []{1,1,0,1,1,1,1}, //6
                new []{1,0,1,0,0,1,0}, //7
                new []{1,1,1,1,1,1,1}, //8
                new []{1,1,1,1,0,1,1}, //9
            };
            var numbers = new int[3][];
            for (var i=0;i<3;++i) {
                numbers[i] = digits[input[i]].ToArray();
            }
            
            for (var numberId=0; numberId<3; ++numberId) { 
                for (var segment=0; segment<7; ++segment) {
                    var newNumbers = numbers.Select(number => number.ToArray()).ToArray();
                    newNumbers[numberId][segment] = 1-newNumbers[numberId][segment]; //invert the segment
                    var newInput = input.ToArray();
                    for (var i=0;i<10;++i) {
                        var ok=true;
                        for (var j=0;j<7;++j) {
                            if (digits[i][j]!=newNumbers[numberId][j]) {
                                ok = false;
                                break;
                            }
                        }
                        if (ok) {
                            newInput[numberId]=i;
                            //now, let's check if the sum is correct
                            if (newInput[0]+newInput[1]==newInput[2]) {
                                Console.WriteLine(string.Join(" ", newInput));
                                return;
                            }
                        }
                    }
                }
            }
            
            Console.WriteLine("Impossible");
        }
    }
}
