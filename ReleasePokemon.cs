using System;
namespace ReleasePokemon
{
    class ReleasePokemon
    {
        static void Main()
        {
            const string MsgChoose = "Someone's PC:";
            const string MsgShowList = "1 - Box:";
            const string MsgExit = "0 - Exit";
            const string MsgPokemon = "\nPokémon in the Box: ";
            const string MsgPokemonSlot = "{0} - {1}";
            const string MsgWhoToRelease = "Select the index of the pokémon you want to release or 0 to cancel: ";
            const string MsgReleased = "You released {0}";
            const string MsgCancelled = "Operation cancelled";
            const string MsgEmpty = "There is an empty space, pokémon already released.";
            const string EmptySlot = "Empty";

            const int MinMenuOption = 0,MaxMenuOption = 1;
            const int CancelOption = 0;

            // Exceptions
            const string MsgFormatException = "\n == ERROR ==\nMust enter a natural number";
            const string MsgOverflow = "\n == ERROR ==\nNumber to big";
            const string MsgNull = "\n == ERROR ==\nEmpty input, please select between {0} and {1}";
            const string MsgOutOfRange = "\n == ERROR ==\nThe option must be between {0} and {1}";

            string[] pokemon = new string[15] { "Pikachu", "Charmander", "Squirtle", "Bulbasaur", "Eevee", "Jigglypuff", "Meowth", "Psyduck", "Snorlax", "Gengar", "Machop", "Magikarp", "Vulpix", "Onix", "Abra"};

            int menuOption = -1, releaseOption = -1, i;
            bool exitMenu = false, canRelease;

            do
            {
                menuOption = -1;

                Console.WriteLine(MsgChoose);
                Console.WriteLine(MsgShowList);
                Console.WriteLine(MsgExit);

                try
                {
                    menuOption = int.Parse(Console.ReadLine());

                    if (menuOption < MinMenuOption || menuOption > MaxMenuOption)
                    {
                        throw new ArgumentOutOfRangeException(nameof(menuOption));
                    }

                    switch (menuOption)
                    {
                        case 0: // Exit
                            exitMenu = true;
                        break;

                        case 1: // List the pokémon
                            Console.WriteLine(MsgPokemon);

                            for (i = 0; i < pokemon.Length; i++)
                            {
                                Console.WriteLine(MsgPokemonSlot, i + 1, pokemon[i]);
                            }

                            canRelease = false;

                            do
                            {
                                Console.WriteLine(MsgWhoToRelease);

                                try
                                {
                                    releaseOption = int.Parse(Console.ReadLine());

                                    if (releaseOption < CancelOption || releaseOption > pokemon.Length)
                                    {
                                        throw new ArgumentOutOfRangeException(nameof(releaseOption));
                                    }

                                    canRelease = true;

                                    if (releaseOption == CancelOption)
                                    {
                                        Console.WriteLine(MsgCancelled);
                                    }
                                    else if(pokemon[releaseOption - 1] == EmptySlot)
                                    {
                                        Console.WriteLine(MsgEmpty);
                                    }
                                    else
                                    {
                                        Console.WriteLine(MsgReleased, pokemon[releaseOption - 1]);
                                        pokemon[releaseOption -1] = EmptySlot;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine(MsgFormatException);
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine(MsgOverflow);
                                }
                                catch (ArgumentNullException)
                                {
                                    Console.WriteLine(MsgNull, CancelOption, pokemon.Length);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine(MsgOutOfRange, CancelOption, pokemon.Length);
                                }
                            } while(!canRelease);
                        break;
                    };
                }
                catch (FormatException)
                {
                    Console.WriteLine(MsgFormatException);
                }
                catch (OverflowException)
                {
                    Console.WriteLine(MsgOverflow);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine(MsgNull, MinMenuOption, MaxMenuOption);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine(MsgOutOfRange, MinMenuOption, MaxMenuOption);
                }
            }while(!exitMenu);
        }
    }
}

