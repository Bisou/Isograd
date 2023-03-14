using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Poubelles - Le dédale du local

Quelle longue journée. Maintenant que vous avez fini de jeter ces bouteilles, il est temps de rentrer chez soi profiter d'une nuit bien méritée.

Malheureusement, vous vous rendez compte rapidement que vous vous êtes perdus dans votre local poubelle. Et pour cause, c'est un véritable labyrinthe : chaque pièce vous emmène vers exactement une autre pièce, les couloirs étant à sens unique.

Vous commencez dans la pièce numéro 1, vous connaissez la carte du labyrinthe, et vous savez que vous vous endormirez après avoir emprunté exactement K couloirs : dans quelle pièce dormirez-vous ?
Données
Entrée

Ligne 1 : deux entiers N (1 ≤ N ≤ 10^4) et K (1 ≤ K ≤ 10^12) séparés par une espace, et représentant respectivement le nombre de pièces dans le labyrinthe et le nombre de couloirs que vous emprunterez avant de vous endormir.

Ligne 2 : N entiers séparés par des espaces. Le ième représente la pièce accessible depuis la pièce numéro i. Les pièces sont numérotées de 1 à N.
Sortie

La pièce dans laquelle vous allez vous endormir.

Attention : K étant très grand, il vous faudra trouver une solution assez efficace. Si votre programme est trop long à trouver la solution une erreur s'affichera et votre solution sera considérée comme fausse.
Exemple

Pour l'entrée :

3 4
2 3 1

La sortie attendue est :

2

En effet, vous commencez dans la pièce 1, puis allez dans la 2, puis la 3, puis la 1 et finissez dans la pièce numéro 2 (après avoir changé 4 fois de pièce) dans laquelle vous vous endormez. 
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
            var data = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var n = data[0];
            var k = data[1];
            var lastSeen = new Dictionary<int,int>();
            var room=1;
            var step=0;
            lastSeen.Add(room,step);
            var nextRooms = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            while(true) {
                room = nextRooms[room-1];
                step++;
                k--;
                if (k==0) {
                    Console.WriteLine(room);
                    return;
                }
                if (lastSeen.ContainsKey(room)) {
                    var cycle = step - lastSeen[room];
                    k = k % cycle; //remove all cycles
                    break;
                }
                lastSeen.Add(room, step);
            }
           
            while(k>0) {
                room = nextRooms[room-1];
                k--;
            }
            Console.WriteLine(room);
        }
    }
}
