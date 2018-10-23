using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberinlist = new List<int>(new int[] {1,2,3,4,5,6,7,8,9,10,11,12});
            List<string> authorFirstName = new List<string>(new string[] { "J.K."/*Rowling*/, "Stephan" /*King*/, "Malcom" /*Gladwell*/, "Mitch" /*Albom*/, "Kevin"/*Kwan*/, "Charles"/*Dickens*/, "J.R.R."/*Tolkien*/, "Dan"/*Brown*/, "J.D."/*Salinger*/, "Harper"/*Lee*/, "Joseph"/*Keller*/, "James"/*Joyce*/ });
            List<string> authorLastName = new List<string>(new string[] { /*J.K.*/"Rowling", /*Stephan*/ "King", /*Malcom*/ "Gladwell", /*Mitch*/ "Albom", /*Kevin*/"Kwan", /*Charles*/"Dickens", /*J.R.R.*/"Tolkien", /*Dan*/"Brown", /*J.D.*/"Salinger", /*Harper*/"Lee", /*Joseph*/"Keller", /*Jame*/"Joyce" });
            List<string> bookTitle = new List<string>(new string[] { "Harry Potter", "IT", "Tipping Point", "Tuesdays with Morrie", "Crazy Rich Asians", "A Tale of Two Cities", "The Hobbit", "Davinci Code","Catcher in the Rye", "To Kill a Mockingbird", "Catch 22", "Ulysses" });
            List<string> checkedOut = new List<string>(new string[] { "Y", "Y", "Y", "N", "Y", "Y", "N", "Y", "Y", "Y", "Y", "Y" });


            int x,y;
            bool yesNo = true;
            while (yesNo == true)
            {
               
                try
                {
                    getMainMenu();
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x == 1)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        addBook(bookTitle, authorFirstName, authorLastName, checkedOut, numberinlist);
                        Console.ResetColor();
                        continue;
                    }
                    else if (x == 2)
                    {
                        Console.Clear();
                        CheckInOut(ref bookTitle, ref authorFirstName, ref authorLastName, ref checkedOut);
                            continue;
                    }
                    else if (x == 5)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("---------------------------------------------\n" +
                                          "|   How would you like to search the list?    |\n" +
                                          "---------------------------------------------");
                        Console.WriteLine("1. By Title.");
                        Console.WriteLine("2. By Author last name.");
                        Console.WriteLine("3. By Author first name.");
                        Console.ResetColor();
                        y = Convert.ToInt32(Console.ReadLine());
                        if (y == 1)
                        {
                            searchBook(bookTitle, authorFirstName, authorLastName, checkedOut, "What Title or keyword do you want to search? ");
                            continue;
                        }
                        else if (y == 2)
                        {
                            searchLastName(authorLastName, authorFirstName, bookTitle, checkedOut, "What Title or keyword do you want to search? ");
                            continue;
                        }
                        else if (y ==3)
                        {
                            searchFirstName(authorFirstName, authorLastName,bookTitle, checkedOut, "What Title or keyword do you want to search? ");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("That is not an option, back to the main menu");
                            Console.ReadKey();
                            continue;
                        }
                        
                    }
                    else if (x == 4)
                    {
                        Console.Clear();
                        
                        printList(authorFirstName, authorLastName, bookTitle, checkedOut);
                        Console.ReadKey();
                        Console.ResetColor();
                        continue;
                    }
                    else if (x==3)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("---------------------------------------------\n" +
                                          "|   How would you like to sort the list?  |\n" +
                                          "---------------------------------------------");
                        Console.WriteLine("1. By Title.");
                        Console.WriteLine("2. By Author last name.");
                        Console.WriteLine("3. By Author first name.");
                        Console.ResetColor();
                        y = Convert.ToInt32(Console.ReadLine());
                        if (y == 1)
                        {
                            sortLibrary(ref bookTitle, ref authorLastName, ref authorFirstName, ref checkedOut);
                            continue;
                        }
                        else if (y == 2)
                        {
                            sortLibrary(ref authorLastName, ref authorFirstName, ref bookTitle, ref checkedOut);
                            continue;
                        }
                        else if (y == 3)
                        {
                            sortLibrary(ref authorFirstName, ref authorLastName, ref bookTitle, ref checkedOut);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("That is not an option, back to the main menu");
                            Console.ReadKey();
                            continue;
                        }

                    }
                    else if (x == 6)
                    {
                        Console.WriteLine("Have a good day!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid option, try again");
                        continue;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("That is not a valid input");
                }
            }
          
        }
        static void CheckInOut(ref List<string> list1, ref List<string> list2, ref List<string> list3, ref List<string> list4)
        {
            bool goStop = true;
            while (goStop == true)
            {
                int x,y;
                try
                {
                    Console.Write($"Which number book would you like to check out? 1 - {list1.Count}.");
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x > ((list1.Count)))
                    {
                        Console.WriteLine("That is not an option to pick");
                        continue;
                    }
                    else if (x < 1)
                    {
                        Console.WriteLine("That is not a valid option");
                        continue;
                    }

                    y = (x - 1);
                    Console.WriteLine($"The Book you are looking for is {list1[y]}, by {list2[y]},{list3[y]} ");
                    if (list4[y] == "Y")
                    {
                        Console.WriteLine("Currently this book is checked out.");
                        Console.WriteLine("Do you have it and want to return it? (Y/N)");
                        string entry = Console.ReadLine();
                        while (entry.ToLower() != "n" || entry.ToLower() != "y" || entry.ToLower() != "no" || entry.ToLower() != "yes")
                        {
                            if (entry.ToLower() == "n" || entry.ToLower() == "no")
                            {
                                Console.WriteLine("Okay, just checking");
                                Console.ReadKey();
                                goStop = false;
                                break;
                            }
                            else if (entry.ToLower() == "y" || entry.ToLower() == "yes")
                            {
                                list4[y] = "N";
                                Console.WriteLine("Thank you for returning this book");
                                Console.ReadKey();
                                goStop = false;
                                break;
                            }
                            else
                            {
                                Console.Write("That is not a valid answer, Return? (y/n): ");
                                entry = Console.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Currently this book is available");
                        Console.WriteLine("Would you like to check thiis book out? (Y/N)");
                        string entry = Console.ReadLine();
                        while (entry.ToLower() != "n" || entry.ToLower() != "y" || entry.ToLower() != "no" || entry.ToLower() != "yes")
                        {
                            if (entry.ToLower() == "n" || entry.ToLower() == "no")
                            {
                                Console.WriteLine("Okay, thanks!");
                                Console.ReadKey();
                                goStop = false;
                                break;
                            }
                            else if (entry.ToLower() == "y" || entry.ToLower() == "yes")
                            {
                                list4[y] = "Y";
                                Console.WriteLine("Have a good read!");
                                Console.ReadKey();
                                goStop = false;
                                break;
                            }
                            else
                            {
                                Console.Write("That is not a valid answer, Check this book out? (y/n): ");
                                entry = Console.ReadLine();
                            }
                        }
                    }

                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("That is not a valid input");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("That is not a valid input");
                }

            }
        }


        static void getMainMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------------\n" +
                          "|   Welcome to the Library, dont make a lot of noise      |\n" +
                          "|            What would you like to do?                   |\n" +
                          "-----------------------------------------------------------");
            Console.WriteLine("1. Add a book.");
            Console.WriteLine("2. Borrow/Return a book.");
            Console.WriteLine("3. Sort list.");
            Console.WriteLine("4. See list of all books.");
            Console.WriteLine("5. Search the list.");
            Console.WriteLine("6. Exit");
            Console.ResetColor();
        }
        static void printList(List<string> list1, List<string> list2, List<string> list3, List<string> list4)

        {
            Console.BackgroundColor = ConsoleColor.DarkBlue; 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------------\n" +
                              "|     Author               Title              Checked out?|\n" +
                              "|     Name  (First,Last)                            (Y/N) |\n" +
                              "-----------------------------------------------------------");
            ///Console.ResetColor();
            for (int i = 0; i < list1.Count; i++)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("# {0,2} | {1,-10}{2,-9} |{3,-25}|{4,0}", (i + 1), list1[i], list2[i], list3[i],"");

                ///Console.Write($"{i + 1} = {list1[i]} {list2[i]}, {list3[i]}.  ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("  {0,0}  ", list4[i]);
                Console.ResetColor();

            }
        }
        static void sortLibrary ( ref List<string> list1,ref List<string>list2, ref List<string>list3, ref List<string> list4)
        {
            List<string> list1copy = new List<string>(list1);
            List<string> list2copy = new List<string>();
            List<string> list3copy = new List<string>();
            List<string> list4copy = new List<string>();


            list1copy.Sort();
            for (int i = 0; i < list1copy.Count; i++)
            {
                list2copy.Add(list2[list1.IndexOf(list1copy[i])]);
                list3copy.Add(list3[list1.IndexOf(list1copy[i])]);
                list4copy.Add(list4[list1.IndexOf(list1copy[i])]);
            }
            list1 = list1copy;
            list2 = list2copy;
            list3 = list3copy;
            list4 = list4copy;
        }
        static void addstringItem(List<string> list, string message)
        {
            string a;
            Console.Write(message);
            a = Console.ReadLine();
            while (String.IsNullOrEmpty(a) == true)
            {
                Console.Write($"That is not a valid answer, try again. {message}  ");
                a = Console.ReadLine();
            }
            list.Add(a);

        }
        static void getList(List<string> list1, List<string> list2)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                Console.WriteLine($"#{i + 1}. Fruit name:{list1[i]}. Color: {list2[i]}.");
            }
        }
        static void addBook(List<string> bookTitle, List<string> authorFirstName, List<string> authorLastName, List<string> checkedOut, List<int> numberinlist  )
        {
            addstringItem(bookTitle, "What is the name of the book: ");
            addstringItem(authorFirstName, "What is the first name of the author: ");
            addstringItem(authorLastName, "What is the last name of the author: ");
            checkedOut.Add("Y");
            numberinlist.Add(numberinlist.Count + 1);

        }
        static void searchBook(List<string> list, List<string> list2, List<string> list3, List<string> list4, string message)
        {
            bool found = false;
            while (found != true)
            {
                Console.WriteLine(message);
                string choice = Console.ReadLine();
                List<string> listCopy = new List<string>(list);
                for (int i = 0; i < listCopy.Count; i++)
                {
                    string[] splitString = listCopy[i].Split(' ');
                    for (int j = 0; j < splitString.Length; j++)
                    {
 
                            string test = splitString[j];
                            if (test.ToLower() == choice.ToLower())
                            {

                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("We found a match");
                                Console.WriteLine("Here is the information");

                                Console.WriteLine("{0}, by {1} {2}. is this book checked out? (Y/N) {3,0}", list[i], list2[i], list3[i], list4[i]);
                                Console.WriteLine($"This book is number {i + 1} in the list.");
                                Console.ResetColor();
                                Console.ReadKey();
                            found = true;
                                break;
                            }
                            else
                            {
                           message = "We could not find that one. PLease try a different word: ";
                            }
                     }
                }
            }
        }
        static void searchLastName(List<string> list, List<string> list2, List<string> list3, List<string> list4, string message)
        {
            bool found = false;
            while (found != true)
            {
                Console.WriteLine(message);
                string choice = Console.ReadLine();
                List<string> listCopy = new List<string>(list);
                for (int i = 0; i < listCopy.Count; i++)
                {
                    string[] splitString = listCopy[i].Split(' ');
                    for (int j = 0; j < splitString.Length; j++)
                    {
                        string test = splitString[j];
                        if (test.ToLower() == choice.ToLower())
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("We found a match");
                            Console.WriteLine("Here is the information");

                            Console.WriteLine("{2}, by {1} {0}. is this book checked out? (Y/N) {3,0}", list[i], list2[i], list3[i], list4[i]);
                            Console.WriteLine($"This book is number {i + 1} in the list.");
                            Console.ResetColor();
                            Console.ReadKey();
                            found = true;
                            break;
                        }
                        else
                        {
                           message = "We could not find that one. PLease try a different word: ";
                        }
                    }
                }
            }
        }
        static void searchFirstName(List<string> list, List<string> list2, List<string> list3, List<string> list4, string message)
        {
            bool found = false;
            while (found != true)
            {
                Console.WriteLine(message);
                string choice = Console.ReadLine();
                List<string> listCopy = new List<string>(list);
                for (int i = 0; i < listCopy.Count; i++)
                {
                    string[] splitString = listCopy[i].Split(' ');
                    for (int j = 0; j < splitString.Length; j++)
                    {
                        string test = splitString[j];
                        if (test.ToLower() == choice.ToLower())
                        {

                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("We found a match");
                            Console.WriteLine("Here is the information");

                            Console.WriteLine("{2}, by {0} {1}. is this book checked out? (Y/N) {3,0}", list[i], list2[i], list3[i], list4[i]);
                            Console.WriteLine($"This book is number {i + 1} in the list.");
                            Console.ResetColor();
                            Console.ReadKey();
                            found = true;
                            break;
                        }
                        else
                        {
                            message = "We could not find that one. PLease try a different word: ";
                        }
                    }
                }
            }
        }
    }
}

