using System.Runtime.InteropServices;

//MessageBox(IntPtr.Zero, "Заголовок", "Основной текст!", 0); // ок
//MessageBox(IntPtr.Zero, "Заголовок", "Основной текст!", 1); // ок,отмена
//MessageBox(IntPtr.Zero, "Заголовок", "Основной текст!", 2); // прервать, повтор, пропустить
//MessageBox(IntPtr.Zero, "Заголовок", "Основной текст!", 3); // да, нет, отмена
//MessageBox(IntPtr.Zero, "Заголовок", "Основной текст!", 4); // да и нет
//MessageBox(IntPtr.Zero, "Заголовок", "Основной текст!", 5); // повтор, отмена
//var value = MessageBox(IntPtr.Zero, "Заголовок", "Основной текст!", 6); // отмена, повтор, продолжить


//[DllImport("user32.dll")]
//static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
//
var argumentA = int.Parse(Console.ReadLine());
var argumentB = int.Parse(Console.ReadLine());

var result = Division(argumentA, argumentB);
Console.WriteLine(result);

[DllImport("SimpleMath.dll", CharSet = CharSet.Unicode)]
static extern int Division(int a, int b);
