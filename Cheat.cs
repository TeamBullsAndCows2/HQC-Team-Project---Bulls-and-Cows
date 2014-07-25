﻿namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Interfaces;
    using BullsAndCows.Tools;
    
    public class Cheat
    {
        private IRandomGenerator randomGenerator;
        private char[] cheatNumber;
        private int[] number;

        public Cheat(int[] initialNumber)
        {
            this.Cheats = 0;
            this.randomGenerator = RandomGenerator.Instance;
            this.cheatNumber = new char[4] { 'X', 'X', 'X', 'X' };
            this.number = initialNumber;
        }

        public int Cheats
        {
            get;
            private set;
        }

        public string GetCheat()
        {
            if (this.Cheats < 4)
            {
                while (true)
                {
                    int randPossition = this.randomGenerator.GetValue(0, 3);
                    if (this.cheatNumber[randPossition] == 'X')
                    {
                        switch (randPossition)
                        {
                            case 0:
                                this.cheatNumber[randPossition] = (char)(this.number[0] + '0');
                                break;
                            case 1:
                                this.cheatNumber[randPossition] = (char)(this.number[1] + '0');
                                break;
                            case 2:
                                this.cheatNumber[randPossition] = (char)(this.number[2] + '0');
                                break;
                            case 3:
                                this.cheatNumber[randPossition] = (char)(this.number[3] + '0');
                                break;
                        }

                        break;
                    }
                }

                this.Cheats++;
            }

            return new string(this.cheatNumber);
        }
    }
}
