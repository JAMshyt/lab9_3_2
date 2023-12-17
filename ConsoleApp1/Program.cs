using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace Рекурсии
{
	internal class Program
	{
		static Random rnd = new Random();
		static int[] CreateArr(int Lenght)
		{
			int[] arr = new int[Lenght];
			if (0 < Lenght)
			{
				arr[0] = rnd.Next(-50, 50);
				CreateArr(Lenght - 1).CopyTo(arr, 1);
			}
			return arr;
		}

		static int Sum(List<int> list, ref int sum)
		{
			if (list.Count > 0)
			{
				if (Math.Abs(list[0]) % 10 == 7) sum = sum + list[0];
				list.RemoveAt(0);
				Sum(list, ref sum);
			}
			return sum;
		}

		static int Count3(List<int> list, ref int cont3)
		{
			if (list.Count > 0)
			{
				char[] numb = list[0].ToString().ToCharArray();
				if (numb.Contains('3')) cont3++;
				list.RemoveAt(0);
				Count3(list, ref cont3);
				return cont3;
			}
			return cont3;
		}

		static bool Have3(List<int> list)
		{
			if (list.Count > 0)
			{
				char[] numb = list[0].ToString().ToCharArray();
				if (numb.Contains('3')) return true;
				else
				{
					list.RemoveAt(0);
					return Have3(list);
				}
			}
			return false;
		}

		static int sumSost(List<int> list, ref int sumsost)
		{
			bool flag = false;
			if (list.Count > 0)
			{
				if (list[0] > 2)
				{
					for (int i = 2; i <= Math.Sqrt(list[0]); i++)
					{
						if (list[0] % i == 0) { flag = true; }
					}
					if (flag) { sumsost = sumsost + list[0]; Console.Write(list[0] + " "); }
				}
				list.RemoveAt(0);
				sumSost(list, ref sumsost);
			}
			return sumsost;
		}

		static bool haveSost(List<int> list)
		{
			if (list.Count > 0)
			{
				if (list[0] > 2)
				{
					for (int i = 2; i <= Math.Sqrt(list[0]); i++)
						if (list[0] % i == 0)
						{
							list.RemoveAt(0);
							return haveSost(list);
						}
					return false;
				}
				else if (list[0] < 4)
				{
					return false;
				}
			}
			return true;
		}

		static int CountNeChet(List<int> list)
		{
			if (list.Count > 0)
			{
				if (list[0] % 2 != 0)
				{
					list.RemoveAt(0);
					return 1 + CountNeChet(list);
				}
				else
				{
					list.RemoveAt(0);
					return CountNeChet(list);
				}
			}
			return 0;
		}

		static int sumProst(List<int> list)
		{
			if (list.Count > 0)
			{
				if (list[0] > 0 & !list[0].ToString().ToCharArray().Contains('5'))
				{
					bool flag = true;
					int num = list[0];
					if (list[0] == 1 || list[0] == 2 || list[0] == 3)
					{
						flag = true;
					}
					else if (list[0] > 3)
					{
						for (int i = 2; i <= Math.Sqrt(list[0]); i++)
						{
							if (list[0] % i == 0) { flag = false; }
						}
					}
					if (flag)
					{
						Console.Write(list[0] + " ");
						list.RemoveAt(0);
						return num + sumProst(list);
					}
					list.RemoveAt(0);
					return sumProst(list);
				}
				else
				{
					list.RemoveAt(0);
					return sumProst(list);
				}

			}
			return 0;
		}

		static bool estNeChet(List<int> list)
		{
			if (list.Count > 0)
			{
				if (list[0] % 2 != 0)
				{
					return true;
				}
				else
				{
					list.RemoveAt(0);
					return estNeChet(list);
				}
			}
			return false;
		}

		static bool allProst(List<int> list)
		{
			if (list.Count > 0)
			{
				if (list[0] > 0 & !list[0].ToString().ToCharArray().Contains('5'))
				{
					bool flag = true;
					int num = list[0];
					if (list[0] == 1 || list[0] == 2 || list[0] == 3)
					{
						flag = true;
					}
					else if (list[0] > 3)
					{
						for (int i = 2; i <= Math.Sqrt(list[0]); i++)
						{
							if (list[0] % i == 0) { flag = false; }
						}
					}
					if (flag)
					{
						list.RemoveAt(0);
						return allProst(list);
					}
					return false;
				}
				else
				{
					return false;
				}

			}
			return true;
		}

		static void InsertSort(int[] arr, int n)
		{
			if (n <= 1)
				return;

			InsertSort(arr, n - 1);

			int last = arr[n - 1];
			int j = n - 2;

			while (j >= 0 && arr[j] > last)
			{
				arr[j + 1] = arr[j];
				j--;
			}
			arr[j + 1] = last;
		}
		static void Main(string[] args)
		{
			for (; true;)
			{
				Console.WriteLine("\nВыберите задание (1, 2, 3) или выход (4):");
				switch (int.Parse(Console.ReadLine()))
				{
					case 1:
						int sum = 0;
						Console.WriteLine("\nВведите длинну:");
						int Lenght = int.Parse(Console.ReadLine());
						int[] arr = CreateArr(Lenght);

						Console.WriteLine("Массив:");
						foreach (var a in arr) Console.Write("{0,3}   ", a);

						Console.WriteLine("\nСумма элементов заканчивающиеса на 7(рекурсия):" + Sum(arr.Cast<int>().ToList(), ref sum));
						int sum2 = 0;
						for (int i = 0; i < arr.Length; i++)
						{
							if (Math.Abs(arr[i]) % 10 == 7) sum2 += arr[i];
						}
						Console.WriteLine("Сумма элементов заканчивающиеса на 7(итерации):" + sum2);
						break;

					case 2:
						Console.WriteLine("\nВведите длинну:");
						int Lenght2 = int.Parse(Console.ReadLine());
						int[] arr2 = CreateArr(Lenght2);

						Console.WriteLine("Массив:");
						foreach (var a in arr2) Console.Write("{0,3}   ", a);

						int co = 0;
						Console.WriteLine("\n\nКол-во элементов содержащих цифру 3 (рекурсия):" + Count3(arr2.Cast<int>().ToList(), ref co));

						int co2 = 0;
						for (int i = 0; i < arr2.Length; i++)
						{
							char[] num = arr2[i].ToString().ToCharArray();
							if (num.Contains('3')) co2++;
						}
						Console.WriteLine("Кол-во элементов содержащих цифру 3 (итерации):" + co2);
						Console.WriteLine();
						int sumsost = 0;
						Console.WriteLine("\nСумма составных элементов (рекурсия)" + sumSost(arr2.Cast<int>().ToList(), ref sumsost));

						int sumsost2 = 0;
						for (int i = 0; i < arr2.Length; i++)
						{
							if (arr2[i] > 2)
							{
								bool flag = false;
								for (int j = 2; j <= Math.Sqrt(arr2[i]); j++)
								{
									if (arr2[i] % j == 0) { flag = true; }
								}
								if (flag) { sumsost2 = sumsost2 + arr2[i]; Console.Write(arr2[i] + " "); }
							}
						}

						Console.WriteLine("\nСумма составных элементов (итерации)" + sumsost2);

						Console.WriteLine("\nОбладает хотя бы один элемент цифрой 3(рекурсия):" + Have3(arr2.Cast<int>().ToList()));

						bool flag2 = false;
						for (int i = 0; i < arr2.Length; i++)
						{
							char[] numb = arr2[i].ToString().ToCharArray();
							if (numb.Contains('3')) { flag2 = true; break; }
						}

						Console.WriteLine("Обладает хотя бы один элемент цифрой 3(итерации):" + flag2);

						Console.WriteLine("\nВсе ли элементы составные(рекурсия):" + haveSost(arr2.Cast<int>().ToList()));

						bool flag3 = false;
						for (int i = 0; i < arr2.Length; i++)
						{
							flag3 = false;
							if (arr2[i] > 3)
							{
								for (int j = 2; j <= Math.Sqrt(arr2[i]); j++)
									if (arr2[i] % j == 0) { flag3 = true; }
							}
							else if (arr2[i] < 4)
							{
								flag3 = false;
								break;
							}
							if (!flag3) { break; }
						}

						Console.WriteLine("Все ли элементы составные(итерации):" + flag3);

						break;

					case 3:

						Console.WriteLine("\nВведите длинну:");
						int Lenght3 = int.Parse(Console.ReadLine());
						int[] arr3 = CreateArr(Lenght3);

						Console.WriteLine("Массив:");
						foreach (var a in arr3) Console.Write("{0,3}   ", a);

						Console.WriteLine("\n\nКол-во нечетных(рекурсия):" + CountNeChet(arr3.Cast<int>().ToList()));

						int count = 0;
						for (int i = 0; i < arr3.Length; i++)
						{
							if (arr3[i] % 2 != 0) count++;
						}
						Console.WriteLine("Кол-во нечетных(итерации):" + count);
						Console.WriteLine();
						Console.WriteLine("\nСумма простых без 5(рекурсия):" + sumProst(arr3.Cast<int>().ToList()));

						int sumSo = 0;
						for (int i = 0; i < arr3.Length; i++)
						{
							bool sost = true;
							if (arr3[i] == 1 || arr3[i] == 2 || arr3[i] == 3)
							{
								sumSo += arr3[i];
								Console.Write(arr3[i] + " ");
							}
							else if (arr3[i] > 0 & !arr3[i].ToString().ToCharArray().Contains('5'))
							{
								for (int j = 2; j <= Math.Sqrt(arr3[i]); j++)
								{
									if (arr3[i] % j == 0) { sost = false; }
								}
								if (sost)
								{
									sumSo += arr3[i];
									Console.Write(arr3[i] + " ");

								}
							}

						}
						Console.WriteLine("\nСумма простых без 5(итерации):" + sumSo);


						Console.WriteLine("\nХотя бы один нечетный(рекурсия):" + estNeChet(arr3.Cast<int>().ToList()));

						bool Nechet = false;

						for (int i = 0; i < arr3.Length; i++)
						{
							if (arr3[i] % 2 != 0)
							{
								Nechet = true;
								break;
							}
						}

						Console.WriteLine("Хотя бы один нечетный(итерации):" + Nechet);

						Console.WriteLine("\nВсе ли простые без 5(рекурсия):" + allProst(arr3.Cast<int>().ToList()));

						bool sost2 = true;
						for (int i = 0; i < arr3.Length; i++)
						{
							if (arr3[i] != 1 || arr3[i] != 2 || arr3[i] != 3)
							{
								if (arr3[i] > 0 & !arr3[i].ToString().ToCharArray().Contains('5'))
								{
									for (int j = 2; j <= Math.Sqrt(arr3[i]); j++)
									{
										if (arr3[i] % j == 0) { sost2 = false; break; }
									}
								}
								else
								{
									sost2 = false;
									break;
								}
							}
						}

						Console.WriteLine("Все ли простые без 5(итерации):" + sost2);

						Console.WriteLine("Сортировка:");
						InsertSort(arr3, arr3.Length);
						foreach (var r in arr3)
						{
							Console.Write(r + " ");
						}
						break;

					case 4:
						Environment.Exit(0);
						break;
				}
			}
		}
	}
}
