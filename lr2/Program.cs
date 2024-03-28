using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2
{
	internal class Program
	{
		public static List<string> users = new List<string>() { "admin", "guest", "user1", "user2", "user3" };
		public static List<string> files = new List<string>() { "file1", "file2", "file3", "file4", "file5" };

		public static int sizeArr = 5;

		public static bool isLogin = false;

		public static int index;
		public static string login;

		public static int[,] array = new int[sizeArr, sizeArr];

		static void Main(string[] args)
		{
			Random rnd = new Random();

			for (int i = 0; i < sizeArr; i++) { 
				for (int j = 0; j < sizeArr; j++) {
					if (i == 0) array[i, j] = 7;
					else array[i, j] = rnd.Next(0, 8);
				}
			}

			Print(array);

			while (true)
			{
				if (!isLogin) {
					Console.Write("User: ");
					login = Console.ReadLine();
					if (users.Contains(login))
					{
						isLogin = true;
                        Console.WriteLine("Идентификация прошла успешно, добро пожаловать в систему. \nВаш перечень прав:");
						index = users.IndexOf(login);
						for (int i = 0; i < sizeArr; i++)
						{
							Console.WriteLine($"{files[i]}:\t {array[index,i]}");

						}
                    }
					else Console.WriteLine("Incorrect user");
				}


				if (isLogin)
				{
					Console.Write("Command> ");
					string action = Console.ReadLine();
					switch (action)
					{
						case "read":
							Read();
							break;

						case "write":
							Write();
							break;

						case "grant":
							Grant();
							break;

						case "quit":
                            Console.WriteLine($"Работа пользователя {login} завершена. До свидания.");
                            isLogin = false;
							break;
					}
                    
                }
				
			}

            

        }

		public static void Read()
		{
            Console.WriteLine("Над каким объектом производится операция?");
			int indexObj = int.Parse(Console.ReadLine());
			if (array[index,indexObj-1] < 4) Console.WriteLine("Отказ в выполнении операции. У Вас нет прав для ее осуществления");
			else Console.WriteLine("Операция прошла успешно");
        }
		public static void Write()
		{
			Console.WriteLine("Над каким объектом производится операция?");
			int indexObj = int.Parse(Console.ReadLine());
			if (array[index, indexObj - 1] == 2 ||
				array[index, indexObj - 1] == 3 ||
				array[index, indexObj - 1] == 6 ||
				array[index, indexObj - 1] == 7) Console.WriteLine("Операция прошла успешно");
			else Console.WriteLine("Отказ в выполнении операции. У Вас нет прав для ее осуществления");
		}

		public static void Grant ()
		{
			Console.WriteLine("Право над каким объектом передается?");
			string Obj = Console.ReadLine();
			int indexObj = files.IndexOf(Obj);
			if (array[index, indexObj] == 1 ||
				array[index, indexObj] == 3 ||
				array[index, indexObj] == 5 ||
				array[index, indexObj] == 7)
			{
                Console.WriteLine("Какое право передается?");
				string pravo = Console.ReadLine();
				if (pravo.Equals("read") )
				{
					if (array[index, indexObj] == 5 ||
					    array[index, indexObj] == 7) 
					{
                        Console.Write("Какому пользователю передактся право? ");
						Console.ReadLine();
                        Console.WriteLine("Операция прошла успешно");
                    }
				}
				else if (pravo.Equals("write"))
				{
					if (array[index, indexObj] == 3 ||
						array[index, indexObj] == 7)
					{
						Console.Write("Какому пользователю передактся право? ");
						Console.ReadLine();
						Console.WriteLine("Операция прошла успешно");
					}
				}

			}
			else Console.WriteLine("У вас нет прав для её осуществления");
		}


		public static void Print(int[,] arr)
		{
			for (int i = 0;i < sizeArr; i++)
			{
				for(int j = 0; j< sizeArr; j++)
				{
					Console.Write(arr[i,j] + " ");
				}
                Console.WriteLine();
            }
		}
	}
}
