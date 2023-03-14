using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Basket - Cultivons notre jardin

Dans le complexe sportif dans lequel vous êtes arrivés il y a peu, il y a non pas un, mais de nombreux terrains de basket. Pour instaurer une ambiance plus champêtre, il a été décidé de convertir certains de ces terrains de basket en jardin.

Suite à votre succès en tant que coach, on vous demande d'effectuer une proposition pour l'emplacement de ce jardin.

Les terrains de basket actuellement installés forment une grille de n lignes et m colonnes, et on vous montre une carte qui les représente. Les cases marquées d'un . sont disponibles pour être mises sous forme de jardin, mais les cases marquées d'un X sont les terrains de basket où le président du club a déjà marqué un panier, donc qu'il se refuse à sacrifier.

Le jardin prévu doit occuper un carré de 2 cases de large et 2 cases de haut. Saurez vous trouver suffisamment de place sur la carte ? Si oui, renvoyez le plan avec les cases du jardin signalées par des O . Sinon, renvoyez simplement le mot "Impossible".
Données
Entrée

Ligne 1 : deux entiers n et m (chacun étant plus petit que 30) représentant le nombre de lignes et de colonnes du terrain.

n lignes suivantes : Une série de m caractères, des . sur les cases où on peut placer un morceau de jardin, et des X sur les cases qu'on ne doit pas toucher.
Sortie

S'il est possible de trouver un carré de 2x2 cases contiguës où l'on peut placer le jardin, renvoyez la même carte avec des O aux emplacements prévus pour le jardin. Si plusieurs solutions valides existent, vous pouvez écrire n'importe laquelle de ces solutions.

Sinon, renvoyez la chaîne de caractère "Impossible".
Exemple

Pour l'entrée :

4 5
XXX.X
XX..X
XX..X
XXXXX

Une réponse est :

4 5
XXX.X
XXOOX
XXOOX
XXXXX

Pour l'entrée :

3 2
XX
X.
X.

La réponse est :

Impossible

Pour l'entrée :

4 4
XXX.
XX..
X...
X..X

Une réponse est :

4 4
XXX.
XX..
XOO.
XOOX

Une autre réponse acceptée est :

4 4
XXX.
XXOO
X.OO
X..X


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
            var height = int.Parse(data[0]);
            var width = int.Parse(data[1]);
            var map = new StringBuilder[height];
            for (var i=0;i<height;++i)
                map[i] = new StringBuilder(Console.ReadLine());

            for (var row=0; row<height-1; ++row) {
                for (var col=0; col<width-1; ++col) {
                    if (map[row][col]=='.' && map[row+1][col]=='.' && map[row][col+1]=='.' && map[row+1][col+1]=='.') {
                        map[row][col]='O';
                        map[row+1][col]='O';
                        map[row][col+1]='O';
                        map[row+1][col+1]='O';
                        //No need to output the dimensions. This is an error in the exemple
                        //Console.WriteLine($"{height} {width}");
                        Console.WriteLine(string.Join("\n", map.Select(sb => sb.ToString())));
                        return;
                    }
                }
            }

            Console.WriteLine("Impossible");
        }
    }
}
