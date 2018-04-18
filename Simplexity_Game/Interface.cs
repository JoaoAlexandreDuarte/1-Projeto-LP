using System;

namespace Simplexity_Game {
    public class Interface {

        public Interface() {

        }

        public void ShowBoard() {
            for(int i = 0; i < 7; i++) {
                Console.Write(" ");

                for(int j = 0; j < 7; j++) {

                    if (board[i, j] == null) {
                        Console.Write(" | ")
                    } else if(board[i,j].Shape == Shape.Cilinder) {
                        if(board[i, j].Color == Color.White) {
                            Console.Write("W O");
                        } else {
                            Console.Write("R O");
                        }
                    } else if(board[i, j].Shape == Shape.Cube){
                        if (board[i, j].Color == Color.White) {
                            Console.Write("W D");
                        }
                        else {
                            Console.Write("R D");
                        }
                    } else {
                        Console.Write(" u fucked up ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
