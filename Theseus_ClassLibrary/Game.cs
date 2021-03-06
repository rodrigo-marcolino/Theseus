﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Theseus_ClassLibrary
{
    public class Game
    {
        Minotaur minotaur;
        Theseus theseus;
        Tile[,] theMap;
        Filer theFiler;
        int currentMap;

        /**** Import Map from Filer */

        public void SetMap(int aMap)
        {
            currentMap = aMap;
            theFiler = new Filer();
            theFiler.Init();
            theMap = theFiler.GetMap(aMap);
            SetTheseus(theFiler.GetTheseus());
            SetMinotaur(theFiler.GetMinotaur());
        }

        public void Restart()
        {
            theMap = theFiler.GetMap(currentMap);
            SetTheseus(theFiler.GetTheseus());
            SetMinotaur(theFiler.GetMinotaur());
            Run();
        }

        public void NextMap()
        {
            currentMap += 1;
            theMap = theFiler.GetMap(currentMap);
            SetTheseus(theFiler.GetTheseus());
            SetMinotaur(theFiler.GetMinotaur());
            Run();
        }

        public void SetTheseus(Theseus newTheseus)
        {
            theseus = newTheseus;
            theseus.SetGame(this);
        }
        public void SetMinotaur(Minotaur newMinotaur)
        {
            minotaur = newMinotaur;
            minotaur.SetGame(this);
        }

        public void DrawMap()
        {
            string output = "";
            int width = theMap.GetLength(0);
            int height = theMap.GetLength(1);


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    output += ".";
                    if (theMap[x, y].MyWalls.HasFlag(TheWalls.North))
                    {
                        output += "___";
                    }
                    else
                    {
                        output += "   ";
                    }

                }
                output += ".\n";



                for (int x = 0; x < width; x++)
                {
                    if (x != width - 1)
                    {
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))// && !mapOne[x, y].MyWalls.HasFlag(TheWalls.East) 
                        {
                            output += "|   ";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))// && !mapOne[x, y].MyWalls.HasFlag(TheWalls.East) 
                        {
                            output += "    ";
                        }

                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X ";
                        }
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X "; //"| X |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X "; //"  X |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X ";
                        }
                    }

                    if (x == width - 1)
                    {
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "|   ";
                        }
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "|   |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "    |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "    ";
                        }

                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X ";//"| X ";
                        }
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X ";//"| X |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X ";//"  X |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X ";
                        }
                    }


                    if (x == minotaur.Coordinate.X && y == minotaur.Coordinate.Y)
                    {
                        StringBuilder minoPosition = new StringBuilder(output);
                        minoPosition[output.Length - 2] = 'M';
                        output = minoPosition.ToString();
                    }
                    if (x == theseus.Coordinate.X && y == theseus.Coordinate.Y)
                    {
                        StringBuilder thesPosition = new StringBuilder(output);
                        thesPosition[output.Length - 2] = 'T';
                        output = thesPosition.ToString();
                    }

                }
                output += "\n";


            }

            // lowest row of map
            for (int x = 0; x < width; x++)
            {
                output += ".";
                if (theMap[x, height - 1].MyWalls.HasFlag(TheWalls.South))
                {
                    output += "___";
                }
                else
                {
                    output += "   ";
                }
            }
            output += ".\n";


            Console.WriteLine(output);
        }



        /**** Get functions for Thing class */
        public Tile[,] GetMap()
        {
            return theMap;
        }

        public Theseus GetTheseus()
        {
            return theseus;
        }

        /**** Test functions */
        public String TestMap(Tile[,] aMap)
        {
            string output = "";
            foreach (Tile tile in aMap)
            {
                output += tile.Coordinate + " " + tile.MyWalls + "\n";
            }
            output += "minotaur " + minotaur.Coordinate + "\n" + "theseus " + theseus.Coordinate;
            return output;
        }


        /**** Game functions */

        // return the Player's move
        public Point PlayersTurn()
        {
            ConsoleKeyInfo theKey = Console.ReadKey();

            if (theKey.Key == ConsoleKey.UpArrow)
            {
                //Console.WriteLine("Up");
                return Direction.Up;
            }
            if (theKey.Key == ConsoleKey.DownArrow)
            {
                //Console.WriteLine("Down");
                return Direction.Down;
            }
            if (theKey.Key == ConsoleKey.LeftArrow)
            {
                //Console.WriteLine("Left");
                return Direction.Left;
            }
            if (theKey.Key == ConsoleKey.RightArrow)
            {
                //Console.WriteLine("Right");
                return Direction.Right;
            }
            if (theKey.Key == ConsoleKey.A)
            {
                //Console.WriteLine("Stayed still");
                return Direction.Pass;
            }
            return new Point();
        }

        public bool Move()
        {
            Point direction = PlayersTurn();
            if (direction != null)
            {
                return (theseus.Move(direction));

            }
            return false;
        }

        public bool IsGameOver()
        {
            if (theseus.IsFinished() || minotaur.HasEaten())
            {
                return true;
            }
            return false;
        }


        /* The go button */
        public bool Run()
        {
            Console.Clear();
            Console.WriteLine("**** LEVEL " + currentMap.ToString() + " ****\n");
            DrawMap();
            while (IsGameOver() == false)
            {
                Console.WriteLine("\nPress Up, Down, Left, Right to move; Press A to do nothing");
                while (!Move())
                {
                    Console.Clear();
                    Console.WriteLine("**** LEVEL " + currentMap.ToString() + " ****\n");
                    DrawMap();
                    Console.WriteLine("\nPress Up, Down, Left, Right to move; Press A to do nothing");
                    Console.WriteLine("blocked");
                }
                if (!theseus.IsFinished())
                {
                    minotaur.Hunt();

                }
                Console.Clear();
                Console.WriteLine("**** LEVEL " + currentMap.ToString() + " ****\n");
                DrawMap();

            }
            if (IsGameOver() && theseus.IsFinished())
            {
                Console.WriteLine("Congrats!");
                return false;
            }
            if (IsGameOver() && minotaur.HasEaten())
            {
                Console.WriteLine("You were eaten by the Minotaur :(\n");
                Console.WriteLine("Game over\n");
                return false;
            }
            return true;
        }


        /*********************************************************************/

        /**** TEST STUFF ****/

        /*********************************************************************/

        public void SetTestMap(int testMap)
        {
            currentMap = testMap;
            theFiler = new Filer();
            theFiler.InitTestCases();
            theMap = theFiler.GetTestMaps(testMap);
            SetTheseus(theFiler.GetTheseus());
            SetMinotaur(theFiler.GetMinotaur());
        }

        public Point GetTheseusPosition()
        {
            return theseus.Coordinate;
        }
        public Point GetMinotaurPosition()
        {
            return minotaur.Coordinate;
        }
        public Minotaur GetMinotaur()
        {
            return minotaur;
        }
        public Filer GetFiler()
        {
            return theFiler;
        }
        public bool HasExitTile(Tile[,] aMap)
        {
            for (int x = 0; x < aMap.GetLength(0); x++)
            {
                for (int y = 0; y < aMap.GetLength(1); y++)
                {
                    if (aMap[x, y].MyWalls.HasFlag(TheWalls.End))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool NorthWallHasExit(Tile[,] aMap)
        {
            int width, height;
            width = aMap.GetLength(0);
            height = aMap.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                if (aMap[i, 0].MyWalls.HasFlag(TheWalls.End))
                {
                    return true;
                }
            }
            return false;
        }
        public bool SouthWallHasExit(Tile[,] aMap)
        {
            int width, height;
            width = aMap.GetLength(0);
            height = aMap.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                if (aMap[i, (height - 1)].MyWalls.HasFlag(TheWalls.End))
                {
                    return true;
                }
            }
            return false;
        }
        public bool WestWallHasExit(Tile[,] aMap)
        {
            int width, height;
            width = aMap.GetLength(0);
            height = aMap.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                if (aMap[0, i].MyWalls.HasFlag(TheWalls.End))
                {
                    return true;
                }
            }
            return false;
        }
        public bool EastWallHasExit(Tile[,] aMap)
        {
            int width, height;
            width = aMap.GetLength(0);
            height = aMap.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                if (aMap[(width - 1), i].MyWalls.HasFlag(TheWalls.End))
                {
                    return true;
                }
            }
            return false;
        }

        public int[] GetOuterWallArray(Tile[,] aMap)
        {
            int width, height, leftWall = 50, rightWall = 50, topWall = 50, bottomWall = 50;
            width = aMap.GetLength(0);
            height = aMap.GetLength(1);
            int[] theWallArray = new int[4];

            // determine where the exit is

            if (NorthWallHasExit(aMap))
            {
                topWall = 1;
            }
            else
            {
                topWall = 0;
            }

            if (SouthWallHasExit(aMap))
            {
                bottomWall = height - 2;
            }
            else
            {
                bottomWall = height - 1;
            }


            if (WestWallHasExit(aMap))
            {
                leftWall = 1;
            }
            else
            {
                leftWall = 0;
            }

            if (EastWallHasExit(aMap))
            {
                rightWall = width - 2;
            }
            else
            {
                rightWall = width - 1;
            }

            string corners = "";
            corners += "Top: " + topWall.ToString() + "\nBottom: " + bottomWall.ToString() + "\nLeft: " + leftWall.ToString() + "\nRight: " + rightWall.ToString();
            Console.WriteLine(corners);

            theWallArray[0] = topWall;
            theWallArray[1] = rightWall;
            theWallArray[2] = bottomWall;
            theWallArray[3] = leftWall;

            return theWallArray;



        }


        public bool EastWallBroken(Tile[,] aMap)
        {
            int[] theWallArray = GetOuterWallArray(aMap);

            if (!EastWallHasExit(aMap))
            {
                if (!NorthWallHasExit(aMap) && !SouthWallHasExit(aMap))
                {
                    for (int i = 0; i <= theWallArray[2]; i++)
                    {
                        if (!aMap[theWallArray[1], i].MyWalls.HasFlag(TheWalls.East))
                        {
                            return true;
                        }
                    }
                }

                if (NorthWallHasExit(aMap))
                {
                    for (int i = 1; i <= theWallArray[2]; i++)
                    {
                        if (!aMap[theWallArray[1], i].MyWalls.HasFlag(TheWalls.East))
                        {
                            return true;
                        }
                    }
                }
                if (SouthWallHasExit(aMap))
                {
                    for (int i = 0; i <= theWallArray[2] - 1; i++)
                    {
                        if (!aMap[theWallArray[1], i].MyWalls.HasFlag(TheWalls.East))
                        {
                            return true;
                        }
                    }
                }

            }
            if (EastWallHasExit(aMap))
            {
                for (int i = 0; i <= theWallArray[2]; i++)
                {
                    if (!aMap[theWallArray[1], i].MyWalls.HasFlag(TheWalls.East))
                    {
                        if (!aMap[theWallArray[1] + 1, i].MyWalls.HasFlag(TheWalls.End))
                        {
                            return true;

                        }
                    }
                }
            }
            return false;
        }

        public bool SouthWallBroken(Tile[,] aMap)
        {
            int[] theWallArray = GetOuterWallArray(aMap);


            if (!SouthWallHasExit(aMap))
            {
                if (!WestWallHasExit(aMap) && !EastWallHasExit(aMap))
                {
                    for (int i = 0; i <= theWallArray[1]; i++)
                    {
                        if (!aMap[i, theWallArray[2]].MyWalls.HasFlag(TheWalls.South))
                        {
                            return true;
                        }
                    }
                }

                if (WestWallHasExit(aMap))
                {
                    for (int i = 1; i <= theWallArray[1]; i++)
                    {
                        if (!aMap[i, theWallArray[2]].MyWalls.HasFlag(TheWalls.South))
                        {
                            return true;
                        }
                    }
                }

                if (EastWallHasExit(aMap))
                {
                    for (int i = 0; i <= theWallArray[1] - 1; i++)
                    {
                        if (!aMap[i, theWallArray[2]].MyWalls.HasFlag(TheWalls.South))
                        {
                            return true;
                        }
                    }
                }

            }
            if (SouthWallHasExit(aMap))
            {
                for (int i = 0; i <= theWallArray[1]; i++)
                {
                    if (!aMap[i, theWallArray[2]].MyWalls.HasFlag(TheWalls.South))
                    {
                        if (!aMap[i, theWallArray[2] + 1].MyWalls.HasFlag(TheWalls.End))
                        {
                            return true;

                        }
                    }
                }
            }
            return false;
        }

        public bool NorthWallBroken(Tile[,] aMap)
        {
            int[] theWallArray = GetOuterWallArray(aMap);


            if (!NorthWallHasExit(aMap))
            {
                if (!WestWallHasExit(aMap) && !EastWallHasExit(aMap))
                {
                    for (int i = 0; i < theWallArray[1]; i++)
                    {
                        if (!aMap[i, theWallArray[0]].MyWalls.HasFlag(TheWalls.North))
                        {
                            return true;
                        }
                    }
                }
                if (WestWallHasExit(aMap))
                {
                    for (int i = 1; i < theWallArray[1]; i++)
                    {
                        if (!aMap[i, theWallArray[0]].MyWalls.HasFlag(TheWalls.North))
                        {
                            return true;
                        }
                    }
                }
                if (EastWallHasExit(aMap))
                {
                    for (int i = 0; i < theWallArray[1] - 1; i++)
                    {
                        if (!aMap[i, theWallArray[0]].MyWalls.HasFlag(TheWalls.North))
                        {
                            return true;
                        }
                    }
                }
            }
            if (NorthWallHasExit(aMap))
            {
                for (int i = 0; i <= theWallArray[1]; i++)
                {
                    if (!aMap[i, theWallArray[0]].MyWalls.HasFlag(TheWalls.North))
                    {
                        if (!aMap[i, theWallArray[0] - 1].MyWalls.HasFlag(TheWalls.End))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool WestWallBroken(Tile[,] aMap)
        {
            int[] theWallArray = GetOuterWallArray(aMap);

            if (!WestWallHasExit(aMap))
            {
                if (!NorthWallHasExit(aMap) && !SouthWallHasExit(aMap))
                {
                    for (int i = 0; i <= theWallArray[2]; i++)
                    {
                        if (!aMap[theWallArray[3], i].MyWalls.HasFlag(TheWalls.West))
                        {
                            return true;
                        }
                    }
                }
                if (NorthWallHasExit(aMap))
                {
                    for (int i = 1; i <= theWallArray[2]; i++)
                    {
                        if (!aMap[theWallArray[3], i].MyWalls.HasFlag(TheWalls.West))
                        {
                            return true;
                        }
                    }
                }
                if (SouthWallHasExit(aMap))
                {
                    for (int i = 0; i <= theWallArray[2] - 1; i++)
                    {
                        if (!aMap[theWallArray[3], i].MyWalls.HasFlag(TheWalls.West))
                        {
                            return true;
                        }
                    }
                }

            }
            if (WestWallHasExit(aMap))
            {
                for (int i = 0; i <= theWallArray[2]; i++)
                {
                    if (!aMap[theWallArray[3], i].MyWalls.HasFlag(TheWalls.West))
                    {
                        if (!aMap[theWallArray[3] - 1, i].MyWalls.HasFlag(TheWalls.End))
                        {
                            return true;

                        }
                    }
                }
            }
            return false;
        }
        public bool AreCornersBroken(Tile[,] aMap)
        {
            int[] theWallArray = GetOuterWallArray(aMap);
           
            if (!aMap[theWallArray[3], theWallArray[0]].MyWalls.HasFlag(TheWalls.North) || !aMap[theWallArray[3], theWallArray[0]].MyWalls.HasFlag(TheWalls.West))
            {
                return true;
            }
            if (!aMap[theWallArray[3], theWallArray[2]].MyWalls.HasFlag(TheWalls.South) || !aMap[theWallArray[3], theWallArray[2]].MyWalls.HasFlag(TheWalls.West))
            {
                return true;
            }

            if (!aMap[theWallArray[1], theWallArray[0]].MyWalls.HasFlag(TheWalls.North) || !aMap[theWallArray[1], theWallArray[0]].MyWalls.HasFlag(TheWalls.East))
            {
                return true;
            }
            
            if (!aMap[theWallArray[1], theWallArray[2]].MyWalls.HasFlag(TheWalls.South) || !aMap[theWallArray[1], theWallArray[2]].MyWalls.HasFlag(TheWalls.East))
            {
                return true;
            }
            return false;
        }

        public bool AreInnerTilesBroken(Tile[,] aMap)
        {
            int[] theWallArray = GetOuterWallArray(aMap);
            int top, right, left, bottom;
            top = theWallArray[0];
            right = theWallArray[1];
            bottom = theWallArray[2];
            left = theWallArray[3];

            for (int x = left + 1; x < right; x++)
            {
                for (int y = top + 1; y < bottom; y++)
                {
                    if (aMap[x, y].MyWalls.HasFlag(TheWalls.North) && !aMap[x, y - 1].MyWalls.HasFlag(TheWalls.South))
                    {
                        //Console.WriteLine("Broken tile (north south)");
                        return true;
                    }
                    if (aMap[x, y].MyWalls.HasFlag(TheWalls.South) && !aMap[x, y + 1].MyWalls.HasFlag(TheWalls.North))
                    {
                        //Console.WriteLine("Broken tile (south north)");
                        return true;
                    }
                    if (aMap[x, y].MyWalls.HasFlag(TheWalls.East) && !aMap[x + 1, y].MyWalls.HasFlag(TheWalls.West))
                    {
                        //Console.WriteLine("Broken tile (east west)");
                        return true;
                    }
                    if (aMap[x, y].MyWalls.HasFlag(TheWalls.West) && !aMap[x - 1, y].MyWalls.HasFlag(TheWalls.East))
                    {
                       //Console.WriteLine("broken tile (west east)");
                        return true;
                    }

                }
                
            }
            return false;

        }
    }

}

