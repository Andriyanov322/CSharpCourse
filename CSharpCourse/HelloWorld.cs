using System;
using System.Globalization;
using System.Text;
/*Писать комментарии не для того, чтобы показать что происходит в коде, 
  а для того, чтобы объяснить как и почему.
  Также лучше писать комментарии над кодом,а не справа от него, для лучшей читаемости.
*/
namespace CSharpCourse
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static void CastingAndParsing ()
        {
            byte b = 3; //0000 0011 - в бинарном виде
            int i = b; //0000 0000 0000 0000 0000 0000 0000 0011 - в бинарном виде
            long l = i; //0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0011 - в бинарном виде

            float f = i; //3.0
            Console.WriteLine(f);

            b = (byte)i; //Запись числа из int в byte , указывая компилятору, что наше число типа int входит в диапазон byte
            Console.WriteLine(b);

            i = (int)f; //Запись числа из int в float , указывая компилятору, что наше число типа int входит в диапазон float

            f = 3.1f;
            i = (int)f;
            Console.WriteLine(i); // На выводе будет число 3 так как мы перевели перменнкю из тип с плавающей точкой в целочисленный (Грубейшая Ошибка)

            string str = "1";
            //i = (int)str; - Нерабочий способ перевода из строкового типа в целочисленный
            i = int.Parse(str); //Рабочий метод перевода из строкового в целочисленный

            int x = 5;
            //double result = x / 2; - неправильный способ деления (Нужно сначала объявить для компилятора, что x является типом float
            double result = (double)x / 2; //Правильный способ деления
            Console.WriteLine(result);
        } //Конвертирование типов данных у переменных
        static void ConsoleBasics()
        {
            Console.WriteLine("Hi, please tell me your name");

            string name = Console.ReadLine(); //Ввод имени в консоли
            string sentence = $"Your name is {name}";
            Console.WriteLine(sentence);

            Console.WriteLine("Hi, please tell me your age.");
            string input = Console.ReadLine(); //Ввод возраста через консоль
            int age = int.Parse(input); //Перевод строкового типа в целочисленный

            sentence = $"you age is {age}";
            Console.WriteLine(sentence);

            Console.Clear(); //Очистка консоли
            Console.BackgroundColor = ConsoleColor.Green; //Установка зеленого цвета фона текста в консоли
            Console.ForegroundColor = ConsoleColor.Red; //Установка красного цвета текста в консоли

            Console.Write("New Style ");
            Console.Write("New Style\n"); //Аналогично Console.WriteLine("New Style");
        } //Операции над консолью
        static void ComparingStrings()
        {
            string str1 = "abcde";
            string str2 = "abcde";
            bool areEqual = str1 == str2; //Сравнение строк на одинаковость
            Console.WriteLine(areEqual);

            areEqual = string.Equals(str1, str2, StringComparison.Ordinal); //Аналогичное вышестоящему сравнению строк применение метода StringComparison
            Console.WriteLine(areEqual);

            string s1 = "Strasse";
            string s2 = "Straße";
            areEqual = string.Equals(s1, s2, StringComparison.Ordinal); //Проверка двух строк с побитовым разложением (проверка синтаксиса в точности)
            Console.WriteLine(areEqual);
            areEqual = string.Equals(s1, s2, StringComparison.InvariantCulture); //Проверка двух строк учитывая Языковые особенности всех культур
            Console.WriteLine(areEqual);
            areEqual = string.Equals(s1, s2, StringComparison.CurrentCulture); //Проверка двух строк учитывая языковые особеноости культуры системы
            Console.WriteLine(areEqual); //По итогу код не работает, хз почему, стану умнее, разберусь
        } //Сравнение строк
        static void StringFormat()
        {
            string name = "Makson";
            int age = 21;
            string str1 = string.Format("My name is {0} and I'm {1}", name, age); //Выведение строки методом PlaceHolder'а
            Console.WriteLine(str1);
            string str2 = "My name is " + name + " and I'm " + age; // Выведение строки методом Concat (сложения)
            Console.WriteLine(str2);
            string str3 = $"My name is {name} and I'm {age}"; // Выведение строки другим методом Placeholder'a
            Console.WriteLine(str3);
            string str4 = "My name is \nMakson"; //Выведение строки с переходом на новую строку 
            Console.WriteLine(str4);
            string str5 = "I'm \t21"; //Выведение строки с табуляцией
            Console.WriteLine(str5);
            str4 = $"My name is {Environment.NewLine}Makson"; //Вывод строки с переходом на новую строку (кроссплатформенный)
            Console.WriteLine(str4);
            // str4 4 = "My name is Makson and I'm a good programmer"; - неправильная запись кавычек внутри строки
            str4 = "My name is Makson and I'm a \"good\" programmer"; //Вывод строки с кавычками
            Console.WriteLine(str4);
            // string str6 = "C:\tmp\test_file.txt"; - неправильная запись в строку пути файла
            string str6 = "C:\\tmp\\test_file.txt"; // Правильная запись в строку пути файла
            Console.WriteLine(str6);
            str6 = @"C:\tmp\test_file.txt"; //Другой вариант правильной записи пути файла методом Verbatim Strings
            Console.WriteLine(str6);
            int answer = 42;
            string result = string.Format("{0:d}", answer); //Запись в строку методом Placeholder целого числа (Вывод: 42)
            string result2 = string.Format("{0:d4}", answer); //Запись в строку методом Placeholder целого числа в формате 4-х символов то-есть (Вывод: 0042)
            Console.WriteLine(result);
            Console.WriteLine(result2);
            result = string.Format("{0:f}", answer); //Запись в строку методом Placeholder С добавлением нулей после точки, по стандарту 2 (Вывод: 42.00)
            result2 = string.Format("{0:f4}", answer); //Запись в строку методом Placeholder С добавлением четырех нулей после точки (Вывод: 42.0000)
            Console.WriteLine(result);
            Console.WriteLine(result2);
        } //Выведение строк различными методами
        static void StringBuilderDemo()
        {
            StringBuilder sb = new(); //Использование метода для построения строк (Использование метода StringBuilder рекомендуется, когда количество строк большое)
            sb.Append("My ");
            sb.Append("name ");
            sb.Append("is ");
            sb.Append("Makson"); // Последовательное присоединение к концу строки различных символов
            sb.AppendLine("!"); //Присоедение символов с переводом курсора на следующую строку
            sb.AppendLine("Hello everyone!");

            string str = sb.ToString(); //Присвоение str строкового варианта переменной sb
            Console.WriteLine(str);
            Console.WriteLine(sb); //Вывод их обоих
        } //Построение строк методом PlaceHolder
        static void StringModifications()
        {
            string nameConcat = string.Concat("My ", "name ", "is ", "Makson"); //Объединение строк методом Concat
            Console.WriteLine(nameConcat);

            nameConcat = string.Join(" ", "My", "name", "is", "Makson4ik"); //Объединение строк методом Join с выбранным разделителем
            Console.WriteLine(nameConcat);

            nameConcat = "My " + "name " + "is " + "Makson"; //Объединение строк методом сложения
            Console.WriteLine(nameConcat);

            string newName = nameConcat.Insert(0, "By the way "); //Добавление к существукющей строке другую строку с первого символа
            Console.WriteLine(nameConcat.Insert(0, "By the way "));

            nameConcat = nameConcat.Remove(4, 4); //Удаление четырех символов строки, начиная с пятого символа
            Console.WriteLine(nameConcat);

            string replaced = nameConcat.Replace('a', 'f'); //Замена букв a на f в строке
            Console.WriteLine(replaced);

            string data = "12;28;34;25;64"; //создание строки с разделителем
            string[] splitData = data.Split(';'); //Разделение строки на массив обозначая её разделитель
            string first = splitData[2]; //Присвоение переменный строки конкретного символа из массива
            Console.WriteLine(first);

            char[] chars = nameConcat.ToCharArray(); //Разделение строки на массив
            Console.WriteLine(nameConcat);
            Console.WriteLine(chars[0]); //Вывод первого символа разделенной на массив строки
            Console.WriteLine(chars[5]); //Вывод шестого символа разделенной на массив строки

            string lower = nameConcat.ToLower(); // Создание экземпляра строки nameConcat со всеми буквам в нижнем регистре
            Console.WriteLine(lower);

            string upper = nameConcat.ToUpper(); // Создание экземпляра строки nameConcat со всеми буквам в верхнем регистре
            Console.WriteLine(upper);

            string makson = "  My name is Makson "; // Создание строки
            Console.WriteLine(makson.Trim());      // и последующее обрезание пробелов с левого и правого края
        } //Операции над строками (Часть 2)
        static void StringEmptiness() 
        {
            string str = string.Empty; //same as " string empty = ""; "

            string empty = ""; //Равноценно команде сверху
            string whiteSpaced = " "; //Создание строки с пробелом
            string notEmpty = " b"; //Создание строки с пробелом и буквой b
            string nullString = null; //Создание строки с пустым значением

            {   
                Console.WriteLine("IsNullOrEmpty");
                bool isNullOrEmpty = string.IsNullOrEmpty(nullString);
                Console.WriteLine(isNullOrEmpty);

                isNullOrEmpty = string.IsNullOrEmpty(empty);
                Console.WriteLine(isNullOrEmpty);

                isNullOrEmpty = string.IsNullOrEmpty(whiteSpaced);
                Console.WriteLine(isNullOrEmpty);

                isNullOrEmpty = string.IsNullOrEmpty(notEmpty);
                Console.WriteLine(isNullOrEmpty);
            } //Проверка строк на ничего или пустоту; Пробел не является пустотой или ничем

            { 
                Console.WriteLine();
                Console.WriteLine("IsNullOrWhiteSpace");

                bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(nullString);
                Console.WriteLine(isNullOrWhiteSpace);

                isNullOrWhiteSpace = string.IsNullOrWhiteSpace(empty);
                Console.WriteLine(isNullOrWhiteSpace);

                isNullOrWhiteSpace = string.IsNullOrWhiteSpace(whiteSpaced);
                Console.WriteLine(isNullOrWhiteSpace);

                isNullOrWhiteSpace = string.IsNullOrWhiteSpace(notEmpty);
                Console.WriteLine(isNullOrWhiteSpace);
            } //Проверка строк на ничего или пробелы
        } //Проверка строк на пустоту
        static void QuearyingStrings() 
        {
            string name = "abracadabra";
            bool containsA = name.Contains('a'); //Булевая операция проверки содержания переменной name на букву a
            bool containsE = name.Contains('E'); //Булевая операция проверки содержания переменной name на букву E
            Console.WriteLine(containsA);
            Console.WriteLine(containsE);

            bool endswithAbra = name.EndsWith("abra"); //Булевая операция проверки содержания переменной name в конце фразы abra
            Console.WriteLine(endswithAbra);

            bool startwithAbra = name.StartsWith("abra"); //Булевая операция проверки содержания переменной name в начале фразы abra
            Console.WriteLine(startwithAbra);

            int indexOfA = name.IndexOf('a', 1); //Операция вычисления индекса второй буквы a в слове abracadabra (Ответ: 3)
            Console.WriteLine(indexOfA);

            int lastIndexofR = name.LastIndexOf('r'); //Операция вычисления индекса последней буквы r в слове abracadabra (Ответ: 9)
            Console.WriteLine(lastIndexofR);

            Console.WriteLine(name.Length); //Операция вычисления длины слова abracadabra (Ответ: 11)

            string substrFrom5 = name.Substring(5); //Операция выписывания из строки символов начиная с шестого символа (Ответ: adabra)
            string substrFromTo = name.Substring(0, 2); //Операция выписывания из строки символов начиная с первого(включительно) символа и до третьего символа(невключительно) (Ответ: ab)
            Console.WriteLine(substrFrom5 + " " + substrFromTo);
        } //Операции над строками (Часть 1)
        static void StaticAndInstanceMethods()
        {
            string name = "AbraKadabra";
            bool containsA = name.Contains('D'); //Булевая операция проверки содержания переменной name на букву D
            bool containsE = name.Contains('E'); //Булевая операция проверки содержания переменной name на букву E

            Console.WriteLine(containsA);
            Console.WriteLine(containsE);

            string abc = string.Concat("a", "b", "c"); //Объединение трех строк
            Console.WriteLine(abc);

            Console.WriteLine(int.MinValue);

            int x = 1;
            string xStr = x.ToString(); //Перевод целочисленной переменной в строку
            Console.WriteLine(x);
            Console.WriteLine(xStr);
        } //Содержание букв в строке
        static void BooleanOperations() {
            int x = 3;
            int y = 2;

            bool areEqual = x == y; //Создание переменной которая проверяет равнозначность двух переменных
            Console.WriteLine(areEqual);

            bool result = x > y; //Создание переменной которая проверяет больше ли икс игрика
            Console.WriteLine(result);

            result = x >= y; //Создание переменной которая проверяет больше либо равен икс игрика
            Console.WriteLine(result);

            result = x < y; //Создание переменной которая проверяет меньше ли икс игрика
            Console.WriteLine(result);

            result = x <= y; //Создание переменной которая проверяет меньше или равно икс игрика
            Console.WriteLine(result);

            result = x != y; //Создание переменной которая проверяет неравнозначность переменных
            Console.WriteLine(result);
        } //Булевые операции сравнения
        static void MathOperations()
        {
            int x = 1;
            int y = 2;

            int z = x + y; //Арифметическая операция сложения
            int k = x - y; //Арифметическая операция вычитания
            int a = z + k - y; //Арифметическая операция сложения и вычитания

            Console.WriteLine(z);
            Console.WriteLine(k);
            Console.WriteLine(a);

            Console.WriteLine();

            int b = z * 2; //Арифметическая операция умножения
            float c = k / 2f; //Арифметическая операция деления

            Console.WriteLine(b);
            Console.WriteLine(c);

            Console.WriteLine();

            a = 4 % 2; //Арифметическая операция получения остатка при делении на 2 из целочисленной переменной
            b = 5 % 2; //Арифметическая операция получения остатка при делении на 2 из целочисленной переменной
            Console.WriteLine(a);
            Console.WriteLine(b);

            Console.WriteLine();

            a = 3;
            a = a * a; //Арифметическая операция степени
            Console.WriteLine(a);

            a = 2;
            a = a + a * a; //Умножение как в математике идет в приоритете
            Console.WriteLine(a);

            Console.WriteLine();

            a = 2;
            a *= 2; //Арифметическая операция умножении а на 2
            Console.WriteLine(a);
            a /= 2; //Арифметическая операция деления а на 2
            Console.WriteLine(a);
        }  //Математические операции
        static void Increments()
        {
            int x = 1;
            x = x + 1; //Повышение x на 1
            Console.WriteLine(x);

            x++; //Правильное применение операции инкремента (постфиксное)
            Console.WriteLine(x);

            ++x; //Другое вариант применения операции посткремента (префиксное)
            Console.WriteLine(x);

            Console.WriteLine();

            x = x - 1; //Понижение x на 1
            x--; //Операция декремента (постфиксное)
            --x; //Операция декремента (префиксное)
            Console.WriteLine(x);

            Console.WriteLine("Learn about increments");
            Console.WriteLine($"Last x state is {x}");

            int j = x++;
            Console.WriteLine(j);
            Console.WriteLine(x); //При применении постфиксного инкремента операция присвоения имеет больший приоритет, поэтому j стало равно предыдущему значению x=1, а x повысился на 1 и стал равен 2

            j = ++x; 
            Console.WriteLine(j);
            Console.WriteLine(x); //А префиксный инкремент имеет больший приоритет по сравнению с операцией присвоения, поэтому сначала x повысился до 3 и потом j стал равен x то есть тоже 3

            Console.WriteLine();

            x += 2;
            Console.WriteLine(x); //Сложение x и 2

            j -= 2;
            Console.WriteLine(j); //Вычитание из j двух
        } //Сокращенные арифметические операции
        static void Overflow() 
        {
            //checked
            //{ 
            uint x = uint.MaxValue; // Вызов максимально доступного числа в диапазоне uint (4294967295)

            Console.WriteLine(x);

            x = x + 1; // Переполнение программа выдаст ошибку

            Console.WriteLine(x);

            x = x - 1; // Число вернется к аналоговому состоянию

            Console.WriteLine(x);
            //}
        } //Переполнение
        static void Scopes() 
        {
            var a = 1;
            {
                var b = 2;
                {
                    var c = 3;

                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                }
                Console.WriteLine(a);
                Console.WriteLine(b);
                //Console.WriteLine(c); Вывод переменной закомментирован так как в данной области она не объявлена и при запуске данного кода программа выдаст ошибку
            }
            Console.WriteLine(a);
            //Console.WriteLine(b); 
            //Console.WriteLine(c); Вывод переменных закомментирован так как в данной области они не объявлены и при запуске данного кода программа выдаст ошибку    
        } //Области видимости переменных
        static void Literals()
        {
            int x = 0b11; //Объявление в двоичном коде цифры 3
            int y = 0b1001; //Объявление в двоичном коде цифры 9
            int k = 0b10001001; //Объявление в двоичном коде цифры 137
            int m = 0b1000_1001; //Объявление в двоичном коде цифры 137 в удобном для обзора кода виде

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(k);
            Console.WriteLine(m);

            x = 0x1F; //Объявление в шестнадцатиричном коде цифры 31
            y = 0xFF0D; //Объявление в шестнадцатиричном коде цифры 65293
            k = 0x1FAB30EF; //Объявление в шестнадцатиричном коде цифры 531312879
            m = 0x1FAB_30EF; //Объявление в шестнадцатиричном коде цифры 531312879 в удобном для обзора кода виде

            Console.WriteLine();
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(k);
            Console.WriteLine(m);

            Console.WriteLine();

            Console.WriteLine(4.5e2); //Вывод числа в степенном виде
            Console.WriteLine(3.1e-1); //Вывод числа в степенном виде

            Console.WriteLine();

            Console.WriteLine('\x78'); //Вывод символа в шестнадцатиричном коде из таблицы ASCII
            Console.WriteLine('\x5A'); //Вывод символа в шестнадцатиричном коде из таблицы ASCII
            Console.WriteLine('\u0420'); //Вывод символа из таблицы UNICODE
            Console.WriteLine('\u0421'); //Вывод символа из таблицы UNICODE
        } //Литералы в различных кодировках
        static void Variables()
        {
            int x = -1; // Объявление целочисленной переменной

            int y;
            y = 2; // Объявление переменной заранее и использование её позже.

            //Int32 x1 = -1;

            //uint z = -1;

            float f = 1.1f; // Объявление переменной с плавающей точкой типа float

            double d = 2.3; // Объявление переменной с плавающей точкой типа double

            int x2 = 0; 
            int x3 = new int(); //Объявление целоччисленной переменной двумя способами (они равноценны)

            var a = 1;
            var b = 1.2; //Объявление неявного типа переменных (нерекомендован когда применение переменной известно)

            //Dictionary<int, string> dict = new Dictionary<int, string>();
            //var dict = new Dictionary<int, String>();

            //var v;

            decimal money = 3.0m; //Объявление денежного типа переменных

            char character = 'A'; //Объявление символьного типа переменной
            string name = "Makson"; //Объявление строкового типа переменной

            bool CanDrive = true; 
            bool CanDraw = false; //Объявление булевого типа переменных

            object obj1 = 1; 
            object obj2 = "obj2"; //Объявление типа переменной object

            Console.WriteLine(a);
            Console.WriteLine(name);
        } //Объявление переменных
    }
}

