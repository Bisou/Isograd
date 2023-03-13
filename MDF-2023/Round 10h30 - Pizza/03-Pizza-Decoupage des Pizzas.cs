using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Pizza - Découpage des pizzas

Votre robot découpeur de pizzas a perdu la tête ! Pour vérifier que les pizzas sont correctement coupées, vous souhaitez compter le nombre de parts après la découpe.

Pouvez-vous écrire un algorithme qui calcule le nombre de parts à partir d'une image en noir et blanc de la pizza ?

Une part de pizza est une zone maximale de cases telles qu'on puisse aller de chaque case vers chaque autre case en se déplacant d'une case à une autre verticalement ou horizontalement en passant uniquement par des cases noires.
Données
Entrée

Ligne 1 : un entier N compris entre 1 et 100, la dimension de l'image.

N lignes suivantes : Une chaîne de caractères de taille N. Un caractère # représente un pixel de pizza et un . correspond à un espace vide.
Sortie

Un entier représentant le nombre de parts sur la pizza. Une part de pizza est considérée comme une zone de pixels de pizza contigus horizontalement ou verticalement.
Exemple

Pour l'entrée :

14
.....##.#.....
...####.###...
...####.####..
.##.###.###.#.
.###.##.##.###
#####.#.#.####
######...#####
..............
######...#####
.####.#.#.####
.###.##.##.##.
..#.###.###...
...####.###...
....###.##....

Le nombre de parts est :

8


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
            var n = int.Parse(Console.ReadLine());
            var image = new StringBuilder[n];
            for (var i=0; i<n; ++i) {
                image[i] = new StringBuilder(Console.ReadLine());
            }
            var pizzaSlices = 0;
            var shiftRow = new [] {0, 1, 0, -1};
            var shiftCol = new [] {1, 0, -1, 0};
            for (var row=0; row<n; ++row) {
                for (var col=0; col<n; ++col) {
                    if (image[row][col] == '.') continue;
                    pizzaSlices++;
                    
                    //now, let's remove this slice from the image
                    var todo = new Queue<(int Row, int Col)>() ;
                    todo.Enqueue((row, col));
                    image[row][col] = '.';
                    while (todo.Any()) {
                        var current = todo.Dequeue();
                        for (var way=0; way<4; ++way) {
                            var newRow = current.Row + shiftRow[way];
                            var newCol = current.Col + shiftCol[way];
                            if (newRow<0 || newRow>=n || newCol<0 || newCol>=n) continue;
                            if (image[newRow][newCol]=='#') {
                                image[newRow][newCol]='.';
                                todo.Enqueue((newRow,newCol));
                            }
                        }
                    }
                }
            }
            
            Console.WriteLine(pizzaSlices);
        }
    }
}
